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
    public class CandidateController : ControllerBase
    {
        private readonly BVContext DBContext;

        public CandidateController(BVContext DBContext)
        {
            this.DBContext = DBContext;
        }
        [HttpGet("GetCandidates")]
        public async Task<ActionResult<List<CandidateDTO>>> Get()
        {
            var List = await DBContext.Candidates.Select(
                s => new CandidateDTO
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    PhoneNo = s.PhoneNo,
                    Email=s.Email,
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
        [HttpPost("InsertCandidate")]
        public async Task < HttpStatusCode > InsertCandidate(CandidateDTO s) {
            var entity = new Candidate() {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    PhoneNo = s.PhoneNo,
                    Email=s.Email,
                    Status = s.Status,
                    IsActive = s.IsActive
            };
            DBContext.Candidates.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("UpdateCandidate")]
        public async Task<HttpStatusCode> UpdateCandidaet(CandidateDTO Candidate) {
            var entity = await DBContext.Candidates.FirstOrDefaultAsync(s => s.Id == Candidate.Id);
            entity.FirstName = Candidate.FirstName;
            entity.LastName = Candidate.LastName;
            entity.PhoneNo = Candidate.PhoneNo;
            entity.Email = Candidate.Email;
            entity.Status = Candidate.Status;
            entity.IsActive = Candidate.IsActive;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        [HttpDelete("DeleteCandidate/{Id}")]
        public async Task < HttpStatusCode > DeleteCandidate(int Id) {
            var entity = new Candidate() {
                Id = Id
            };
            DBContext.Candidates.Attach(entity);
            DBContext.Candidates.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}