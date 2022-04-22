using AlmassarGate.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domains.DTO
{
   
    public class ApprovalDTO
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public BaseStatus Status { get; set; }
        public DateTime? ActionDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public TaskDTO Task { get; set; }
        public ProjectDTO Project { get; set; }

    }
}
