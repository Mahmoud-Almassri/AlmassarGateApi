

using AlmassarGate.Domain.Enums;
using AlmassarGate.Domain.Models.Common;

namespace Domains.Models
{
    public partial class Task : BaseModel
    {
        public int TaskEnumId { get; set; }
        public string Title { get; set; }
        public long RoleId { get; set; }
        public string ReadOnlyControls { get; set; }
        public string RequiredControls { get; set; }
        public string NextTaskIds { get; set; }
        public string PrevTaskIds { get; set; }
        public int? OrderId { get; set; }
        public ActionType? TaskType { get; set; }
        public string CheckWithTasks { get; set; }
        public Roles Role { get; set; }
    }
}
