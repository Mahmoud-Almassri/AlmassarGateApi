using AlmassarGate.Domain.Enums;
using Domains.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmassarGate.Domain.Models.Common
{
    public class BaseModel
    {
        public int Id { get; set; }
        public BaseStatus? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedById { get; set; } 
        public ApplicationUser CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifiedById { get; set; }
        public ApplicationUser ModifiedBy { get; set; }
    }
}
