using AlmassarGate.Domain.Enums;
using AlmassarGate.Domain.Models.Common;
using AlmassarGateApi.Domain.Models;
using Domains.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using Action = Domains.Models.Action;

namespace Repository.Context
{

    public partial class AlmassarGateContext : IdentityDbContext<ApplicationUser, Roles, long, UserClaims, UserRoles, UserLogins, RoleClaims, AspNetUserTokens>
    {
        public AlmassarGateContext()
        {
        }

        public AlmassarGateContext(DbContextOptions<AlmassarGateContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ApplicationExceptions> ApplicationExceptions { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<Approval> Approvals { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectFiles> ProjectFiles { get; set; }
        public virtual DbSet<ChecklistQuestion> ChecklistQuestions { get; set; }
        public virtual DbSet<ChecklistAnswer> ChecklistAnswers { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Lookup> Lookups { get; set; }
        AppConfiguration appConfiguration = new AppConfiguration();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(appConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<ApplicationExceptions>(entity =>
            {
                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.LoggedInUser).HasMaxLength(50);
            });

            modelBuilder.Entity<ChecklistAnswer>(entity =>
            {
                entity.ToTable("ChecklistAnswer");
            });

            modelBuilder.Entity<ChecklistQuestion>(entity =>
            {
                entity.ToTable("ChecklistQuestion");
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");


                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });
            modelBuilder.Entity<RoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<UserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId);
            });
            modelBuilder.Entity<Approval>(entity =>
            {
                entity.ToTable("Approval");

                entity.Property(e => e.ActionDate).HasColumnType("datetime");

                entity.Property(e => e.ReceivedDate).HasColumnType("datetime");
            });
            
            modelBuilder.Entity<ProjectFiles>(entity =>
            {
                entity.ToTable("ProjectFiles");

            }); 
            
            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("Actions");

            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ClientName).HasMaxLength(500);

                entity.Property(e => e.DesignReference).HasMaxLength(500);

                entity.Property(e => e.FinancialProposalFileName).HasMaxLength(500);

                entity.Property(e => e.LayoutFileName).HasMaxLength(500);

                entity.Property(e => e.PaymentTermsFileName).HasMaxLength(500);

                entity.Property(e => e.ProjectGuid)
                    .HasMaxLength(50)
                    .HasColumnName("ProjectGUID");

                entity.Property(e => e.ProjectName).HasMaxLength(500);

                entity.Property(e => e.SpecsFileName).HasMaxLength(500);

                entity.Property(e => e.TechnicalProposalFileName).HasMaxLength(500);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500);
            });
            modelBuilder.Entity<ApplicationUser>().HasData(
             new ApplicationUser
             {
                 Id = 1,
                 UserName = "ADMIN",
                 NormalizedUserName = "ADMIN",
                 Email = "Mahmoud-Al-Massri@hotmail.com",
                 NormalizedEmail = "Mahmoud-Al-Massri@hotmail.com",
                 EmailConfirmed = false,
                 PasswordHash = "AQAAAAEAACcQAAAAELr73GmhxCifQepLABo6ilVa+fVkEu+M40P4tfg2C5xiBxeEROKT2xfyxcIoU57roQ==",
                 SecurityStamp = "RCWSSGGSUGXLM4LBICRGPK75IGT77DIY",
                 ConcurrencyStamp = "83532a81-1d3d-434e-93a4-5728210ae2d7",
                 PhoneNumber = "0790809158",
                 PhoneNumberConfirmed = false,
                 TwoFactorEnabled = false,
                 LockoutEnd = null,
                 LockoutEnabled = true,
                 AccessFailedCount = 0,
                 MobileNumber = null,
                 FullName = null,
                 RegId = null,
                 CreatedAt = null,
                 UpdatedAt = null,
                 CreatedBy = null,
                 UpdatedBy = null,
                 IsActive = false
             });

            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 1,
                 Key = "specsFileName",
                 Value = 1,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 2,
                 Key = "layoutFileName",
                 Value = 2,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 3,
                 Key = "paymentTermsFileName",
                 Value = 3,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 4,
                 Key = "numberOfPanels",
                 Value = 4,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 5,
                 Key = "designReference",
                 Value = 5,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 6,
                 Key = "projectName",
                 Value = 6,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 7,
                 Key = "clientName",
                 Value = 7,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 8,
                 Key = "projectGuid",
                 Value = 8,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 9,
                 Key = "technicalProposalFileName",
                 Value = 9,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 10,
                 Key = "financialProposalFileName",
                 Value = 10,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 11,
                 Key = "subStatus",
                 Value = 11,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 12,
                 Key = "technicalProposalProof",
                 Value = 12,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 13,
                 Key = "financialProposalProof",
                 Value = 13,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 14,
                 Key = "ironPhaseStartDate",
                 Value = 14,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 15,
                 Key = "ironPhaseEndDate",
                 Value = 15,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 16,
                 Key = "electricityPhaseStartDate",
                 Value = 16,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 17,
                 Key = "electricityPhaseEndDate",
                 Value = 17,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 18,
                 Key = "projectStartDate",
                 Value = 18,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });
            modelBuilder.Entity<Lookup>().HasData(
             new Lookup
             {
                 Id = 19,
                 Key = "projectEndDate",
                 Value = 19,
                 ParentId = EntitiesEnum.Project,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null
             });

            modelBuilder.Entity<Roles>().HasData(
             new Roles
             {
                 Id = 1,
                 Name = "Admin",
                 NormalizedName = "Admin",
                 ConcurrencyStamp = null
             });
            modelBuilder.Entity<Roles>().HasData(
             new Roles
             {
                 Id = 2,
                 Name = "Client",
                 NormalizedName = "Client",
                 ConcurrencyStamp = null
             });
            modelBuilder.Entity<Roles>().HasData(
             new Roles
             {
                 Id = 3,
                 Name = "Production",
                 NormalizedName = "Production",
                 ConcurrencyStamp = null
             });
            modelBuilder.Entity<Roles>().HasData(
             new Roles
             {
                 Id = 4,
                 Name = "Design",
                 NormalizedName = "Design",
                 ConcurrencyStamp = null
             });
            modelBuilder.Entity<Roles>().HasData(
             new Roles
             {
                 Id = 5,
                 Name = "Repository",
                 NormalizedName = "Repository",
                 ConcurrencyStamp = null
             });
            modelBuilder.Entity<Roles>().HasData(
             new Roles
             {
                 Id = 6,
                 Name = "QC",
                 NormalizedName = "QC",
                 ConcurrencyStamp = null
             });
            modelBuilder.Entity<Roles>().HasData(
             new Roles
             {
                 Id = 7,
                 Name = "QA",
                 NormalizedName = "QA",
                 ConcurrencyStamp = null
             });
            modelBuilder.Entity<Roles>().HasData(
             new Roles
             {
                 Id = 8,
                 Name = "Sales",
                 NormalizedName = "Sales",
                 ConcurrencyStamp = null
             });
            modelBuilder.Entity<Roles>().HasData(
             new Roles
             {
                 Id = 9,
                 Name = "Finance",
                 NormalizedName = "Finance",
                 ConcurrencyStamp = null
             });

            modelBuilder.Entity<UserRoles>().HasData(
             new UserRoles
             {
                 UserId = 1,
                 RoleId = 1
             });

            modelBuilder.Entity<Task>().HasData(
             new Task
             {
                 Id = 1,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null,
                 TaskEnumId = 1,
                 Title = "Financial Proposal",
                 RoleId = 8,
                 ReadOnlyControls = "",
                 RequiredControls = "10",
                 NextTaskIds = "2",
                 PrevTaskIds = "",
                 OrderId = 1,
                 TaskType = ActionType.Submit,
                 CheckWithTasks = null,
             });
             modelBuilder.Entity<Task>().HasData(
             new Task
             {
                 Id = 2,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null,
                 TaskEnumId = 1,
                 Title = "Confirmation from Sales Team for Client Approval",
                 RoleId = 8,
                 ReadOnlyControls = "10",
                 RequiredControls = "13",
                 NextTaskIds = "3",
                 PrevTaskIds = "",
                 OrderId = 2,
                 TaskType = ActionType.Submit,
                 CheckWithTasks = null,
             });
             modelBuilder.Entity<Task>().HasData(
             new Task
             {
                 Id = 3,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null,
                 TaskEnumId = 3,
                 Title = "Technical Proposal",
                 RoleId = 8,
                 ReadOnlyControls = "",
                 RequiredControls = "9",
                 NextTaskIds = "4,5",
                 PrevTaskIds = "",
                 OrderId = 3,
                 TaskType = ActionType.Submit,
                 CheckWithTasks = null,
             });
             modelBuilder.Entity<Task>().HasData(
             new Task
             {
                 Id = 4,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null,
                 TaskEnumId = 4,
                 Title = "Design Approval",
                 RoleId = 4,
                 ReadOnlyControls = "9",
                 RequiredControls = "",
                 NextTaskIds = "6",
                 PrevTaskIds = "3",
                 OrderId = 4,
                 TaskType = ActionType.Approve,
                 CheckWithTasks = "5",
             });
             modelBuilder.Entity<Task>().HasData(
             new Task
             {
                 Id = 5,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null,
                 TaskEnumId = 5,
                 Title = "Production Approval",
                 RoleId = 3,
                 ReadOnlyControls = "9",
                 RequiredControls = "",
                 NextTaskIds = "6",
                 PrevTaskIds = "3",
                 OrderId = 5,
                 TaskType = ActionType.Approve,
                 CheckWithTasks = "4",
             });
             modelBuilder.Entity<Task>().HasData(
             new Task
             {
                 Id = 6,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null,
                 TaskEnumId = 6,
                 Title = "Confirmation from Sales Team for Client Approval",
                 RoleId = 8,
                 ReadOnlyControls = "9",
                 RequiredControls = "",
                 NextTaskIds = "7",
                 PrevTaskIds = "",
                 OrderId = 6,
                 TaskType = ActionType.Submit,
                 CheckWithTasks = null,
             });
             modelBuilder.Entity<Task>().HasData(
             new Task
             {
                 Id = 7,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null,
                 TaskEnumId = 7,
                 Title = "Project Initiation",
                 RoleId = 3,
                 ReadOnlyControls = "",
                 RequiredControls = "1,2,3,4,5,6,7",
                 NextTaskIds = "9",
                 PrevTaskIds = "",
                 OrderId = 7,
                 TaskType = ActionType.Submit,
                 CheckWithTasks = "8",
             });
             modelBuilder.Entity<Task>().HasData(
             new Task
             {
                 Id = 8,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null,
                 TaskEnumId = 8,
                 Title = "Repository",
                 RoleId = 5,
                 ReadOnlyControls = "",
                 RequiredControls = "",
                 NextTaskIds = "7",
                 PrevTaskIds = "",
                 OrderId = 8,
                 TaskType = ActionType.Submit,
                 CheckWithTasks = "7",
             });
             modelBuilder.Entity<Task>().HasData(
             new Task
             {
                 Id = 9,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null,
                 TaskEnumId = 9,
                 Title = "Finance Team Approval",
                 RoleId = 9,
                 ReadOnlyControls = "10",
                 RequiredControls = "",
                 NextTaskIds = "10",
                 PrevTaskIds = "7",
                 OrderId = 9,
                 TaskType = ActionType.Approve,
                 CheckWithTasks = null,
             });
             modelBuilder.Entity<Task>().HasData(
             new Task
             {
                 Id = 10,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null,
                 TaskEnumId = 10,
                 Title = "Production",
                 RoleId = 3,
                 ReadOnlyControls = "",
                 RequiredControls = "11,14,15,16,17,18,19,20",
                 NextTaskIds = "12",
                 PrevTaskIds = "",
                 OrderId = 10,
                 TaskType = ActionType.Submit,
                 CheckWithTasks = "11",
             });
             modelBuilder.Entity<Task>().HasData(
             new Task
             {
                 Id = 11,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null,
                 TaskEnumId = 11,
                 Title = "Repository",
                 RoleId = 5,
                 ReadOnlyControls = "9",
                 RequiredControls = "",
                 NextTaskIds = "12",
                 PrevTaskIds = "",
                 OrderId = 11,
                 TaskType = ActionType.Submit,
                 CheckWithTasks = "10",
             });
             modelBuilder.Entity<Task>().HasData(
             new Task
             {
                 Id = 12,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null,
                 TaskEnumId = 12,
                 Title = "QC",
                 RoleId = 6,
                 ReadOnlyControls = "4",
                 RequiredControls = "",
                 NextTaskIds = "13",
                 PrevTaskIds = "",
                 OrderId = 2,
                 TaskType = ActionType.Submit,
                 CheckWithTasks = null,
             });
             modelBuilder.Entity<Task>().HasData(
             new Task
             {
                 Id = 13,
                 Status = BaseStatus.NotStarted,
                 CreatedDate = null,
                 CreatedById = null,
                 ModifiedDate = null,
                 ModifiedById = null,
                 TaskEnumId = 13,
                 Title = "Finance",
                 RoleId = 9,
                 ReadOnlyControls = "9",
                 RequiredControls = "",
                 NextTaskIds = "",
                 PrevTaskIds = "12",
                 OrderId = 13,
                 TaskType = ActionType.CloseProject,
                 CheckWithTasks = null,
             });

            //modelBuilder.Entity<Project>().HasData(
            // new Project
            // {
            //     SpecsFileName = "9acafb39-96a8-46e6-b61e-fa79d7fd6e19.pdf",
            //     LayoutFileName = "af17dec3-0378-4c59-8e4e-7369123bf080.pdf",
            //     PaymentTermsFileName = "52280559-0b46-46cd-a5bb-542b88219c1f.pdf",
            //     NumberOfPanels = 2,
            //     DesignReference = "Almassar",
            //     ProjectName = "Project 1",
            //     ClientName = "Almassar",
            //     ProjectGuid = "fa10f069-dd7c-48be-a2ea-b65ae2fb9314",
            //     TechnicalProposalFileName = "9acafb39-96a8-46e6-b61e-fa79d7fd6e19.pdf",
            //     FinancialProposalFileName = "35cf5968-9e07-4bf3-b659-658d1d850ce7.pdf",
            //     SubStatus = 1,
            //     Id = 1,
            //     CreatedById = 4,
            //     CreatedDate = DateTime.Now,
            //     ModifiedById = null,
            //     ModifiedDate = null,
            //     Status = BaseStatus.NotStarted,
            //     ProjectInputId = null,
            //     ElectricityPhaseEndDate = null,
            //     ElectricityPhaseStartDate = null,
            //     FinancialProposalProof = null,
            //     IronPhaseEndDate = null,
            //     IronPhaseStartDate = null,
            //     ProjectEndDate = null,
            //     ProjectStartDate = null,
            //     TechnicalProposalProof = null,
            //     FilledPanels = null,
            // });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}