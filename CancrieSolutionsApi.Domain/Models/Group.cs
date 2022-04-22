

using AlmassarGate.Domain.Models.Common;

namespace Domains.Models
{
    public partial class Group : BaseModel
    {
        public long RoleId { get; set; }
        public string GroupName { get; set; }
        public Roles Role { get; set; }
    }
}
