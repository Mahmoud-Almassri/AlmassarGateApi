using AlmassarGate.Domain.DTO;
using AlmassarGate.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domains.DTO
{
   
    public class TaskDTO
    {
        public int TaskEnumId { get; set; }
        public string Title { get; set; }
        public long RoleId { get; set; }
        public List<string> ReadOnlyControls { get; set; }
        public List<int> ReadOnlyControlsNumbers { get; set; }
        public List<string> RequiredControls { get; set; }
        public List<int> RequiredControlsNumbers { get; set; }
        public List<string> NextTaskIds { get; set; }
        public List<string> PrevTaskIds { get; set; }
        public int? OrderId { get; set; }
        public ActionType? TaskType { get; set; }
        public List<string> CheckWithTasks { get; set; }
        public List<int> CheckWithTasksNumbers { get; set; }
        public RoleDTO Role { get; set; }

    }
}
