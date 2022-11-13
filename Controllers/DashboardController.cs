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
    public class DashboardController : ControllerBase
    {
        private readonly BVContext DBContext;

        public DashboardController(BVContext DBContext)
        {
            this.DBContext = DBContext;
        }
        [HttpGet("GetPieData")]
        public async Task<ActionResult<List<List<string>>>> GetPieData()
        {
            List<List<string>> myList = new List<List<string>>();
            myList.Add(new List<string> { "Task", "Hours per Day" });
            myList.Add(new List<string> { "Work", "11"});
            myList.Add(new List<string> { "Eat", "3"});
            return myList;
        }

        // [
    //   ['Task', 'Hours per Day'],
    //   ['Work',     11],
    //   ['Eat',      2],
    //   ['Commute',  2],
    //   ['Watch TV', 2],
    //   ['Sleep',    7]
    // ],
        // [HttpPost("InsertAssetAllocation")]
        // public async Task < HttpStatusCode > InsertAssetAllocation(AssetAllocationDTO s) {
        //     var entity = new AssetAllocation() {
        //             AssetId = s.AssetId,
        //             AllocatedById = s.AllocatedById,
        //             AllocatedToId = s.AllocatedToId,
        //             AllocatedDate = s.AllocatedDate,
        //             ReturnDate=s.ReturnDate,
        //             Status = s.Status
        //     };
        //     DBContext.AssetAllocation.Add(entity);
        //     await DBContext.SaveChangesAsync();
        //     return HttpStatusCode.Created;
        // }
        // [HttpPut("UpdateAssetAllocation")]
        // public async Task<HttpStatusCode> UpdateAssetAllocation(AssetAllocationDTO AssetAllocation) {
        //     var entity = await DBContext.AssetAllocation.FirstOrDefaultAsync(s => s.Id == AssetAllocation.Id);
        //     entity.AssetId  = AssetAllocation.AssetId ;
        //     entity.AllocatedById = AssetAllocation.AllocatedById;
        //     entity.AllocatedToId = AssetAllocation.AllocatedToId;
        //     entity.AllocatedDate = AssetAllocation.AllocatedDate;
        //     entity.ReturnDate = AssetAllocation.ReturnDate;
        //     entity.Status = AssetAllocation.Status;
        //     await DBContext.SaveChangesAsync();
        //     return HttpStatusCode.OK;
        // }
        // [HttpDelete("DeleteAssetAllocation/{Id}")]
        // public async Task < HttpStatusCode > DeleteAssetAllocation(int Id) {
        //     var entity = new AssetAllocation() {
        //         Id = Id
        //     };
        //     DBContext.AssetAllocation.Attach(entity);
        //     DBContext.AssetAllocation.Remove(entity);
        //     await DBContext.SaveChangesAsync();
        //     return HttpStatusCode.OK;
        // }
    }
}