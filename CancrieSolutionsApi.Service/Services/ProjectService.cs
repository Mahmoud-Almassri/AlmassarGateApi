using AlmassarGate.Domain.Enums;
using AlmassarGateApi.Domain.DTO.AddDTO;
using AlmassarGateApi.Domain.Models;
using AutoMapper;
using Domains.DTO;
using Domains.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;
using Service.Interfaces;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Action = Domains.Models.Action;
using Task = Domains.Models.Task;

namespace Service.Services
{
    public class ProjectService : IProjectService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private IMapper _mapper;
        private FileUploader fileUploader;
        public ProjectService(IRepositoryUnitOfWork repositoryUnitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironmen)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _mapper = mapper;
            fileUploader = new FileUploader(webHostEnvironmen);
        }

        public Project Add(Project entity)
        {
            throw new NotImplementedException();
        }
        public ProjectAddDTO AddEntity(ProjectAddDTO entity)
        {
            Project project = new Project
            {
                FinancialProposalFileName = fileUploader.PostFile(entity.FinancialProposalFile)
            };
            Project projectAdded = _repositoryUnitOfWork.Project.Value.Add(project);
            IEnumerable<Task> tasks = _repositoryUnitOfWork.Task.Value.GetAllWithoutFilters();
            foreach (var task in tasks.OrderBy(x => x.OrderId))
            {
                Approval approval = new Approval
                {
                    ProjectId = projectAdded.Id,
                    Status = tasks.Last().Id == task.Id ? BaseStatus.InProgress : BaseStatus.NotStarted,
                    TaskId = task.Id
                };
                Approval approvalAdded = _repositoryUnitOfWork.Approval.Value.Add(approval);
            }
            return entity;
        }
        public bool AddFile(ProjectFilesAddDTO file)
        {
                ProjectFiles projectFile = new ProjectFiles
                {
                    FileCategory = 0,
                    ProjectId = file.ProjectId,
                    Status = BaseStatus.NotStarted,
                    FileName = fileUploader.PostFile(file.File),
                    Name=file.Name
                };
                _repositoryUnitOfWork.ProjectFile.Value.Add(projectFile);

            return true;
        }
        public bool DeleteFile(int fileId)
        {
                ProjectFiles projectFile = _repositoryUnitOfWork.ProjectFile.Value.Get(fileId);
                fileUploader.DeleteFile(projectFile.FileName);
                _repositoryUnitOfWork.ProjectFile.Value.Remove(fileId);
           

            return true;
        }
        public BaseListResponse<ProjectListDTO> GetList(ProjectSearchDTO baseSearch)
        {

            BaseListResponse<Project> projects = _repositoryUnitOfWork.Project.Value.GetList(x =>
                                                       ((string.IsNullOrEmpty(baseSearch.ProjectName) || x.ProjectName.Contains(baseSearch.ProjectName))) &&
                                                       ((string.IsNullOrEmpty(baseSearch.ClientName) || x.ClientName.Contains(baseSearch.ClientName))) &&
                                                       ((!baseSearch.Id.HasValue || x.Id==(int)baseSearch.Id))
                                                       , baseSearch.PageSize
                                                       , baseSearch.PageNumber
                                                       , x => x.CreatedBy, x => x.ModifiedBy);

            List<ProjectListDTO> projectsDTOs = _mapper.Map<List<ProjectListDTO>>(projects.Entities);
            return new BaseListResponse<ProjectListDTO>
            {
                Entities = projectsDTOs,
                TotalCount = projects.TotalCount
            };
        }
        public IEnumerable<Project> AddRange(IEnumerable<Project> entities)
        {
            throw new NotImplementedException();
        }
        public ProjectDTO GetById(int Id)
        {
            Project project = _repositoryUnitOfWork.Project.Value.FirstOrDefault(x => x.Id == Id, x => x.ModifiedBy, x => x.CreatedBy);
            ProjectDTO projectDTO = _mapper.Map<ProjectDTO>(project);
            return projectDTO;
        }

        public Project Get(long Id)
        {
            return _repositoryUnitOfWork.Project.Value.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Project> GetAll()
        {
            throw new NotImplementedException();
        }

        public Project Remove(Project entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> RemoveRange(IEnumerable<Project> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> RemoveRangeByIDs(IEnumerable<long> IDs)
        {
            throw new NotImplementedException();
        }

        public Project Update(Project entity)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateProject(ProjectUpdateDTO entity)
        {
            Project project = Get(entity.Id);
            Approval approval = _repositoryUnitOfWork.Approval.Value.FirstOrDefault(x => x.Id == entity.ApprovalId, x => x.Task);
            ProjectUpdateDTO projectUpdate = UpdateProjectFiles(project, entity);
            ProjectUpdateDTO projectUpdated = await _repositoryUnitOfWork.Project.Value.UpdateProject(projectUpdate,approval.TaskId);
            int[] relatedTasks = Array.ConvertAll(FetchNumbers(approval.Task.CheckWithTasks).ToArray(), s => int.Parse(s));
            int[] nextTasks = Array.ConvertAll(FetchNumbers(approval.Task.NextTaskIds).ToArray(), s => int.Parse(s));
            int[] prevTasks = Array.ConvertAll(FetchNumbers(approval.Task.PrevTaskIds).ToArray(), s => int.Parse(s));

            switch (entity.ActionType)
            {
                case ActionType.Approve:
                    {
                        approval.Status = BaseStatus.Closed;
                        _repositoryUnitOfWork.Approval.Value.Update(approval);
                        if (!_repositoryUnitOfWork.Task.Value.CheckWithTasks(relatedTasks))
                        {
                            await _repositoryUnitOfWork.Task.Value.OpenTasks(nextTasks);
                        }
                        break;
                    }
                case ActionType.Reject:
                    {
                        approval.Status = BaseStatus.Rejected;
                        _repositoryUnitOfWork.Approval.Value.Update(approval);
                        break;
                    }
                case ActionType.ReturnForModification:
                    {
                        if(prevTasks.Count() != 0)
                        {
                            approval.Status = BaseStatus.ReturnedForModification;
                            _repositoryUnitOfWork.Approval.Value.Update(approval);
                            if (!_repositoryUnitOfWork.Task.Value.CheckWithTasks(relatedTasks))
                            {
                                await _repositoryUnitOfWork.Task.Value.OpenTasks(prevTasks);
                            }
                            break;
                        }
                        else
                        {
                            return false;
                        }
                        
                    }
                case ActionType.Submit:
                    {
                        if (nextTasks.Count() != 0)
                        {
                            approval.Status = BaseStatus.Closed;
                            _repositoryUnitOfWork.Approval.Value.Update(approval);
                            if (!_repositoryUnitOfWork.Task.Value.CheckWithTasks(relatedTasks))
                            {
                                await _repositoryUnitOfWork.Task.Value.OpenTasks(nextTasks);
                            }
                            break;
                        }
                        else
                        {
                             return false;
                        }
                    }
                case ActionType.CloseProject:
                    {
                        approval.Status = BaseStatus.Closed;
                        _repositoryUnitOfWork.Approval.Value.Update(approval);
                        break;
                    }
                case ActionType.ChecklistSubmission:
                    {
                        approval.Status = BaseStatus.Closed;
                        _repositoryUnitOfWork.Approval.Value.Update(approval);
                        break;
                    }
            }
            Action action = new Action
            {
                ActionType = entity.ActionType,
                ApprovalId = entity.ApprovalId,
                Comments = entity.Comments,
                Status = BaseStatus.Opened
            };
            Action actionAdded = _repositoryUnitOfWork.Action.Value.Add(action);
            return true;
        }
        public bool SubmitQcForm(SubmitQcFormDTO entity)
        {
            Approval approval = _repositoryUnitOfWork.Approval.Value.FirstOrDefault(x => x.Id == entity.ApprovalId, x => x.Task);
            Project project = Get(approval.ProjectId);
            project.FilledPanels += 1;
            Action action = new Action
            {
                ActionType = entity.ActionType,
                ApprovalId = entity.ApprovalId,
                Comments = entity.Comments,
                Status = BaseStatus.Opened
            };
            Action actionAdded = _repositoryUnitOfWork.Action.Value.Add(action);
            foreach (CheckListAnswerDTO answer in entity.CheckListAnswes)
            {
                if (answer.AnswerId.HasValue)
                {
                    ChecklistAnswer oldAnswer = _repositoryUnitOfWork.CheckListAnswer.Value.Get((int)answer.AnswerId);
                    oldAnswer.Answer = answer.Answer;
                    _repositoryUnitOfWork.CheckListAnswer.Value.Update(oldAnswer);
                }
                else
                {
                    ChecklistAnswer checklistAnswer = new ChecklistAnswer
                    {
                        Answer = answer.Answer,
                        ApprovalId = answer.ApprovalId,
                        ChecklistQuestionId = answer.ChecklistQuestionId,
                        Status = BaseStatus.Opened
                    };
                    _repositoryUnitOfWork.CheckListAnswer.Value.Add(checklistAnswer);
                }

            }
            return true;
        }
        private static string[] FetchNumbers(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Array.Empty<string>();
            }
            else
            {
                return value.Split(',');
            }
        }
        private ProjectUpdateDTO UpdateProjectFiles(Project project, ProjectUpdateDTO projectUpdateDTO)
        {
            if (projectUpdateDTO.FinancialProposalFile != null && projectUpdateDTO.FinancialProposalFile.Length > 0)
            {
                projectUpdateDTO.FinancialProposalFileName = fileUploader.UpdateFile(projectUpdateDTO.FinancialProposalFile, project.FinancialProposalFileName);
            }
            if (projectUpdateDTO.TechnicalProposalFile != null && projectUpdateDTO.TechnicalProposalFile.Length > 0)
            {
                projectUpdateDTO.TechnicalProposalFileName = fileUploader.UpdateFile(projectUpdateDTO.TechnicalProposalFile, project.TechnicalProposalFileName);
            }
            if (projectUpdateDTO.LayoutFile != null && projectUpdateDTO.LayoutFile.Length > 0)
            {
                projectUpdateDTO.LayoutFileName = fileUploader.UpdateFile(projectUpdateDTO.LayoutFile, project.LayoutFileName);
            }
            if (projectUpdateDTO.PaymentTermsFile != null && projectUpdateDTO.PaymentTermsFile.Length > 0)
            {
                projectUpdateDTO.PaymentTermsFileName = fileUploader.UpdateFile(projectUpdateDTO.PaymentTermsFile, project.PaymentTermsFileName);
            }
            if (projectUpdateDTO.SpecsFile != null && projectUpdateDTO.SpecsFile.Length > 0)
            {
                projectUpdateDTO.SpecsFileName = fileUploader.UpdateFile(projectUpdateDTO.SpecsFile, project.SpecsFileName);
            }
            if (projectUpdateDTO.FinancialProposalProofFile != null && projectUpdateDTO.FinancialProposalProofFile.Length > 0)
            {
                projectUpdateDTO.FinancialProposalProof = fileUploader.UpdateFile(projectUpdateDTO.FinancialProposalProofFile, project.FinancialProposalProof);
            }
            if (projectUpdateDTO.TechnicalProposalProofFile != null && projectUpdateDTO.TechnicalProposalProofFile.Length > 0)
            {
                projectUpdateDTO.TechnicalProposalProof = fileUploader.UpdateFile(projectUpdateDTO.TechnicalProposalProofFile, project.TechnicalProposalProof);
            }
            return projectUpdateDTO;
        }
        public IEnumerable<Project> UpdateRange(IEnumerable<Project> entities)
        {
            throw new NotImplementedException();
        }

    }
}
