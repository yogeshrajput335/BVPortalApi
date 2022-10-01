using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BVPortalApi.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TypeId { get; set; }
        public string? ModelNumber { get; set; }
        public string? Status { get; set; }
        public bool IsActive { get; set; }
    }
}