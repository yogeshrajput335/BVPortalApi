using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BVPortalApi.Models
{
    public class AssetAllocation
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public int AllocatedById { get; set; }
        public int AllocatedToId { get; set; }
        public DateTime AllocatedDate{ get; set; }
        public DateTime ReturnDate { get; set; }
        public string? Status { get; set; }
    }
}