using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BVPortalApi.CommonFeatures;
using BVPortalApi.CommonFeatures.Contracts;
using BVPortalApi.DTO;
using BVPortalApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BVPortalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectAssignmentController : ControllerBase
    {
        private readonly BVContext DBContext;

        public ProjectAssignmentController(BVContext DBContext)
        {
            this.DBContext = DBContext;
        }
        [HttpGet("GetProjectAssignment")]
        public async Task<ActionResult<List<ProjectAssignmentDTO>>> Get()
        {
            var List = await DBContext.ProjectAssignment.Select(
                s => new ProjectAssignmentDTO
                {
                    Id = s.Id,
                    ProjectId = s.ProjectId,
                    EmployeeId  = s.EmployeeId,
                    ProjectName = s.Project.ProjectName,
                    EmployeeName  = s.Employee.FirstName + " " + s.Employee.LastName,
                    Notes = s.Notes,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate
                   }
            ).ToListAsync();
            
            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }
        [HttpPost("InsertProjectAssignment")]
        public async Task < HttpStatusCode > InsertProjectAssignment(ProjectAssignmentDTO s) {
            var entity = new ProjectAssignment() {
                    ProjectId = s.ProjectId,
                    EmployeeId  = s.EmployeeId,
                    Notes = s.Notes,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate
            };
            DBContext.ProjectAssignment.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("UpdateProjectAssignment")]
        public async Task<HttpStatusCode> UpdateProjectAssignment(ProjectAssignmentDTO ProjectAssignment) {
            var entity = await DBContext.ProjectAssignment.FirstOrDefaultAsync(s => s.Id == ProjectAssignment.Id);
            entity.ProjectId = ProjectAssignment.ProjectId;
            entity.EmployeeId = ProjectAssignment.EmployeeId;
            entity.Notes = ProjectAssignment.Notes;
            entity.StartDate = ProjectAssignment.StartDate;
            entity.EndDate = ProjectAssignment.EndDate;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        [HttpDelete("DeleteProjectAssignment/{Id}")]
        public async Task < HttpStatusCode > DeleteProjectAssignment(int Id) {
            var entity = new ProjectAssignment() {
                Id = Id
            };
            DBContext.ProjectAssignment.Attach(entity);
            DBContext.ProjectAssignment.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}