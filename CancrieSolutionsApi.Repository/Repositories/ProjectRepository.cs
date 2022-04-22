using AlmassarGate.Domain.Enums;
using AlmassarGate.Domain.Models;
using AlmassarGate.Domain.Models.Common;
using Domains.DTO;
using Domains.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interfaces;
using Repository.Repositories.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private AlmassarGateContext _context;

        public ProjectRepository(AlmassarGateContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProjectUpdateDTO> UpdateProject(ProjectUpdateDTO projectDto,int taskId)
        {
            Project project = await _context.Projects.Where(x => x.Id == projectDto.Id).FirstOrDefaultAsync();
            if (!string.IsNullOrEmpty(projectDto.ClientName))
            {
                project.ClientName = projectDto.ClientName;
            }
            if (!string.IsNullOrEmpty(projectDto.DesignReference))
            {
                project.DesignReference = projectDto.DesignReference;
            }
            if (!string.IsNullOrEmpty(projectDto.ProjectGuid))
            {
                project.ProjectGuid = projectDto.ProjectGuid;
            }
            if (!string.IsNullOrEmpty(projectDto.ProjectName))
            {
                project.ProjectName = projectDto.ProjectName;
            }
            if (!string.IsNullOrEmpty(projectDto.FinancialProposalFileName))
            {
                project.FinancialProposalFileName = projectDto.FinancialProposalFileName;
            }
            if (!string.IsNullOrEmpty(projectDto.TechnicalProposalFileName))
            {
                project.TechnicalProposalFileName = projectDto.TechnicalProposalFileName;
            }
            if (!string.IsNullOrEmpty(projectDto.LayoutFileName))
            {
                project.LayoutFileName = projectDto.LayoutFileName;
            }
            if (!string.IsNullOrEmpty(projectDto.PaymentTermsFileName))
            {
                project.PaymentTermsFileName = projectDto.PaymentTermsFileName;
            }
            if (!string.IsNullOrEmpty(projectDto.SpecsFileName))
            {
                project.SpecsFileName = projectDto.SpecsFileName;
            }
            if (projectDto.NumberOfPanels.HasValue)
            {
                project.NumberOfPanels = projectDto.NumberOfPanels;
                int pastApprovals = _context.Approvals.Where(x => x.ProjectId == projectDto.Id && x.TaskId == taskId).ToList().Count;
                if (pastApprovals < projectDto.NumberOfPanels)
                {
                    List<Approval> approvals = new List<Approval>();
                    for (int p = 0; p < projectDto.NumberOfPanels; p++)
                    {
                        Approval approval = new Approval
                        {
                            TaskId = taskId,
                            ProjectId = projectDto.Id,
                            Status = BaseStatus.Opened,
                        };
                        approvals.Add(approval);

                    }
                    await _context.Approvals.AddRangeAsync(approvals);
                    await _context.SaveChangesAsync();
                }
               
            }
            if (projectDto.SubStatus.HasValue)
            {
                project.SubStatus = projectDto.SubStatus;
            }
            if (projectDto.ProjectStartDate.HasValue)
            {
                project.ProjectStartDate = projectDto.ProjectStartDate;
            }
            if (projectDto.ProjectEndDate.HasValue)
            {
                project.ProjectEndDate = projectDto.ProjectEndDate;
            }
            if (projectDto.ElectricityPhaseStartDate.HasValue)
            {
                project.ElectricityPhaseStartDate = projectDto.ElectricityPhaseStartDate;
            }
            if (projectDto.ElectricityPhaseEndDate.HasValue)
            {
                project.ElectricityPhaseEndDate = projectDto.ElectricityPhaseEndDate;
            }
            if (projectDto.IronPhaseStartDate.HasValue)
            {
                project.IronPhaseStartDate = projectDto.IronPhaseStartDate;
            }
            if (projectDto.IronPhaseEndDate.HasValue)
            {
                project.IronPhaseEndDate = projectDto.IronPhaseEndDate;
            }
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return projectDto;
        }
       
    }
}
