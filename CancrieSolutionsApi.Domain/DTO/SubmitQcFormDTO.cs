using AlmassarGate.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Domains.DTO
{
   
    public class SubmitQcFormDTO
    {
        public int ApprovalId { get; set; }
        public ActionType  ActionType { get; set; }
        public string  Comments { get; set; }
        public List<CheckListAnswerDTO> CheckListAnswes { get; set; }

    }
}
