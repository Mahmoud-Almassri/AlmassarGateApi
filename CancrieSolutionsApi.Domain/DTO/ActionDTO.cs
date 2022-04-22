using AlmassarGate.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domains.DTO
{
   
    public class ActionDTO
    {
        public int ApprovalId { get; set; }
        public string Comments { get; set; }
        public string TaskName { get; set; }
        public ActionType ActionType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedById { get; set; }
        public string CreatedBy { get; set; }
    }
}
