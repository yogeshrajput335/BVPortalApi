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
    public class UserController : ControllerBase
    {
        private readonly BVContext DBContext;
        private readonly IEmailService emailService;

        public UserController(BVContext DBContext,IEmailService emailService)
        {
            this.DBContext = DBContext;
            this.emailService = emailService;
        }
        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var List = await DBContext.Users.Select(
                s => new UserDTO
                {
                    Id = s.Id,
                    Username = s.Username,
                    Password = s.Password,
                    Email = s.Email,
                    IsActive = s.IsActive
                }
            ).ToListAsync();

            emailService.Send();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }
        [HttpPost("InsertUser")]
        public async Task < HttpStatusCode > InsertUser(UserDTO User) {
            var entity = new User() {
                Username = User.Username,
                Password = User.Password,
                Email = User.Email,
                IsActive = User.IsActive
            };
            DBContext.Users.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpPut("UpdateUser")]
        public async Task<HttpStatusCode> UpdateUser(UserDTO User) {
            var entity = await DBContext.Users.FirstOrDefaultAsync(s => s.Id == User.Id);
            entity.Username = User.Username;
            entity.Password = User.Password;
            entity.Email = User.Email;
            entity.IsActive = User.IsActive;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        [HttpDelete("DeleteUser/{Id}")]
        public async Task < HttpStatusCode > DeleteUser(int Id) {
            var entity = new User() {
                Id = Id
            };
            DBContext.Users.Attach(entity);
            DBContext.Users.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}