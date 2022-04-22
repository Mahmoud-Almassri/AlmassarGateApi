using AlmassarGate.Domain.DTO;
using AlmassarGate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Domain.DTO.LookupsDTO
{
    public class CheckListQuestionDTO : BaseModelDTO
    {
        public GroupTitle? GroupTitleId { get; set; }
        public int QuestionEnumId { get; set; }
        public int AnswerId { get; set; }
        public ChecklistAnswers? AnswerValue { get; set; }

        public string QuestionText { get; set; }

        public string QuestionProperties { get; set; }
    }
}
