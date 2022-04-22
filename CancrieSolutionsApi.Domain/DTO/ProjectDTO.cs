using AlmassarGateApi.Domain.DTO;
using System;
using System.Collections.Generic;

namespace Domains.DTO
{
   
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string SpecsFileName { get; set; }
        public string LayoutFileName { get; set; }
        public string PaymentTermsFileName { get; set; }
        public int? NumberOfPanels { get; set; }
        public string DesignReference { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string ProjectGuid { get; set; }
        public string TechnicalProposalFileName { get; set; }
        public string FinancialProposalFileName { get; set; }
        public int? SubStatus { get; set; }
        public string Comments { get; set; }
        public string TechnicalProposalProof { get; set; }
        public string FinancialProposalProof { get; set; }
        public DateTime? IronPhaseStartDate { get; set; }
        public DateTime? IronPhaseEndDate { get; set; }
        public DateTime? ElectricityPhaseStartDate { get; set; }
        public DateTime? ElectricityPhaseEndDate { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public virtual ICollection<ProjectFilesDTO> ProjectFiles { get; set; }


    }
}
