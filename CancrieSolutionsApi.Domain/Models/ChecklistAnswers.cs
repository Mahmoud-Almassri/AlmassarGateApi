using AlmassarGate.Domain.Enums;
using AlmassarGate.Domain.Models.Common;

namespace Domains.Models
{
    public class ChecklistAnswer : BaseModel
    {
        public int ApprovalId { get; set; }
        public int ChecklistQuestionId { get; set; }
        public ChecklistAnswers Answer { get; set; }
        public Approval Approval { get; set; }
        public ChecklistQuestion ChecklistQuestion { get; set; }
    }
}
