using AlmassarGate.Domain.Enums;
using AlmassarGate.Domain.Models.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domains.Models
{
    public partial class Action : BaseModel
    {
        public int ApprovalId { get; set; }
        public string Comments { get; set; }
        public ActionType ActionType { get; set; }
        public Approval Approval { get; set; }
    }
}
