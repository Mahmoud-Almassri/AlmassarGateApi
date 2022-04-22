using AlmassarGate.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Domains.DTO
{
   
    public class CheckListAnswerDTO
    {
        public int? AnswerId { get; set; }
        public int ApprovalId { get; set; }
        public ActionType  ActionType { get; set; }
        public int ChecklistQuestionId { get; set; }
        public ChecklistAnswers Answer { get; set; }
    }
}
