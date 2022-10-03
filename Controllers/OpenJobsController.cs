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
    public class OpenjobsController : ControllerBase
    {
        private readonly BVContext DBContext;

        public OpenjobsController(BVContext DBContext)
        {
            this.DBContext = DBContext;
        }
        [HttpGet("GetOpenjobs")]
        public async Task<ActionResult<List<OpenjobsDTO>>> Get()
        {
            var List = await DBContext.Openjobs.Select(
                s => new OpenjobsDTO
                {
                    Id = s.Id,
                    JobName = s.JobName,
                    Description = s.Description,
                    StartDate = s.StartDate,
                    Country = s.Country,
                    Status = s.Status,
                    IsActive = s.IsActive
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
        [HttpPost("InsertOpenjobs")]
        public async Task < HttpStatusCode > InsertOpenjobs(OpenjobsDTO s) {
            var entity = new Openjobs() {
                JobName = s.JobName,
                Description = s.Description,
                StartDate = s.StartDate,
                Country = s.Country,
                Status = s.Status,
                IsActive = s.IsActive
            };
            DBContext.Openjobs.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("UpdateOpenjobs")]
        public async Task<HttpStatusCode> UpdateOpenjobs(OpenjobsDTO Openjobs) {
            var entity = await DBContext.Openjobs.FirstOrDefaultAsync(s => s.Id == Openjobs.Id);
            entity.JobName = Openjobs.JobName;
            entity.Description = Openjobs.Description;
            entity.StartDate = Openjobs.StartDate;
            entity.Country = Openjobs.Country;
            entity.Status = Openjobs.Status;
            entity.IsActive = Openjobs.IsActive;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        [HttpDelete("DeleteOpenjobs/{Id}")]
        public async Task < HttpStatusCode > DeleteOpenjobs(int Id) {
            var entity = new Openjobs() {
                Id = Id
            };
            DBContext.Openjobs.Attach(entity);
            DBContext.Openjobs.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}