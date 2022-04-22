using AlmassarGate.Domain.Models.Common;
using System;
using System.Collections.Generic;

#nullable disable

namespace Domains.Models
{
    public partial class Approval : BaseModel
    {
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public DateTime? ActionDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public Task Task { get; set; }
        public Project Project { get; set; }
    }
}
