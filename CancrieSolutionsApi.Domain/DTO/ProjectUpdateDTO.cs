using AlmassarGate.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Domains.DTO
{
   
    public class ProjectUpdateDTO
    {
        public int Id { get; set; }
        public int ApprovalId { get; set; }
        public ActionType  ActionType { get; set; }
        public int? NumberOfPanels { get; set; }
        public string DesignReference { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string ProjectGuid { get; set; }
        public int? SubStatus { get; set; }
        public string Comments { get; set; }
        public string LayoutFileName { get; set; }
        public string PaymentTermsFileName { get; set; }
        public string TechnicalProposalFileName { get; set; }
        public string FinancialProposalFileName { get; set; }
        public string SpecsFileName { get; set; }
        public string TechnicalProposalProof { get; set; }
        public string FinancialProposalProof { get; set; }
        public IFormFile SpecsFile { get; set; }
        public IFormFile LayoutFile { get; set; }
        public IFormFile PaymentTermsFile { get; set; }
        public IFormFile TechnicalProposalFile { get; set; }
        public IFormFile FinancialProposalFile { get; set; }
        public IFormFile TechnicalProposalProofFile { get; set; }
        public IFormFile FinancialProposalProofFile { get; set; }

        public DateTime? IronPhaseStartDate { get; set; }
        public DateTime? IronPhaseEndDate { get; set; }
        public DateTime? ElectricityPhaseStartDate { get; set; }
        public DateTime? ElectricityPhaseEndDate { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }

    }
}
