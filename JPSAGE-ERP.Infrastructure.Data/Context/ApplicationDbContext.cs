using JPSAGE_ERP.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JPSAGE_ERP.Domain
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AggregatedCounter> AggregatedCounter { get; set; }
        //public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        //public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

        public virtual DbSet<BackgroundExecutor> BackgroundExecutor { get; set; }
        public virtual DbSet<BackgroundExecutorTrack> BackgroundExecutorTrack { get; set; }
        public virtual DbSet<BackgroundExecutorTrackingHistory> BackgroundExecutorTrackingHistory { get; set; }
        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<Hash> Hash { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobParameter> JobParameter { get; set; }
        public virtual DbSet<JobQueue> JobQueue { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<Schema> Schema { get; set; }
        public virtual DbSet<Server> Server { get; set; }
        public virtual DbSet<Set> Set { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<TblActivityLog> TblActivityLog { get; set; }
        public virtual DbSet<TblApproval> TblApproval { get; set; }
        public virtual DbSet<TblAuthApprover> TblAuthApprover { get; set; }
        public virtual DbSet<TblAuthChecker> TblAuthChecker { get; set; }
        public virtual DbSet<TblAuthList> TblAuthList { get; set; }
        public virtual DbSet<TblBusinessExperience> TblBusinessExperience { get; set; }
        public virtual DbSet<TblCategorySpecialization> TblCategorySpecialization { get; set; }
        public virtual DbSet<TblCertifyingOrg> TblCertifyingOrg { get; set; }
        public virtual DbSet<TblCity> TblCity { get; set; }
        public virtual DbSet<TblClients> TblClients { get; set; }
        public virtual DbSet<TblCodeGenerator> TblCodeGenerator { get; set; }
        public virtual DbSet<TblCompanyInfo> TblCompanyInfo { get; set; }
        public virtual DbSet<TblCompanySubContractors> TblCompanySubContractors { get; set; }
        public virtual DbSet<TblContactPersons> TblContactPersons { get; set; }
        public virtual DbSet<TblCorpSocialResponsibility> TblCorpSocialResponsibility { get; set; }
        public virtual DbSet<TblCorporateDistinctives> TblCorporateDistinctives { get; set; }
        public virtual DbSet<TblCountry> TblCountry { get; set; }
        public virtual DbSet<TblCurrency> TblCurrency { get; set; }
        public virtual DbSet<TblCyMfgFf> TblCyMfgFf { get; set; }
        public virtual DbSet<TblDatabaseObjects> TblDatabaseObjects { get; set; }
        public virtual DbSet<TblDepartments> TblDepartments { get; set; }
        public virtual DbSet<TblDirectServiceScope> TblDirectServiceScope { get; set; }
        public virtual DbSet<TblDocumentType> TblDocumentType { get; set; }
        public virtual DbSet<TblDprcategory> TblDprcategory { get; set; }
        public virtual DbSet<TblEndUserRequisitionProducts> TblEndUserRequisitionProducts { get; set; }
        public virtual DbSet<TblEndUserRequisitionProductsDeliveryInfo> TblEndUserRequisitionProductsDeliveryInfo { get; set; }
        public virtual DbSet<TblEndUserRequisitionProductsDetails> TblEndUserRequisitionProductsDetails { get; set; }
        public virtual DbSet<TblEndUserRequisitionProductsMto> TblEndUserRequisitionProductsMto { get; set; }
        public virtual DbSet<TblEndUserRequisitionProductsOtherInfo> TblEndUserRequisitionProductsOtherInfo { get; set; }
        public virtual DbSet<TblEndUserRequisitionServices> TblEndUserRequisitionServices { get; set; }
        public virtual DbSet<TblEndUserRequisitionServicesMto> TblEndUserRequisitionServicesMto { get; set; }
        public virtual DbSet<TblEventDetails> TblEventDetails { get; set; }
        public virtual DbSet<TblEventOtherInfo> TblEventOtherInfo { get; set; }
        public virtual DbSet<TblEvents> TblEvents { get; set; }
        public virtual DbSet<TblFinancialStatements> TblFinancialStatements { get; set; }
        public virtual DbSet<TblForeignCompany> TblForeignCompany { get; set; }
        public virtual DbSet<TblFormIdentification> TblFormIdentification { get; set; }
        public virtual DbSet<TblHealthSafetyEnvironment> TblHealthSafetyEnvironment { get; set; }
        public virtual DbSet<TblHseCertification> TblHseCertification { get; set; }
        public virtual DbSet<TblInvoice> TblInvoice { get; set; }
        public virtual DbSet<TblInvoiceDetails> TblInvoiceDetails { get; set; }
        public virtual DbSet<TblInvoiceOtherInfo> TblInvoiceOtherInfo { get; set; }
        public virtual DbSet<TblJobCompletionCertificate> TblJobCompletionCertificate { get; set; }
        public virtual DbSet<TblJustificationofAward> TblJustificationofAward { get; set; }
        public virtual DbSet<TblLog> TblLog { get; set; }
        public virtual DbSet<TblMainCustomers> TblMainCustomers { get; set; }
        public virtual DbSet<TblManufacturers> TblManufacturers { get; set; }
        public virtual DbSet<TblMaterials> TblMaterials { get; set; }
        public virtual DbSet<TblMtoformDetails> TblMtoformDetails { get; set; }
        public virtual DbSet<TblMtoforms> TblMtoforms { get; set; }
        public virtual DbSet<TblNotificationGroup> TblNotificationGroup { get; set; }
        public virtual DbSet<TblNumberOfEmployees> TblNumberOfEmployees { get; set; }
        public virtual DbSet<TblOfficeServiceCl> TblOfficeServiceCl { get; set; }
        public virtual DbSet<TblPaymentBank> TblPaymentBank { get; set; }
        public virtual DbSet<TblPaymentRequestDetails> TblPaymentRequestDetails { get; set; }
        public virtual DbSet<TblPaymentRequestMaster> TblPaymentRequestMaster { get; set; }
        public virtual DbSet<TblPosition> TblPosition { get; set; }
        public virtual DbSet<TblProductCategory> TblProductCategory { get; set; }
        public virtual DbSet<TblProductEquipmentService> TblProductEquipmentService { get; set; }
        public virtual DbSet<TblProductServiceCategory> TblProductServiceCategory { get; set; }
        public virtual DbSet<TblProducts> TblProducts { get; set; }
        public virtual DbSet<TblProjects> TblProjects { get; set; }
        public virtual DbSet<TblPurchaseOrder> TblPurchaseOrder { get; set; }
        public virtual DbSet<TblPurchaseOrderDetails> TblPurchaseOrderDetails { get; set; }
        public virtual DbSet<TblPurchaseOrderMilestones> TblPurchaseOrderMilestones { get; set; }
        public virtual DbSet<TblQualityCertification> TblQualityCertification { get; set; }
        public virtual DbSet<TblQualityManagement> TblQualityManagement { get; set; }
        public virtual DbSet<TblQuotationApproval> TblQuotationApproval { get; set; }
        public virtual DbSet<TblQuotationDeliveryInfo> TblQuotationDeliveryInfo { get; set; }
        public virtual DbSet<TblQuotationDetails> TblQuotationDetails { get; set; }
        public virtual DbSet<TblQuotationMaster> TblQuotationMaster { get; set; }
        public virtual DbSet<TblQuotationOtherInfo> TblQuotationOtherInfo { get; set; }
        public virtual DbSet<TblQuotationOtherInfoAttachments> TblQuotationOtherInfoAttachments { get; set; }
        public virtual DbSet<TblServices> TblServices { get; set; }
        public virtual DbSet<TblServicesCategory> TblServicesCategory { get; set; }
        public virtual DbSet<TblSingleTenderJustification> TblSingleTenderJustification { get; set; }
        public virtual DbSet<TblSpDirectServiceScope> TblSpDirectServiceScope { get; set; }
        public virtual DbSet<TblSrconstructionTechnicalQueries> TblSrconstructionTechnicalQueries { get; set; }
        public virtual DbSet<TblSrconstructionTechnicalQueriesTemp> TblSrconstructionTechnicalQueriesTemp { get; set; }
        public virtual DbSet<TblSrconstructionTechnicalQueryAttachments> TblSrconstructionTechnicalQueryAttachments { get; set; }
        public virtual DbSet<TblSrconstructionTechnicalQueryAttachmentsTemp> TblSrconstructionTechnicalQueryAttachmentsTemp { get; set; }
        public virtual DbSet<TblSrconstructionTechnicalQueryReplies> TblSrconstructionTechnicalQueryReplies { get; set; }
        public virtual DbSet<TblSrconstructionTechnicalQueryRepliesTemp> TblSrconstructionTechnicalQueryRepliesTemp { get; set; }
        public virtual DbSet<TblSrdailyReportFileAttachments> TblSrdailyReportFileAttachments { get; set; }
        public virtual DbSet<TblSrdailyReportFileAttachmentsTemp> TblSrdailyReportFileAttachmentsTemp { get; set; }
        public virtual DbSet<TblSrdailyReportHse> TblSrdailyReportHse { get; set; }
        public virtual DbSet<TblSrdailyReportHsetemp> TblSrdailyReportHsetemp { get; set; }
        public virtual DbSet<TblSrdailyReportProgressMeasurement> TblSrdailyReportProgressMeasurement { get; set; }
        public virtual DbSet<TblSrdailyReportProgressMeasurementTemp> TblSrdailyReportProgressMeasurementTemp { get; set; }
        public virtual DbSet<TblSrdailyReporting> TblSrdailyReporting { get; set; }
        public virtual DbSet<TblSrdailyReportingDelays> TblSrdailyReportingDelays { get; set; }
        public virtual DbSet<TblSrdailyReportingDelaysTemp> TblSrdailyReportingDelaysTemp { get; set; }
        public virtual DbSet<TblSrdailyReportingIssues> TblSrdailyReportingIssues { get; set; }
        public virtual DbSet<TblSrdailyReportingIssuesTemp> TblSrdailyReportingIssuesTemp { get; set; }
        public virtual DbSet<TblSrdailyReportingTemp> TblSrdailyReportingTemp { get; set; }
        public virtual DbSet<TblSrfileAttachments> TblSrfileAttachments { get; set; }
        public virtual DbSet<TblSrnonConformanceReports> TblSrnonConformanceReports { get; set; }
        public virtual DbSet<TblStaffBioData> TblStaffBioData { get; set; }
        public virtual DbSet<TblStaffRoles> TblStaffRoles { get; set; }
        public virtual DbSet<TblStaffStrengthComp> TblStaffStrengthComp { get; set; }
        public virtual DbSet<TblState> TblState { get; set; }
        public virtual DbSet<TblSubCategory> TblSubCategory { get; set; }
        public virtual DbSet<TblSubContractedDetails> TblSubContractedDetails { get; set; }
        public virtual DbSet<TblSubContractedServices> TblSubContractedServices { get; set; }
        public virtual DbSet<TblSubsidiaryCompany> TblSubsidiaryCompany { get; set; }
        public virtual DbSet<TblSupplierIdentification> TblSupplierIdentification { get; set; }
        public virtual DbSet<TblSupplierOwnership> TblSupplierOwnership { get; set; }
        public virtual DbSet<TblSupplierProfile> TblSupplierProfile { get; set; }
        public virtual DbSet<TblTenderAttachements> TblTenderAttachements { get; set; }
        public virtual DbSet<TblThirdPartyReference> TblThirdPartyReference { get; set; }
        public virtual DbSet<TblTypicalSubcontractedScope> TblTypicalSubcontractedScope { get; set; }
        public virtual DbSet<TblValueDetails> TblValueDetails { get; set; }
        public virtual DbSet<TblVendorProjectConsortium> TblVendorProjectConsortium { get; set; }
        public virtual DbSet<TblVendorRegFormApproval> TblVendorRegFormApproval { get; set; }
        public virtual DbSet<TblWorkflowProcessDef> TblWorkflowProcessDef { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Checker", NormalizedName = "CHECKER" },
                new { Id = "3", Name = "Authorizer", NormalizedName = "AUTHORIZER" },
                new { Id = "4", Name = "Staff", NormalizedName = "STAFF" },
                new { Id = "5", Name = "VendorAdmin", NormalizedName = "VENDORADMIN" },
                new { Id = "6", Name = "Vendor", NormalizedName = "VENDOR" }
                );

            modelBuilder.Entity<AggregatedCounter>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK_HangFire_CounterAggregated");

                entity.ToTable("AggregatedCounter", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_AggregatedCounter_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<BackgroundExecutor>(entity =>
            {
                entity.ToTable("Background_executor");

                entity.HasIndex(e => e.BackgroundSp)
                    .HasName("UK_Background_executor")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BackgroundSp)
                    .IsRequired()
                    .HasColumnName("background_sp")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RunRank).HasColumnName("run_rank");
            });

            modelBuilder.Entity<BackgroundExecutorTrack>(entity =>
            {
                entity.ToTable("Background_executor_track");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProcName)
                    .IsRequired()
                    .HasColumnName("procName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RunError)
                    .HasColumnName("run_error")
                    .IsUnicode(false);

                entity.Property(e => e.RunTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<BackgroundExecutorTrackingHistory>(entity =>
            {
                entity.ToTable("Background_executor_tracking_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BatchId)
                    .IsRequired()
                    .HasColumnName("batch_id")
                    .HasMaxLength(100);

                entity.Property(e => e.ProcName)
                    .IsRequired()
                    .HasColumnName("proc_name")
                    .HasMaxLength(100);

                entity.Property(e => e.TTime)
                    .HasColumnName("t_time")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TimeEnd)
                    .HasColumnName("time_end")
                    .HasColumnType("datetime");

                entity.Property(e => e.TimeStart)
                    .HasColumnName("time_start")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransactionDate)
                    .HasColumnName("transaction_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Counter", "HangFire");

                entity.HasIndex(e => e.Key)
                    .HasName("CX_HangFire_Counter");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Hash>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Field })
                    .HasName("PK_HangFire_Hash");

                entity.ToTable("Hash", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_Hash_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Field).HasMaxLength(100);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job", "HangFire");

                entity.HasIndex(e => e.StateName)
                    .HasName("IX_HangFire_Job_StateName")
                    .HasFilter("([StateName] IS NOT NULL)");

                entity.HasIndex(e => new { e.StateName, e.ExpireAt })
                    .HasName("IX_HangFire_Job_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Arguments).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.InvocationData).IsRequired();

                entity.Property(e => e.StateName).HasMaxLength(20);
            });

            modelBuilder.Entity<JobParameter>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Name })
                    .HasName("PK_HangFire_JobParameter");

                entity.ToTable("JobParameter", "HangFire");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobParameter)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_JobParameter_Job");
            });

            modelBuilder.Entity<JobQueue>(entity =>
            {
                entity.HasKey(e => new { e.Queue, e.Id })
                    .HasName("PK_HangFire_JobQueue");

                entity.ToTable("JobQueue", "HangFire");

                entity.Property(e => e.Queue).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FetchedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Id })
                    .HasName("PK_HangFire_List");

                entity.ToTable("List", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_List_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Schema>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PK_HangFire_Schema");

                entity.ToTable("Schema", "HangFire");

                entity.Property(e => e.Version).ValueGeneratedNever();
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.ToTable("Server", "HangFire");

                entity.HasIndex(e => e.LastHeartbeat)
                    .HasName("IX_HangFire_Server_LastHeartbeat");

                entity.Property(e => e.Id).HasMaxLength(200);

                entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Value })
                    .HasName("PK_HangFire_Set");

                entity.ToTable("Set", "HangFire");

                entity.HasIndex(e => e.ExpireAt)
                    .HasName("IX_HangFire_Set_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.HasIndex(e => new { e.Key, e.Score })
                    .HasName("IX_HangFire_Set_Score");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(256);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Id })
                    .HasName("PK_HangFire_State");

                entity.ToTable("State", "HangFire");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_State_Job");
            });

            modelBuilder.Entity<TblActivityLog>(entity =>
            {
                entity.HasKey(e => e.ActivityLogId);

                entity.ToTable("tbl_ActivityLog");

                entity.Property(e => e.ActivityLogId).HasColumnName("ActivityLogID");

                entity.Property(e => e.ApprovedBy).HasMaxLength(200);

                entity.Property(e => e.CheckedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.InitiatedBy).HasMaxLength(200);

                entity.Property(e => e.ProcessName).HasMaxLength(200);
            });

            modelBuilder.Entity<TblApproval>(entity =>
            {
                entity.HasKey(e => e.ApprovalId);

                entity.ToTable("tbl_Approval");

                entity.Property(e => e.ApprovalId).HasColumnName("ApprovalID");

                entity.Property(e => e.ApprovalDate)
                    .HasColumnName("Approval_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Signature)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblApproval)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Approval_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblAuthApprover>(entity =>
            {
                entity.HasKey(e => e.AuthAppId);

                entity.ToTable("tbl_AuthApprover");

                entity.Property(e => e.AuthAppId).HasColumnName("AuthAppID");

                entity.Property(e => e.AuthId).HasColumnName("AuthID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Reason).HasMaxLength(1000);

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.HasOne(d => d.Auth)
                    .WithMany(p => p.TblAuthApprover)
                    .HasForeignKey(d => d.AuthId)
                    .HasConstraintName("FK_tbl_AuthApprover_tbl_AuthList");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.TblAuthApprover)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_tbl_AuthApprover_tbl_StaffBioData");
            });

            modelBuilder.Entity<TblAuthChecker>(entity =>
            {
                entity.HasKey(e => e.AuthChId);

                entity.ToTable("tbl_AuthChecker");

                entity.Property(e => e.AuthChId).HasColumnName("AuthChID");

                entity.Property(e => e.AuthId).HasColumnName("AuthID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Reason).HasMaxLength(1000);

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.HasOne(d => d.Auth)
                    .WithMany(p => p.TblAuthChecker)
                    .HasForeignKey(d => d.AuthId)
                    .HasConstraintName("FK_tbl_AuthChecker_tbl_AuthList");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.TblAuthChecker)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_tbl_AuthChecker_tbl_StaffBioData");
            });

            modelBuilder.Entity<TblAuthList>(entity =>
            {
                entity.HasKey(e => e.AuthId);

                entity.ToTable("tbl_AuthList");

                entity.Property(e => e.AuthId).HasColumnName("AuthID");

                entity.Property(e => e.ApproverStatusReason).HasMaxLength(1000);

                entity.Property(e => e.BatchId)
                    .IsRequired()
                    .HasColumnName("BatchID")
                    .HasMaxLength(100);

                entity.Property(e => e.CheckerStatusReason).HasMaxLength(1000);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.StatusReason).HasMaxLength(1000);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblBusinessExperience>(entity =>
            {
                entity.HasKey(e => e.BizExId);

                entity.ToTable("tbl_BusinessExperience");

                entity.Property(e => e.BizExId).HasColumnName("BizExID");

                entity.Property(e => e.CompanyWorkedWith).HasMaxLength(100);

                entity.Property(e => e.ContinuityPolicy).HasMaxLength(100);

                entity.Property(e => e.HasContinuityPolicy).HasMaxLength(10);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.ScopeCovered).HasMaxLength(500);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.TimeFrame).HasMaxLength(10);

                entity.Property(e => e.TransactionReference).HasMaxLength(100);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblBusinessExperience)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_BusinessExperience_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblCategorySpecialization>(entity =>
            {
                entity.HasKey(e => e.CatSpecId);

                entity.ToTable("tbl_CategorySpecialization");

                entity.Property(e => e.CatSpecId).HasColumnName("CatSpecID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProdServId).HasColumnName("ProdServID");

                entity.HasOne(d => d.ProdServ)
                    .WithMany(p => p.TblCategorySpecialization)
                    .HasForeignKey(d => d.ProdServId)
                    .HasConstraintName("FK_tbl_CategorySpecialization_tbl_ProductServiceCategory");
            });

            modelBuilder.Entity<TblCertifyingOrg>(entity =>
            {
                entity.HasKey(e => e.CertOrgId);

                entity.ToTable("tbl_CertifyingOrg");

                entity.Property(e => e.CertOrgId).HasColumnName("CertOrgID");

                entity.Property(e => e.CertOrgName).HasMaxLength(500);
            });

            modelBuilder.Entity<TblCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("tbl_City");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblClients>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.ToTable("tbl_Clients");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.ClientCode).HasMaxLength(10);

                entity.Property(e => e.ClientLogo).HasColumnType("image");

                entity.Property(e => e.ClientName).HasMaxLength(200);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EmailAddress).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber1).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber2).HasMaxLength(50);

                entity.Property(e => e.WebSiteUrl)
                    .HasColumnName("WebSiteURL")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TblClients)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_tbl_Clients_tbl_CompanyInfo");
            });

            modelBuilder.Entity<TblCodeGenerator>(entity =>
            {
                entity.HasKey(e => e.CodeGenId);

                entity.ToTable("tbl_CodeGenerator");

                entity.Property(e => e.CodeGenId).HasColumnName("CodeGenID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GeneratedCode).HasMaxLength(100);
            });

            modelBuilder.Entity<TblCompanyInfo>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.ToTable("tbl_CompanyInfo");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.CompanyCode).HasMaxLength(10);

                entity.Property(e => e.CompanyLogo).HasColumnType("image");

                entity.Property(e => e.CompanyName).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EmailAddress).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber1).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber2).HasMaxLength(50);

                entity.Property(e => e.WebsiteUrl)
                    .HasColumnName("WebsiteURL")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblCompanySubContractors>(entity =>
            {
                entity.HasKey(e => e.ComSubConId);

                entity.ToTable("tbl_CompanySubContractors");

                entity.Property(e => e.ComSubConId).HasColumnName("ComSubConID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SubContractorAddress).HasMaxLength(500);

                entity.Property(e => e.SubContractorName).HasMaxLength(200);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TblCompanySubContractors)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_tbl_CompanySubContractors_tbl_CompanyInfo");
            });

            modelBuilder.Entity<TblContactPersons>(entity =>
            {
                entity.HasKey(e => e.ContactPersonId);

                entity.ToTable("tbl_ContactPersons");

                entity.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");

                entity.Property(e => e.ContactPersonName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WorkPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.TblContactPersons)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_tbl_ContactPersons_tbl_FormIdentification");
            });

            modelBuilder.Entity<TblCorpSocialResponsibility>(entity =>
            {
                entity.HasKey(e => e.CsrId);

                entity.ToTable("tbl_CorpSocialResponsibility");

                entity.Property(e => e.CsrId).HasColumnName("CSR_ID");

                entity.Property(e => e.FraudMalpracticePolicy).HasMaxLength(100);

                entity.Property(e => e.SrethHumanLaborLaws)
                    .HasColumnName("SREthHumanLaborLaws")
                    .HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.ThirdPartySocAudit).HasMaxLength(100);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblCorpSocialResponsibility)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_CorpSocialResponsibility_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblCorporateDistinctives>(entity =>
            {
                entity.HasKey(e => e.CorpDisId);

                entity.ToTable("tbl_CorporateDistinctives");

                entity.Property(e => e.CorpDisId).HasColumnName("CorpDisID");

                entity.Property(e => e.Details).IsRequired();

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblCorporateDistinctives)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_CorporateDistinctives_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("tbl_Country");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblCurrency>(entity =>
            {
                entity.HasKey(e => e.CurrencyId);

                entity.ToTable("tbl_Currency");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.CurrencyCode).HasMaxLength(5);

                entity.Property(e => e.CurrencyName).HasMaxLength(50);

                entity.Property(e => e.CurrencySymbol).HasMaxLength(5);
            });

            modelBuilder.Entity<TblCyMfgFf>(entity =>
            {
                entity.HasKey(e => e.CyMfgFfId);

                entity.ToTable("tbl_CY_MFG_FF");

                entity.Property(e => e.CyMfgFfId).HasColumnName("CY_MFG_FF_ID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.FactoryArea).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.PlantsEquipmentType).HasMaxLength(500);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Utilization).HasMaxLength(500);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblCyMfgFf)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_tbl_CY_MFG_FF_tbl_City");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblCyMfgFf)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_CY_MFG_FF_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblDatabaseObjects>(entity =>
            {
                entity.HasKey(e => e.DbobjId);

                entity.ToTable("tbl_DatabaseObjects");

                entity.Property(e => e.DbobjId).HasColumnName("DBObjID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Parameters).HasMaxLength(500);
            });

            modelBuilder.Entity<TblDepartments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("tbl_Departments");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentCode).HasMaxLength(10);

                entity.Property(e => e.DepartmentEmailAddress).HasMaxLength(100);

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TblDepartments)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_tbl_Departments_tbl_CompanyInfo");
            });

            modelBuilder.Entity<TblDirectServiceScope>(entity =>
            {
                entity.HasKey(e => e.ServiceScopeId);

                entity.ToTable("tbl_DirectServiceScope");

                entity.Property(e => e.ServiceScopeId).HasColumnName("ServiceScopeID");

                entity.Property(e => e.MaterialsName).HasMaxLength(500);

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TblDirectServiceScope)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK_tbl_DirectServiceScope_tbl_SubCategory");
            });

            modelBuilder.Entity<TblDocumentType>(entity =>
            {
                entity.HasKey(e => e.DocTypeId);

                entity.ToTable("tbl_DocumentType");

                entity.Property(e => e.DocTypeId).HasColumnName("DocTypeID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocTypeDescription).HasMaxLength(500);

                entity.Property(e => e.DocTypeName).HasMaxLength(20);
            });

            modelBuilder.Entity<TblDprcategory>(entity =>
            {
                entity.HasKey(e => e.DprcatId);

                entity.ToTable("tbl_DPRCategory");

                entity.Property(e => e.DprcatId).HasColumnName("DPRCatID");

                entity.Property(e => e.CatSpecId).HasColumnName("CatSpecID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DprcatCode)
                    .HasColumnName("DPRCatCode")
                    .HasMaxLength(10);

                entity.Property(e => e.DprcatName)
                    .HasColumnName("DPRCatName")
                    .HasMaxLength(100);

                entity.HasOne(d => d.CatSpec)
                    .WithMany(p => p.TblDprcategory)
                    .HasForeignKey(d => d.CatSpecId)
                    .HasConstraintName("FK_tbl_DPRCategory_tbl_CategorySpecialization");
            });

            modelBuilder.Entity<TblEndUserRequisitionProducts>(entity =>
            {
                entity.HasKey(e => e.Eurpid);

                entity.ToTable("tbl_EndUserRequisitionProducts");

                entity.Property(e => e.Eurpid).HasColumnName("EURPID");

                entity.Property(e => e.BudgetEstimate).HasColumnType("money");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.RequestTitle).HasMaxLength(200);

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.TechnicalScore).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TblEndUserRequisitionProducts)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_tbl_EndUserRequisitionProducts_tbl_Clients");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblEndUserRequisitionProducts)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_tbl_EndUserRequisitionProducts_tbl_Departments");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.TblEndUserRequisitionProducts)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_tbl_EndUserRequisitionProducts_tbl_Position");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblEndUserRequisitionProducts)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_tbl_EndUserRequisitionProducts_tbl_Projects");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.TblEndUserRequisitionProducts)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_tbl_EndUserRequisitionProducts_tbl_StaffBioData");
            });

            modelBuilder.Entity<TblEndUserRequisitionProductsDeliveryInfo>(entity =>
            {
                entity.HasKey(e => e.EurpdelInfoId)
                    .HasName("PK_EndUserRequisitionProductsDeliveryInfo");

                entity.ToTable("tbl_EndUserRequisitionProductsDeliveryInfo");

                entity.Property(e => e.EurpdelInfoId).HasColumnName("EURPDelInfoID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryAddress).HasMaxLength(200);

                entity.Property(e => e.Eurpid).HasColumnName("EURPID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.HasOne(d => d.Eurp)
                    .WithMany(p => p.TblEndUserRequisitionProductsDeliveryInfo)
                    .HasForeignKey(d => d.Eurpid)
                    .HasConstraintName("FK_tbl_EndUserRequisitionProductsDeliveryInfo_tbl_EndUserRequisitionProducts");
            });

            modelBuilder.Entity<TblEndUserRequisitionProductsDetails>(entity =>
            {
                entity.HasKey(e => e.EurpdetId);

                entity.ToTable("tbl_EndUserRequisitionProductsDetails");

                entity.Property(e => e.EurpdetId).HasColumnName("EURPDetID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.EstimatedCost).HasColumnType("money");

                entity.Property(e => e.Eurpid).HasColumnName("EURPID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RefCodeStandards).HasMaxLength(100);

                entity.Property(e => e.Unit).HasMaxLength(50);

                entity.HasOne(d => d.Eurp)
                    .WithMany(p => p.TblEndUserRequisitionProductsDetails)
                    .HasForeignKey(d => d.Eurpid)
                    .HasConstraintName("FK_tbl_EndUserRequisitionProductsDetails_tbl_EndUserRequisitionProducts");
            });

            modelBuilder.Entity<TblEndUserRequisitionProductsMto>(entity =>
            {
                entity.HasKey(e => e.Eurpmtoid);

                entity.ToTable("tbl_EndUserRequisitionProductsMTO");

                entity.Property(e => e.Eurpmtoid).HasColumnName("EURPMTOID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Eurpid).HasColumnName("EURPID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MtoformId).HasColumnName("MTOFormID");

                entity.HasOne(d => d.Eurp)
                    .WithMany(p => p.TblEndUserRequisitionProductsMto)
                    .HasForeignKey(d => d.Eurpid)
                    .HasConstraintName("FK_tbl_EndUserRequisitionProductsMTO_tbl_EndUserRequisitionProducts");

                entity.HasOne(d => d.Mtoform)
                    .WithMany(p => p.TblEndUserRequisitionProductsMto)
                    .HasForeignKey(d => d.MtoformId)
                    .HasConstraintName("FK_tbl_EndUserRequisitionProductsMTO_tbl_MTOForms");
            });

            modelBuilder.Entity<TblEndUserRequisitionProductsOtherInfo>(entity =>
            {
                entity.HasKey(e => e.EurpotherInfoId);

                entity.ToTable("tbl_EndUserRequisitionProductsOtherInfo");

                entity.Property(e => e.EurpotherInfoId).HasColumnName("EURPOtherInfoID");

                entity.Property(e => e.AsservicesRq).HasColumnName("ASServicesRq");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DataSheet).HasMaxLength(100);

                entity.Property(e => e.Eurpid).HasColumnName("EURPID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Mto)
                    .HasColumnName("MTO")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Eurp)
                    .WithMany(p => p.TblEndUserRequisitionProductsOtherInfo)
                    .HasForeignKey(d => d.Eurpid)
                    .HasConstraintName("FK_tbl_EndUserRequisitionProductsOtherInfo_tbl_EndUserRequisitionProducts");
            });

            modelBuilder.Entity<TblEndUserRequisitionServices>(entity =>
            {
                entity.HasKey(e => e.Eursid);

                entity.ToTable("tbl_EndUserRequisitionServices");

                entity.Property(e => e.Eursid).HasColumnName("EURSID");

                entity.Property(e => e.BudgetEstimate).HasColumnType("money");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocumentTitle).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.RequisitionNumber).HasMaxLength(20);

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.TechnicalScore).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblEndUserRequisitionServices)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_tbl_EndUserRequisitionServices_tbl_City");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TblEndUserRequisitionServices)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_tbl_EndUserRequisitionServices_tbl_Clients");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblEndUserRequisitionServices)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tbl_EndUserRequisitionServices_tbl_Country");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblEndUserRequisitionServices)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_tbl_EndUserRequisitionServices_tbl_Projects");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TblEndUserRequisitionServices)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_tbl_EndUserRequisitionServices_tbl_State");
            });

            modelBuilder.Entity<TblEndUserRequisitionServicesMto>(entity =>
            {
                entity.HasKey(e => e.Eursmtoid);

                entity.ToTable("tbl_EndUserRequisitionServicesMTO");

                entity.Property(e => e.Eursmtoid).HasColumnName("EURSMTOID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Eursid).HasColumnName("EURSID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MtoformId).HasColumnName("MTOFormID");

                entity.HasOne(d => d.Eurs)
                    .WithMany(p => p.TblEndUserRequisitionServicesMto)
                    .HasForeignKey(d => d.Eursid)
                    .HasConstraintName("FK_tbl_EndUserRequisitionServicesMTO_tbl_EndUserRequisitionServices");

                entity.HasOne(d => d.Mtoform)
                    .WithMany(p => p.TblEndUserRequisitionServicesMto)
                    .HasForeignKey(d => d.MtoformId)
                    .HasConstraintName("FK_tbl_EndUserRequisitionServicesMTO_tbl_MTOForms");
            });

            modelBuilder.Entity<TblEventDetails>(entity =>
            {
                entity.HasKey(e => e.EventDetId);

                entity.ToTable("tbl_EventDetails");

                entity.Property(e => e.EventDetId).HasColumnName("EventDetID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Rfxnumber)
                    .HasColumnName("RFXNumber")
                    .HasMaxLength(100);

                entity.Property(e => e.Rfxowner).HasColumnName("RFXOwner");

                entity.Property(e => e.RfxstartDate)
                    .HasColumnName("RFXStartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Rfxstatus)
                    .HasColumnName("RFXStatus")
                    .HasMaxLength(100);

                entity.Property(e => e.SmartNumber).HasMaxLength(100);

                entity.Property(e => e.SubmissionDeadline).HasColumnType("datetime");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.TblEventDetails)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_tbl_EventDetails_tbl_Events");

                entity.HasOne(d => d.RfxownerNavigation)
                    .WithMany(p => p.TblEventDetails)
                    .HasForeignKey(d => d.Rfxowner)
                    .HasConstraintName("FK_tbl_EventDetails_tbl_StaffBioData");
            });

            modelBuilder.Entity<TblEventOtherInfo>(entity =>
            {
                entity.HasKey(e => e.EventOtherInfoId);

                entity.ToTable("tbl_EventOtherInfo");

                entity.Property(e => e.EventOtherInfoId).HasColumnName("EventOtherInfoID");

                entity.Property(e => e.Attachments).HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.TblEventOtherInfo)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_tbl_EventOtherInfo_tbl_Events");
            });

            modelBuilder.Entity<TblEvents>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("tbl_Events");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EventDescription).HasMaxLength(20);

                entity.Property(e => e.EventNumber).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ResponseNumber).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblFinancialStatements>(entity =>
            {
                entity.HasKey(e => e.FinStatId);

                entity.ToTable("tbl_FinancialStatements");

                entity.Property(e => e.FinStatId).HasColumnName("FinStatID");

                entity.Property(e => e.AnnualReport).HasMaxLength(100);

                entity.Property(e => e.AuditorAddress).HasMaxLength(500);

                entity.Property(e => e.AuditorName).HasMaxLength(200);

                entity.Property(e => e.ContactNumber).HasMaxLength(20);

                entity.Property(e => e.FinancialStatement).HasMaxLength(100);

                entity.Property(e => e.FinancialStatementYear2).HasMaxLength(100);

                entity.Property(e => e.FinancialStatementYear3).HasMaxLength(100);

                entity.Property(e => e.IsListed).HasMaxLength(10);

                entity.Property(e => e.StockMarketInfo).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.TaxIdentificationNo).HasMaxLength(20);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblFinancialStatements)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_FinancialStatements_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblForeignCompany>(entity =>
            {
                entity.HasKey(e => e.ForComId);

                entity.ToTable("tbl_ForeignCompany");

                entity.Property(e => e.ForComId).HasColumnName("ForComID");

                entity.Property(e => e.CompanyName).HasMaxLength(200);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.ProductSuppliedNavigation)
                    .WithMany(p => p.TblForeignCompany)
                    .HasForeignKey(d => d.ProductSupplied)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ForeignCompany_tbl_Products");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblForeignCompany)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ForeignCompany_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblFormIdentification>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("tbl_FormIdentification");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WorkPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblHealthSafetyEnvironment>(entity =>
            {
                entity.HasKey(e => e.HseId);

                entity.ToTable("tbl_HealthSafetyEnvironment");

                entity.Property(e => e.HseId).HasColumnName("HSE_ID");

                entity.Property(e => e.Fax).HasMaxLength(100);

                entity.Property(e => e.HseCompanyKpi)
                    .HasColumnName("HSE_CompanyKPI")
                    .HasMaxLength(100);

                entity.Property(e => e.HseManagerEmail)
                    .HasColumnName("HSE_ManagerEmail")
                    .HasMaxLength(100);

                entity.Property(e => e.HseManagerName)
                    .HasColumnName("HSE_ManagerName")
                    .HasMaxLength(200);

                entity.Property(e => e.HseYearN1results)
                    .HasColumnName("HSE_YearN1Results")
                    .HasMaxLength(100);

                entity.Property(e => e.Hsepolicy)
                    .HasColumnName("HSEPolicy")
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(100);

                entity.Property(e => e.StaffTraining).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.ThirdPartyAudit).HasMaxLength(100);

                entity.Property(e => e.WorkPhoneNumber).HasMaxLength(100);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblHealthSafetyEnvironment)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_HealthSafetyEnvironment_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblHseCertification>(entity =>
            {
                entity.HasKey(e => e.HseCertId);

                entity.ToTable("tbl_HSE_Certification");

                entity.Property(e => e.HseCertId).HasColumnName("HSE_CertID");

                entity.Property(e => e.CertOrgId).HasColumnName("CertOrgID");

                entity.Property(e => e.CertificateCopy).HasMaxLength(100);

                entity.Property(e => e.NameofCertificate).HasMaxLength(200);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.ValidityDate).HasColumnType("datetime");

                entity.HasOne(d => d.CertOrg)
                    .WithMany(p => p.TblHseCertification)
                    .HasForeignKey(d => d.CertOrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_HSE_Certification_tbl_CertifyingOrg");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblHseCertification)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_HSE_Certification_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.ToTable("tbl_Invoice");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.Attention).HasMaxLength(200);

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.CompanyInfoId).HasColumnName("CompanyInfoID");

                entity.Property(e => e.Contact).HasMaxLength(200);

                entity.Property(e => e.ContractTitle).HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceNumber).HasMaxLength(100);

                entity.Property(e => e.IssuedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PoId).HasColumnName("PO_ID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.TaxIdnumber)
                    .HasColumnName("TaxIDNumber")
                    .HasMaxLength(100);

                entity.Property(e => e.Vatrate)
                    .HasColumnName("VATRate")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.VatregNumber)
                    .HasColumnName("VATRegNumber")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TblInvoice)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_tbl_Invoice_tbl_Clients");

                entity.HasOne(d => d.CompanyInfo)
                    .WithMany(p => p.TblInvoice)
                    .HasForeignKey(d => d.CompanyInfoId)
                    .HasConstraintName("FK_tbl_Invoice_tbl_CompanyInfo");

                entity.HasOne(d => d.Po)
                    .WithMany(p => p.TblInvoice)
                    .HasForeignKey(d => d.PoId)
                    .HasConstraintName("FK_tbl_Invoice_tbl_PurchaseOrder");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblInvoice)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_Invoice_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblInvoiceDetails>(entity =>
            {
                entity.HasKey(e => e.InvoiceDetId);

                entity.ToTable("tbl_InvoiceDetails");

                entity.Property(e => e.InvoiceDetId).HasColumnName("InvoiceDetID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AmountInWords).HasMaxLength(200);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.TblInvoiceDetails)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK_tbl_InvoiceDetails_tbl_Invoice");
            });

            modelBuilder.Entity<TblInvoiceOtherInfo>(entity =>
            {
                entity.HasKey(e => e.InvoiceOtherInfoId);

                entity.ToTable("tbl_InvoiceOtherInfo");

                entity.Property(e => e.InvoiceOtherInfoId).HasColumnName("InvoiceOtherInfoID");

                entity.Property(e => e.AccountDetails).HasMaxLength(100);

                entity.Property(e => e.AccountName).HasMaxLength(200);

                entity.Property(e => e.AccountNumber).HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentBankId).HasColumnName("PaymentBankID");

                entity.Property(e => e.SortCode).HasMaxLength(20);

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.TblInvoiceOtherInfo)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK_tbl_InvoiceOtherInfo_tbl_Invoice");
            });

            modelBuilder.Entity<TblJobCompletionCertificate>(entity =>
            {
                entity.HasKey(e => e.Jccid);

                entity.ToTable("tbl_JobCompletionCertificate");

                entity.Property(e => e.Jccid).HasColumnName("JCCID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CertificateNumber).HasMaxLength(20);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryAddress).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RecieptDate).HasColumnType("datetime");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Telephone).HasMaxLength(20);

                entity.Property(e => e.WorkOrder).HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TblJobCompletionCertificate)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_tbl_JobCompletionCertificate_tbl_CompanyInfo");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblJobCompletionCertificate)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_JobCompletionCertificate_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblJustificationofAward>(entity =>
            {
                entity.HasKey(e => e.Joaid);

                entity.ToTable("tbl_JustificationofAward");

                entity.Property(e => e.Joaid).HasColumnName("JOAID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EndUser).HasMaxLength(100);

                entity.Property(e => e.EndUserDepartmentId).HasColumnName("EndUserDepartmentID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.Rfqid).HasColumnName("RFQID");

                entity.Property(e => e.Rqnnumber)
                    .HasColumnName("RQNNumber")
                    .HasMaxLength(200);

                entity.Property(e => e.ScoreCommercialEval).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ScoreTechnicalEval).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.VendorBidPrice).HasColumnType("money");

                entity.HasOne(d => d.EndUserDepartment)
                    .WithMany(p => p.TblJustificationofAward)
                    .HasForeignKey(d => d.EndUserDepartmentId)
                    .HasConstraintName("FK_tbl_JustificationofAward_tbl_Departments");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblJustificationofAward)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_tbl_JustificationofAward_tbl_Projects");

                entity.HasOne(d => d.Rfq)
                    .WithMany(p => p.TblJustificationofAward)
                    .HasForeignKey(d => d.Rfqid)
                    .HasConstraintName("FK_tbl_JustificationofAward_tbl_QuotationMaster");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblJustificationofAward)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_JustificationofAward_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("tbl_Log");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.Comments).HasMaxLength(1000);

                entity.Property(e => e.LogDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<TblMainCustomers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("tbl_MainCustomers");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.ValueId).HasColumnName("ValueID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblMainCustomers)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_MainCustomers_tbl_Country");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblMainCustomers)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_MainCustomers_tbl_SupplierIdentification");

                entity.HasOne(d => d.Value)
                    .WithMany(p => p.TblMainCustomers)
                    .HasForeignKey(d => d.ValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_MainCustomers_tbl_ValueDetails");
            });

            modelBuilder.Entity<TblManufacturers>(entity =>
            {
                entity.HasKey(e => e.ManufacturerId);

                entity.ToTable("tbl_Manufacturers");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ManufacturerName).HasMaxLength(100);

                entity.Property(e => e.StatusReason).HasMaxLength(200);
            });

            modelBuilder.Entity<TblMaterials>(entity =>
            {
                entity.HasKey(e => e.MaterialId);

                entity.ToTable("tbl_Materials");

                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.MaterialName).HasMaxLength(100);
            });

            modelBuilder.Entity<TblMtoformDetails>(entity =>
            {
                entity.HasKey(e => e.MtoformDetId);

                entity.ToTable("tbl_MTOFormDetails");

                entity.Property(e => e.MtoformDetId).HasColumnName("MTOFormDetID");

                entity.Property(e => e.AdditionalInfo).HasMaxLength(100);

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocumentNumber).HasMaxLength(50);

                entity.Property(e => e.Item).HasMaxLength(100);

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.ModelNumber).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MtoformId).HasColumnName("MTOFormID");

                entity.Property(e => e.Rating).HasMaxLength(10);

                entity.Property(e => e.Remarks).HasMaxLength(1000);

                entity.Property(e => e.Rfq)
                    .HasColumnName("RFQ")
                    .HasMaxLength(50);

                entity.Property(e => e.Schedule).HasMaxLength(10);

                entity.Property(e => e.Size).HasMaxLength(10);

                entity.Property(e => e.Spare).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblMtoformDetails)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_tbl_MTOFormDetails_tbl_City");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblMtoformDetails)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tbl_MTOFormDetails_tbl_Country");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.TblMtoformDetails)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_tbl_MTOFormDetails_tbl_Manufacturers");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.TblMtoformDetails)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_tbl_MTOFormDetails_tbl_Materials");

                entity.HasOne(d => d.Mtoform)
                    .WithMany(p => p.TblMtoformDetails)
                    .HasForeignKey(d => d.MtoformId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_MTOFormDetails_tbl_MTOForms");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TblMtoformDetails)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_tbl_MTOFormDetails_tbl_State");
            });

            modelBuilder.Entity<TblMtoforms>(entity =>
            {
                entity.HasKey(e => e.MtoformId);

                entity.ToTable("tbl_MTOForms");

                entity.Property(e => e.MtoformId).HasColumnName("MTOFormID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FormName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ValidityPeriod).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TblMtoforms)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_tbl_MTOForms_tbl_Clients");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TblMtoforms)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_tbl_MTOForms_tbl_CompanyInfo");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblMtoforms)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_MTOForms_tbl_Projects");
            });

            modelBuilder.Entity<TblNotificationGroup>(entity =>
            {
                entity.HasKey(e => e.NoGrId);

                entity.ToTable("tbl_NotificationGroup");

                entity.Property(e => e.NoGrId).HasColumnName("NoGrID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.WfdefId).HasColumnName("WFDefID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblNotificationGroup)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_tbl_NotificationGroup_tbl_Departments");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.TblNotificationGroup)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_tbl_NotificationGroup_tbl_Position");

                entity.HasOne(d => d.Wfdef)
                    .WithMany(p => p.TblNotificationGroup)
                    .HasForeignKey(d => d.WfdefId)
                    .HasConstraintName("FK_tbl_NotificationGroup_tbl_WorkflowProcessDef");
            });

            modelBuilder.Entity<TblNumberOfEmployees>(entity =>
            {
                entity.HasKey(e => e.NoOfEmpId);

                entity.ToTable("tbl_NumberOfEmployees");

                entity.Property(e => e.NoOfEmpId).HasColumnName("NoOfEmpID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.StaffStrCompId).HasColumnName("StaffStrCompID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblNumberOfEmployees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_NumberOfEmployees_tbl_Departments");

                entity.HasOne(d => d.StaffStrComp)
                    .WithMany(p => p.TblNumberOfEmployees)
                    .HasForeignKey(d => d.StaffStrCompId)
                    .HasConstraintName("FK_tbl_NumberofEmployees_tbl_StaffStrengthComp");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblNumberOfEmployees)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_NumberOfEmployees_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblOfficeServiceCl>(entity =>
            {
                entity.HasKey(e => e.OfficeServClId);

                entity.ToTable("tbl_OfficeServiceCL");

                entity.Property(e => e.OfficeServClId).HasColumnName("OfficeServCL_ID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.SpServices)
                    .IsRequired()
                    .HasColumnName("SP_Services")
                    .HasMaxLength(500);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblOfficeServiceCl)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_tbl_OfficeServiceCL_tbl_City");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblOfficeServiceCl)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tbl_OfficeServiceCL_tbl_Country");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblOfficeServiceCl)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_OfficeServiceCL_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblPaymentBank>(entity =>
            {
                entity.HasKey(e => e.PymntBankId);

                entity.ToTable("tbl_PaymentBank");

                entity.Property(e => e.PymntBankId).HasColumnName("PymntBankID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentBankCode).HasMaxLength(10);

                entity.Property(e => e.PaymentBankName).HasMaxLength(100);
            });

            modelBuilder.Entity<TblPaymentRequestDetails>(entity =>
            {
                entity.HasKey(e => e.PayReqDetId);

                entity.ToTable("tbl_PaymentRequestDetails");

                entity.Property(e => e.PayReqDetId).HasColumnName("PayReqDetID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AmountInWords)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.GlaccountCode)
                    .IsRequired()
                    .HasColumnName("GLAccountCode")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PayReqMasterId).HasColumnName("PayReqMasterID");

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.HasOne(d => d.PayReqMaster)
                    .WithMany(p => p.TblPaymentRequestDetails)
                    .HasForeignKey(d => d.PayReqMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PaymentRequestDetails_tbl_PaymentRequestMaster");
            });

            modelBuilder.Entity<TblPaymentRequestMaster>(entity =>
            {
                entity.HasKey(e => e.PayReqMasterId);

                entity.ToTable("tbl_PaymentRequestMaster");

                entity.Property(e => e.PayReqMasterId).HasColumnName("PayReqMasterID");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PayReqDate).HasColumnType("datetime");

                entity.Property(e => e.PayReqNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Payee)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PaymentBankId).HasColumnName("PaymentBankID");

                entity.Property(e => e.PoId).HasColumnName("PO_ID");

                entity.HasOne(d => d.DepartmentProjectNavigation)
                    .WithMany(p => p.TblPaymentRequestMaster)
                    .HasForeignKey(d => d.DepartmentProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PaymentRequestMaster_tbl_Departments");

                entity.HasOne(d => d.PaymentBank)
                    .WithMany(p => p.TblPaymentRequestMaster)
                    .HasForeignKey(d => d.PaymentBankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PaymentRequestMaster_tbl_PaymentBank");

                entity.HasOne(d => d.Po)
                    .WithMany(p => p.TblPaymentRequestMaster)
                    .HasForeignKey(d => d.PoId)
                    .HasConstraintName("FK_tbl_PaymentRequestMaster_tbl_PurchaseOrder");
            });

            modelBuilder.Entity<TblPosition>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.ToTable("tbl_Position");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.PositionCode).HasMaxLength(10);

                entity.Property(e => e.PositionEmailAddress).HasMaxLength(100);

                entity.Property(e => e.PositionTitle).HasMaxLength(200);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblPosition)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_tbl_Position_tbl_Departments");
            });

            modelBuilder.Entity<TblProductCategory>(entity =>
            {
                entity.HasKey(e => e.ProductCatId);

                entity.ToTable("tbl_ProductCategory");

                entity.Property(e => e.ProductCatId).HasColumnName("ProductCatID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DprcatId).HasColumnName("DPRCatID");

                entity.Property(e => e.ProductCatCode).HasMaxLength(10);

                entity.Property(e => e.ProductCatName).HasMaxLength(100);

                entity.HasOne(d => d.Dprcat)
                    .WithMany(p => p.TblProductCategory)
                    .HasForeignKey(d => d.DprcatId)
                    .HasConstraintName("FK_tbl_ProductCategory_tbl_DPRCategory");
            });

            modelBuilder.Entity<TblProductEquipmentService>(entity =>
            {
                entity.HasKey(e => e.ProdEquSerId);

                entity.ToTable("tbl_ProductEquipmentService");

                entity.Property(e => e.ProdEquSerId).HasColumnName("ProdEquSerID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblProductServiceCategory>(entity =>
            {
                entity.HasKey(e => e.ProdServId);

                entity.ToTable("tbl_ProductServiceCategory");

                entity.Property(e => e.ProdServId).HasColumnName("ProdServID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblProducts>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("tbl_Products");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductCatId).HasColumnName("ProductCatID");

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.HasOne(d => d.ProductCat)
                    .WithMany(p => p.TblProducts)
                    .HasForeignKey(d => d.ProductCatId)
                    .HasConstraintName("FK_tbl_Products_tbl_ProductCategory");
            });

            modelBuilder.Entity<TblProjects>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.ToTable("tbl_Projects");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblPurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.PoId);

                entity.ToTable("tbl_PurchaseOrder");

                entity.Property(e => e.PoId).HasColumnName("PO_ID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IssuedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Poamount)
                    .HasColumnName("POAmount")
                    .HasColumnType("money");

                entity.Property(e => e.Potype).HasColumnName("POType");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.QuoMasterId).HasColumnName("QuoMasterID");

                entity.Property(e => e.QuoteRef).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TblPurchaseOrder)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_tbl_PurchaseOrder_tbl_CompanyInfo");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblPurchaseOrder)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_tbl_PurchaseOrder_tbl_Projects");

                entity.HasOne(d => d.QuoMaster)
                    .WithMany(p => p.TblPurchaseOrder)
                    .HasForeignKey(d => d.QuoMasterId)
                    .HasConstraintName("FK_tbl_PurchaseOrder_tbl_QuotationMaster");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblPurchaseOrder)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_PurchaseOrder_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblPurchaseOrderDetails>(entity =>
            {
                entity.HasKey(e => e.PodetId);

                entity.ToTable("tbl_PurchaseOrderDetails");

                entity.Property(e => e.PodetId).HasColumnName("PODet_ID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.DeliveryAddress).HasMaxLength(500);

                entity.Property(e => e.DeliveryTerms).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PoId).HasColumnName("PO_ID");

                entity.Property(e => e.Rate).HasColumnType("money");

                entity.Property(e => e.SubTotal).HasColumnType("money");

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.Total).HasColumnType("money");

                entity.Property(e => e.TotalCost).HasColumnType("money");

                entity.Property(e => e.UnitCost).HasColumnType("money");

                entity.Property(e => e.Vat)
                    .HasColumnName("VAT")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.TblPurchaseOrderDetails)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_tbl_PurchaseOrderDetails_tbl_Currency");

                entity.HasOne(d => d.Po)
                    .WithMany(p => p.TblPurchaseOrderDetails)
                    .HasForeignKey(d => d.PoId)
                    .HasConstraintName("FK_tbl_PurchaseOrderDetails_tbl_PurchaseOrder");
            });

            modelBuilder.Entity<TblPurchaseOrderMilestones>(entity =>
            {
                entity.HasKey(e => e.MilestoneId);

                entity.ToTable("tbl_PurchaseOrderMilestones");

                entity.Property(e => e.MilestoneId).HasColumnName("MilestoneID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EstimatedDate).HasColumnType("datetime");

                entity.Property(e => e.MilestoneAmount).HasColumnType("money");

                entity.Property(e => e.MilestoneDetails).HasMaxLength(500);

                entity.Property(e => e.MilestoneWeight).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PoId).HasColumnName("PO_ID");

                entity.Property(e => e.Vendor).HasMaxLength(200);

                entity.HasOne(d => d.Po)
                    .WithMany(p => p.TblPurchaseOrderMilestones)
                    .HasForeignKey(d => d.PoId)
                    .HasConstraintName("FK_tbl_PurchaseOrderMilestones_tbl_PurchaseOrder");
            });

            modelBuilder.Entity<TblQualityCertification>(entity =>
            {
                entity.HasKey(e => e.QualCertId);

                entity.ToTable("tbl_QualityCertification");

                entity.Property(e => e.QualCertId).HasColumnName("QualCertID");

                entity.Property(e => e.CertOrgId).HasColumnName("CertOrgID");

                entity.Property(e => e.CertificateCopy).HasMaxLength(100);

                entity.Property(e => e.NameofCertificate).HasMaxLength(200);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.ValidityDate).HasColumnType("datetime");

                entity.HasOne(d => d.CertOrg)
                    .WithMany(p => p.TblQualityCertification)
                    .HasForeignKey(d => d.CertOrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QualityCertification_tbl_CertifyingOrg");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblQualityCertification)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QualityCertification_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblQualityManagement>(entity =>
            {
                entity.HasKey(e => e.QualMgtId);

                entity.ToTable("tbl_QualityManagement");

                entity.Property(e => e.QualMgtId).HasColumnName("QualMgtID");

                entity.Property(e => e.Fax).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(100);

                entity.Property(e => e.ProductQualMgt).HasMaxLength(100);

                entity.Property(e => e.QualManagerEmail).HasMaxLength(100);

                entity.Property(e => e.QualManagerName).HasMaxLength(200);

                entity.Property(e => e.QualityMgt).HasMaxLength(100);

                entity.Property(e => e.QualityPolicy).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.WorkPhoneNumber).HasMaxLength(100);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblQualityManagement)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QualityManagement_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblQuotationApproval>(entity =>
            {
                entity.HasKey(e => e.QuoAppId);

                entity.ToTable("tbl_QuotationApproval");

                entity.Property(e => e.QuoAppId).HasColumnName("QuoAppID");

                entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

                entity.Property(e => e.ApprovalSignature).HasMaxLength(100);

                entity.Property(e => e.BuyerName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.QuoMasterId).HasColumnName("QuoMasterID");

                entity.HasOne(d => d.QuoMaster)
                    .WithMany(p => p.TblQuotationApproval)
                    .HasForeignKey(d => d.QuoMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QuotationApproval_tbl_QuotationMaster");
            });

            modelBuilder.Entity<TblQuotationDeliveryInfo>(entity =>
            {
                entity.HasKey(e => e.DelInfoId)
                    .HasName("PK_tbl_DeliveryInfo");

                entity.ToTable("tbl_QuotationDeliveryInfo");

                entity.Property(e => e.DelInfoId).HasColumnName("DelInfoID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.QuoMasterId).HasColumnName("QuoMasterID");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.SpecialInstructions).IsRequired();

                entity.HasOne(d => d.QuoMaster)
                    .WithMany(p => p.TblQuotationDeliveryInfo)
                    .HasForeignKey(d => d.QuoMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QuotationDeliveryInfo_tbl_QuotationMaster");
            });

            modelBuilder.Entity<TblQuotationDetails>(entity =>
            {
                entity.HasKey(e => e.QuoDetId)
                    .HasName("PK_tbl_QuotationDetail");

                entity.ToTable("tbl_QuotationDetails");

                entity.Property(e => e.QuoDetId).HasColumnName("QuoDetID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.EstimatedCost).HasColumnType("money");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.QuoMasterId).HasColumnName("QuoMasterID");

                entity.Property(e => e.QuoteRef).HasMaxLength(100);

                entity.HasOne(d => d.QuoMaster)
                    .WithMany(p => p.TblQuotationDetails)
                    .HasForeignKey(d => d.QuoMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QuotationDetails_tbl_QuotationMaster");
            });

            modelBuilder.Entity<TblQuotationMaster>(entity =>
            {
                entity.HasKey(e => e.QuoMasterId);

                entity.ToTable("tbl_QuotationMaster");

                entity.Property(e => e.QuoMasterId).HasColumnName("QuoMasterID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ExpiryReminderDate).HasColumnType("datetime");

                entity.Property(e => e.ExtensionDate).HasColumnType("datetime");

                entity.Property(e => e.ExtensionReminder).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.QuotationDate).HasColumnType("datetime");

                entity.Property(e => e.RequestTitle).HasMaxLength(200);

                entity.Property(e => e.Rfqnumber)
                    .HasColumnName("RFQNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Rfqtype).HasColumnName("RFQType");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.TenderAttId).HasColumnName("TenderAttID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TblQuotationMaster)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_tbl_QuotationMaster_tbl_Clients");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.TblQuotationMaster)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_tbl_QuotationMaster_tbl_Events");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblQuotationMaster)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_tbl_QuotationMaster_tbl_Projects");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblQuotationMaster)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QuotationMaster_tbl_SupplierIdentification");

                entity.HasOne(d => d.TenderAtt)
                    .WithMany(p => p.TblQuotationMaster)
                    .HasForeignKey(d => d.TenderAttId)
                    .HasConstraintName("FK_tbl_QuotationMaster_tbl_TenderAttachements");
            });

            modelBuilder.Entity<TblQuotationOtherInfo>(entity =>
            {
                entity.HasKey(e => e.OtherInfoId);

                entity.ToTable("tbl_QuotationOtherInfo");

                entity.Property(e => e.OtherInfoId).HasColumnName("OtherInfoID");

                entity.Property(e => e.AsservicesRq)
                    .IsRequired()
                    .HasColumnName("ASServicesRq");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.QuoMasterId).HasColumnName("QuoMasterID");

                entity.HasOne(d => d.QuoMaster)
                    .WithMany(p => p.TblQuotationOtherInfo)
                    .HasForeignKey(d => d.QuoMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_QuotationOtherInfo_tbl_QuotationMaster");
            });

            modelBuilder.Entity<TblQuotationOtherInfoAttachments>(entity =>
            {
                entity.HasKey(e => e.Qoiaid);

                entity.ToTable("tbl_QuotationOtherInfoAttachments");

                entity.Property(e => e.Qoiaid).HasColumnName("QOIAID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DataSheet).HasMaxLength(100);

                entity.Property(e => e.DocTypeId).HasColumnName("DocTypeID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Mtocertificate)
                    .HasColumnName("MTOCertificate")
                    .HasMaxLength(100);

                entity.Property(e => e.OtherInfoId).HasColumnName("OtherInfoID");

                entity.HasOne(d => d.DocType)
                    .WithMany(p => p.TblQuotationOtherInfoAttachments)
                    .HasForeignKey(d => d.DocTypeId)
                    .HasConstraintName("FK_tbl_QuotationOtherInfoAttachments_tbl_DocumentType");

                entity.HasOne(d => d.OtherInfo)
                    .WithMany(p => p.TblQuotationOtherInfoAttachments)
                    .HasForeignKey(d => d.OtherInfoId)
                    .HasConstraintName("FK_tbl_QuotationOtherInfoAttachments_tbl_QuotationOtherInfo");
            });

            modelBuilder.Entity<TblServices>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.ToTable("tbl_Services");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ServCatId).HasColumnName("ServCatID");

                entity.Property(e => e.ServiceCode).HasMaxLength(10);

                entity.Property(e => e.ServiceName).HasMaxLength(100);

                entity.HasOne(d => d.ServCat)
                    .WithMany(p => p.TblServices)
                    .HasForeignKey(d => d.ServCatId)
                    .HasConstraintName("FK_tbl_Services_tbl_ServicesCategory");
            });

            modelBuilder.Entity<TblServicesCategory>(entity =>
            {
                entity.HasKey(e => e.ServCatId);

                entity.ToTable("tbl_ServicesCategory");

                entity.Property(e => e.ServCatId).HasColumnName("ServCatID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DprcatId).HasColumnName("DPRCatID");

                entity.Property(e => e.ServCatCode).HasMaxLength(10);

                entity.Property(e => e.ServCatName).HasMaxLength(100);

                entity.HasOne(d => d.Dprcat)
                    .WithMany(p => p.TblServicesCategory)
                    .HasForeignKey(d => d.DprcatId)
                    .HasConstraintName("FK_tbl_ServicesCategory_tbl_DPRCategory");
            });

            modelBuilder.Entity<TblSingleTenderJustification>(entity =>
            {
                entity.HasKey(e => e.Stjid);

                entity.ToTable("tbl_SingleTenderJustification");

                entity.Property(e => e.Stjid).HasColumnName("STJID");

                entity.Property(e => e.AdditionalInfo).HasMaxLength(100);

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.ContactName).HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProposedContractValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProposedContractor).HasMaxLength(200);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.TelephoneNumber).HasMaxLength(50);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblSingleTenderJustification)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_tbl_SingleTenderJustification_tbl_Projects");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblSingleTenderJustification)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_SingleTenderJustification_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblSpDirectServiceScope>(entity =>
            {
                entity.HasKey(e => e.SpDssId);

                entity.ToTable("tbl_SP_DirectServiceScope");

                entity.Property(e => e.SpDssId).HasColumnName("SP_DSS_ID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.SpServices)
                    .HasColumnName("SP_Services")
                    .HasMaxLength(500);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblSpDirectServiceScope)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_SP_DirectServiceScope_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblSrconstructionTechnicalQueries>(entity =>
            {
                entity.HasKey(e => e.Ctqid);

                entity.ToTable("tbl_SRConstructionTechnicalQueries");

                entity.Property(e => e.Ctqid).HasColumnName("CTQID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Ctqdescription).HasColumnName("CTQDescription");

                entity.Property(e => e.Ctqnumber)
                    .IsRequired()
                    .HasColumnName("CTQNumber")
                    .HasMaxLength(100);

                entity.Property(e => e.Ctqtitle)
                    .IsRequired()
                    .HasColumnName("CTQTitle")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.QueryDate).HasColumnType("datetime");

                entity.Property(e => e.ReplyRequiredBy).HasColumnType("datetime");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.HasOne(d => d.AttentionNavigation)
                    .WithMany(p => p.TblSrconstructionTechnicalQueriesAttentionNavigation)
                    .HasForeignKey(d => d.Attention)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueries_tbl_StaffBioData1");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblSrconstructionTechnicalQueries)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueries_tbl_City");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblSrconstructionTechnicalQueries)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueries_tbl_Country");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblSrconstructionTechnicalQueries)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueries_tbl_Projects");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.TblSrconstructionTechnicalQueriesStaff)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueries_tbl_StaffBioData");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TblSrconstructionTechnicalQueries)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueries_tbl_State");
            });

            modelBuilder.Entity<TblSrconstructionTechnicalQueriesTemp>(entity =>
            {
                entity.HasKey(e => e.Ctqid);

                entity.ToTable("tbl_SRConstructionTechnicalQueriesTemp");

                entity.Property(e => e.Ctqid).HasColumnName("CTQID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Ctqdescription).HasColumnName("CTQDescription");

                entity.Property(e => e.Ctqnumber)
                    .IsRequired()
                    .HasColumnName("CTQNumber")
                    .HasMaxLength(100);

                entity.Property(e => e.Ctqtitle)
                    .IsRequired()
                    .HasColumnName("CTQTitle")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.QueryDate).HasColumnType("datetime");

                entity.Property(e => e.ReplyRequiredBy).HasColumnType("datetime");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.HasOne(d => d.AttentionNavigation)
                    .WithMany(p => p.TblSrconstructionTechnicalQueriesTempAttentionNavigation)
                    .HasForeignKey(d => d.Attention)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueriesTemp_tbl_StaffBioData1");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblSrconstructionTechnicalQueriesTemp)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueriesTemp_tbl_City");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblSrconstructionTechnicalQueriesTemp)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueriesTemp_tbl_Country");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblSrconstructionTechnicalQueriesTemp)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueriesTemp_tbl_Projects");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.TblSrconstructionTechnicalQueriesTempStaff)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueriesTemp_tbl_StaffBioData");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TblSrconstructionTechnicalQueriesTemp)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueriesTemp_tbl_State");
            });

            modelBuilder.Entity<TblSrconstructionTechnicalQueryAttachments>(entity =>
            {
                entity.HasKey(e => e.QueryAttId);

                entity.ToTable("tbl_SRConstructionTechnicalQueryAttachments");

                entity.Property(e => e.QueryAttId).HasColumnName("QueryAttID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Ctqid).HasColumnName("CTQID");

                entity.Property(e => e.DrawingFile).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ReferenceNumber).HasMaxLength(100);

                entity.HasOne(d => d.Ctq)
                    .WithMany(p => p.TblSrconstructionTechnicalQueryAttachments)
                    .HasForeignKey(d => d.Ctqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueryAttachments_tbl_SRConstructionTechnicalQueries");
            });

            modelBuilder.Entity<TblSrconstructionTechnicalQueryAttachmentsTemp>(entity =>
            {
                entity.HasKey(e => e.QueryAttId);

                entity.ToTable("tbl_SRConstructionTechnicalQueryAttachmentsTemp");

                entity.Property(e => e.QueryAttId).HasColumnName("QueryAttID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Ctqid).HasColumnName("CTQID");

                entity.Property(e => e.DrawingFile).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ReferenceNumber).HasMaxLength(100);

                entity.HasOne(d => d.Ctq)
                    .WithMany(p => p.TblSrconstructionTechnicalQueryAttachmentsTemp)
                    .HasForeignKey(d => d.Ctqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueryAttachmentsTemp_tbl_SRConstructionTechnicalQueriesTemp");
            });

            modelBuilder.Entity<TblSrconstructionTechnicalQueryReplies>(entity =>
            {
                entity.HasKey(e => e.ReplyId);

                entity.ToTable("tbl_SRConstructionTechnicalQueryReplies");

                entity.Property(e => e.ReplyId).HasColumnName("ReplyID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Ctqid).HasColumnName("CTQID");

                entity.Property(e => e.InitiatorReplyDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.QueryCloseDate).HasColumnType("datetime");

                entity.HasOne(d => d.Ctq)
                    .WithMany(p => p.TblSrconstructionTechnicalQueryReplies)
                    .HasForeignKey(d => d.Ctqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueryReplies_tbl_SRConstructionTechnicalQueries");
            });

            modelBuilder.Entity<TblSrconstructionTechnicalQueryRepliesTemp>(entity =>
            {
                entity.HasKey(e => e.ReplyId);

                entity.ToTable("tbl_SRConstructionTechnicalQueryRepliesTemp");

                entity.Property(e => e.ReplyId).HasColumnName("ReplyID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Ctqid).HasColumnName("CTQID");

                entity.Property(e => e.InitiatorReplyDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.QueryCloseDate).HasColumnType("datetime");

                entity.HasOne(d => d.Ctq)
                    .WithMany(p => p.TblSrconstructionTechnicalQueryRepliesTemp)
                    .HasForeignKey(d => d.Ctqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRConstructionTechnicalQueryRepliesTemp_tbl_SRConstructionTechnicalQueriesTemp");
            });

            modelBuilder.Entity<TblSrdailyReportFileAttachments>(entity =>
            {
                entity.HasKey(e => e.Srdrfaid);

                entity.ToTable("tbl_SRDailyReportFileAttachments");

                entity.Property(e => e.Srdrfaid).HasColumnName("SRDRFAID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DailyRepId).HasColumnName("DailyRepID");

                entity.Property(e => e.LogisticsReport).HasMaxLength(500);

                entity.Property(e => e.MaterialReport).HasMaxLength(500);

                entity.Property(e => e.Mocreport)
                    .HasColumnName("MOCReport")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PermitToWork).HasMaxLength(500);

                entity.Property(e => e.ProgressPictures).HasMaxLength(500);

                entity.Property(e => e.Qaqcreport)
                    .HasColumnName("QAQCReport")
                    .HasMaxLength(500);

                entity.Property(e => e.SecurityReport).HasMaxLength(500);

                entity.Property(e => e.SitePersonnelLogReport).HasMaxLength(500);

                entity.HasOne(d => d.DailyRep)
                    .WithMany(p => p.TblSrdailyReportFileAttachments)
                    .HasForeignKey(d => d.DailyRepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRDailyReportFileAttachments_tbl_SRDailyReporting");
            });

            modelBuilder.Entity<TblSrdailyReportFileAttachmentsTemp>(entity =>
            {
                entity.HasKey(e => e.Srdrfaid);

                entity.ToTable("tbl_SRDailyReportFileAttachmentsTemp");

                entity.Property(e => e.Srdrfaid).HasColumnName("SRDRFAID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DailyRepId).HasColumnName("DailyRepID");

                entity.Property(e => e.LogisticsReport).HasMaxLength(500);

                entity.Property(e => e.MaterialReport).HasMaxLength(500);

                entity.Property(e => e.Mocreport)
                    .HasColumnName("MOCReport")
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PermitToWork).HasMaxLength(500);

                entity.Property(e => e.ProgressPictures).HasMaxLength(500);

                entity.Property(e => e.Qaqcreport)
                    .HasColumnName("QAQCReport")
                    .HasMaxLength(500);

                entity.Property(e => e.SecurityReport).HasMaxLength(500);

                entity.Property(e => e.SitePersonnelLogReport).HasMaxLength(500);

                entity.HasOne(d => d.DailyRep)
                    .WithMany(p => p.TblSrdailyReportFileAttachmentsTemp)
                    .HasForeignKey(d => d.DailyRepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRDailyReportFileAttachmentsTemp_tbl_SRDailyReportingTemp");
            });

            modelBuilder.Entity<TblSrdailyReportHse>(entity =>
            {
                entity.HasKey(e => e.Drhseid);

                entity.ToTable("tbl_SRDailyReportHSE");

                entity.Property(e => e.Drhseid).HasColumnName("DRHSEID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DailyRepId).HasColumnName("DailyRepID");

                entity.Property(e => e.DetailsStatistics)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.DailyRep)
                    .WithMany(p => p.TblSrdailyReportHse)
                    .HasForeignKey(d => d.DailyRepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRDailyReportHSE_tbl_SRDailyReporting");
            });

            modelBuilder.Entity<TblSrdailyReportHsetemp>(entity =>
            {
                entity.HasKey(e => e.Drhseid);

                entity.ToTable("tbl_SRDailyReportHSETemp");

                entity.Property(e => e.Drhseid).HasColumnName("DRHSEID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DailyRepId).HasColumnName("DailyRepID");

                entity.Property(e => e.DetailsStatistics)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.DailyRep)
                    .WithMany(p => p.TblSrdailyReportHsetemp)
                    .HasForeignKey(d => d.DailyRepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRDailyReportHSETemp_tbl_SRDailyReportingTemp");
            });

            modelBuilder.Entity<TblSrdailyReportProgressMeasurement>(entity =>
            {
                entity.HasKey(e => e.ProMeId);

                entity.ToTable("tbl_SRDailyReportProgressMeasurement");

                entity.Property(e => e.ProMeId).HasColumnName("ProMeID");

                entity.Property(e => e.Activity)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CumPlannedProgress).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CumProgressActual).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DailyRepId).HasColumnName("DailyRepID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.DailyRep)
                    .WithMany(p => p.TblSrdailyReportProgressMeasurement)
                    .HasForeignKey(d => d.DailyRepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRDailyReportProgressMeasurement_tbl_SRDailyReporting");
            });

            modelBuilder.Entity<TblSrdailyReportProgressMeasurementTemp>(entity =>
            {
                entity.HasKey(e => e.ProMeId);

                entity.ToTable("tbl_SRDailyReportProgressMeasurementTemp");

                entity.Property(e => e.ProMeId).HasColumnName("ProMeID");

                entity.Property(e => e.Activity)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CumPlannedProgress).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CumProgressActual).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DailyRepId).HasColumnName("DailyRepID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.DailyRep)
                    .WithMany(p => p.TblSrdailyReportProgressMeasurementTemp)
                    .HasForeignKey(d => d.DailyRepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRDailyReportProgressMeasurementTemp_tbl_SRDailyReportingTemp1");
            });

            modelBuilder.Entity<TblSrdailyReporting>(entity =>
            {
                entity.HasKey(e => e.DailyRepId);

                entity.ToTable("tbl_SRDailyReporting");

                entity.Property(e => e.DailyRepId).HasColumnName("DailyRepID");

                entity.Property(e => e.ConstructionActivities).IsRequired();

                entity.Property(e => e.ConstructionActual).HasColumnType("money");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DailyProgress).IsRequired();

                entity.Property(e => e.FollowingDayPlan).IsRequired();

                entity.Property(e => e.GeneralSummary).IsRequired();

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Planned).HasColumnType("money");

                entity.Property(e => e.ProgressAt)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblSrdailyReporting)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRDailyReporting_tbl_Projects");
            });

            modelBuilder.Entity<TblSrdailyReportingDelays>(entity =>
            {
                entity.HasKey(e => e.DelayId);

                entity.ToTable("tbl_SRDailyReportingDelays");

                entity.Property(e => e.DelayId).HasColumnName("DelayID");

                entity.Property(e => e.Cause)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DailyRepId).HasColumnName("DailyRepID");

                entity.Property(e => e.DescriptionofDelay).IsRequired();

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Responsible)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TimeTaken).HasColumnType("datetime");

                entity.HasOne(d => d.DailyRep)
                    .WithMany(p => p.TblSrdailyReportingDelays)
                    .HasForeignKey(d => d.DailyRepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRDailyReportingDelays_tbl_SRDailyReporting");
            });

            modelBuilder.Entity<TblSrdailyReportingDelaysTemp>(entity =>
            {
                entity.HasKey(e => e.DelayId);

                entity.ToTable("tbl_SRDailyReportingDelaysTemp");

                entity.Property(e => e.DelayId).HasColumnName("DelayID");

                entity.Property(e => e.Cause)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DailyRepId).HasColumnName("DailyRepID");

                entity.Property(e => e.DescriptionofDelay).IsRequired();

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Responsible)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TimeTaken).HasColumnType("datetime");

                entity.HasOne(d => d.DailyRep)
                    .WithMany(p => p.TblSrdailyReportingDelaysTemp)
                    .HasForeignKey(d => d.DailyRepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRDailyReportingDelaysTemp_tbl_SRDailyReportingTemp");
            });

            modelBuilder.Entity<TblSrdailyReportingIssues>(entity =>
            {
                entity.HasKey(e => e.IssueId);

                entity.ToTable("tbl_SRDailyReportingIssues");

                entity.Property(e => e.IssueId).HasColumnName("IssueID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DailyRepId).HasColumnName("DailyRepID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.DailyRep)
                    .WithMany(p => p.TblSrdailyReportingIssues)
                    .HasForeignKey(d => d.DailyRepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRDailyReportingIssues_tbl_SRDailyReporting");
            });

            modelBuilder.Entity<TblSrdailyReportingIssuesTemp>(entity =>
            {
                entity.HasKey(e => e.IssueId);

                entity.ToTable("tbl_SRDailyReportingIssuesTemp");

                entity.Property(e => e.IssueId).HasColumnName("IssueID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DailyRepId).HasColumnName("DailyRepID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.DailyRep)
                    .WithMany(p => p.TblSrdailyReportingIssuesTemp)
                    .HasForeignKey(d => d.DailyRepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRDailyReportingIssuesTemp_tbl_SRDailyReportingTemp");
            });

            modelBuilder.Entity<TblSrdailyReportingTemp>(entity =>
            {
                entity.HasKey(e => e.DailyRepId);

                entity.ToTable("tbl_SRDailyReportingTemp");

                entity.Property(e => e.DailyRepId).HasColumnName("DailyRepID");

                entity.Property(e => e.ConstructionActivities).IsRequired();

                entity.Property(e => e.ConstructionActual).HasColumnType("money");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DailyProgress).IsRequired();

                entity.Property(e => e.FollowingDayPlan).IsRequired();

                entity.Property(e => e.GeneralSummary).IsRequired();

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Planned).HasColumnType("money");

                entity.Property(e => e.ProgressAt)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblSrdailyReportingTemp)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SRDailyReportingTemp_tbl_Projects");
            });

            modelBuilder.Entity<TblSrfileAttachments>(entity =>
            {
                entity.HasKey(e => e.Srfaid);

                entity.ToTable("tbl_SRFileAttachments");

                entity.Property(e => e.Srfaid).HasColumnName("SRFAID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocTypeId).HasColumnName("DocTypeID");

                entity.Property(e => e.Ncrid).HasColumnName("NCRID");

                entity.Property(e => e.UploadedFile).HasMaxLength(100);

                entity.HasOne(d => d.DocType)
                    .WithMany(p => p.TblSrfileAttachments)
                    .HasForeignKey(d => d.DocTypeId)
                    .HasConstraintName("FK_tbl_SRFileAttachments_tbl_DocumentType");

                entity.HasOne(d => d.Ncr)
                    .WithMany(p => p.TblSrfileAttachments)
                    .HasForeignKey(d => d.Ncrid)
                    .HasConstraintName("FK_tbl_SRFileAttachments_tbl_SRNonConformanceReports");
            });

            modelBuilder.Entity<TblSrnonConformanceReports>(entity =>
            {
                entity.HasKey(e => e.Ncrid);

                entity.ToTable("tbl_SRNonConformanceReports");

                entity.Property(e => e.Ncrid).HasColumnName("NCRID");

                entity.Property(e => e.AreaModuleNumber).HasMaxLength(20);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.ContractorProposedDisposition).HasMaxLength(100);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DispositionSubmittedBy).HasMaxLength(200);

                entity.Property(e => e.DispositionSubmittedDate).HasColumnType("datetime");

                entity.Property(e => e.DrawingReferenceNumber).HasMaxLength(20);

                entity.Property(e => e.IssuedBy).HasMaxLength(100);

                entity.Property(e => e.IssuedDate).HasColumnType("datetime");

                entity.Property(e => e.Item).HasMaxLength(200);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ReportNumber).HasMaxLength(20);

                entity.Property(e => e.ResponseDate).HasColumnType("datetime");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.SystemsSubSystems).HasMaxLength(100);

                entity.Property(e => e.TagNumber).HasMaxLength(20);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblSrnonConformanceReports)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_tbl_SRNonConformanceReports_tbl_City");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblSrnonConformanceReports)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tbl_SRNonConformanceReports_tbl_Country");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblSrnonConformanceReports)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_tbl_SRNonConformanceReports_tbl_Projects");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TblSrnonConformanceReports)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_tbl_SRNonConformanceReports_tbl_State");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblSrnonConformanceReports)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_SRNonConformanceReports_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblStaffBioData>(entity =>
            {
                entity.HasKey(e => e.StaffId);

                entity.ToTable("tbl_StaffBioData");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.AspnetUserId)
                    .HasColumnName("ASPNetUserID")
                    .HasMaxLength(450);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.OfficeEmailAddress).HasMaxLength(100);

                entity.Property(e => e.OfficePhoneNumber).HasMaxLength(50);

                entity.Property(e => e.OtherName).HasMaxLength(50);

                entity.Property(e => e.PersonalEmailAddress).HasMaxLength(100);

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.ProfileImage).HasMaxLength(100);

                entity.Property(e => e.StaffNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TelephoneNumber).HasMaxLength(50);

                entity.HasOne(d => d.AspnetUser)
                    .WithMany(p => p.TblStaffBioData)
                    .HasForeignKey(d => d.AspnetUserId)
                    .HasConstraintName("FK_tbl_StaffBioData_AspNetUsers");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblStaffBioData)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_tbl_StaffBioData_tbl_City");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TblStaffBioData)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_tbl_StaffBioData_tbl_CompanyInfo");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblStaffBioData)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tbl_StaffBioData_tbl_Country");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblStaffBioData)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_tbl_StaffBioData_tbl_Departments");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.TblStaffBioData)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_tbl_StaffBioData_tbl_Position");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TblStaffBioData)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_tbl_StaffBioData_tbl_State");
            });

            modelBuilder.Entity<TblStaffRoles>(entity =>
            {
                entity.HasKey(e => e.StaffRoleId);

                entity.ToTable("tbl_StaffRoles");

                entity.Property(e => e.StaffRoleId).HasColumnName("StaffRoleID");

                entity.Property(e => e.AuthoriserId).HasColumnName("AuthoriserID");

                entity.Property(e => e.CheckerId).HasColumnName("CheckerID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.WfdefId).HasColumnName("WFDefID");

                entity.HasOne(d => d.Authoriser)
                    .WithMany(p => p.TblStaffRolesAuthoriser)
                    .HasForeignKey(d => d.AuthoriserId)
                    .HasConstraintName("FK_tbl_StaffRoles_tbl_StaffBioDataAuthoriser");

                entity.HasOne(d => d.Checker)
                    .WithMany(p => p.TblStaffRolesChecker)
                    .HasForeignKey(d => d.CheckerId)
                    .HasConstraintName("FK_tbl_StaffRoles_tbl_StaffBioDataChecker");

                entity.HasOne(d => d.Wfdef)
                    .WithMany(p => p.TblStaffRoles)
                    .HasForeignKey(d => d.WfdefId)
                    .HasConstraintName("FK_tbl_StaffRoles_tbl_WorkflowProcessDef");
            });

            modelBuilder.Entity<TblStaffStrengthComp>(entity =>
            {
                entity.HasKey(e => e.StaffStrCompId);

                entity.ToTable("tbl_StaffStrengthComp");

                entity.Property(e => e.StaffStrCompId).HasColumnName("StaffStrCompID");

                entity.Property(e => e.Audit3rdParty).HasMaxLength(100);

                entity.Property(e => e.StaffPolicy).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblStaffStrengthComp)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_StaffStrengthComp_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblState>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("tbl_State");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblSubCategory>(entity =>
            {
                entity.HasKey(e => e.SubCategoryId);

                entity.ToTable("tbl_SubCategory");

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblSubContractedDetails>(entity =>
            {
                entity.HasKey(e => e.SubConId);

                entity.ToTable("tbl_SubContractedDetails");

                entity.Property(e => e.SubConId).HasColumnName("SubConID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.SubConAddress).HasMaxLength(500);

                entity.Property(e => e.SubConName).HasMaxLength(500);

                entity.Property(e => e.SubServId).HasColumnName("SubServID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblSubContractedDetails)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tbl_SubContractedDetails_tbl_Country");

                entity.HasOne(d => d.SubServ)
                    .WithMany(p => p.TblSubContractedDetails)
                    .HasForeignKey(d => d.SubServId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SubContractedDetails_tbl_SubContractedServices");
            });

            modelBuilder.Entity<TblSubContractedServices>(entity =>
            {
                entity.HasKey(e => e.SubServId);

                entity.ToTable("tbl_SubContractedServices");

                entity.Property(e => e.SubServId).HasColumnName("SubServID");

                entity.Property(e => e.PercentageOutsourced).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TblSubContractedServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK_tbl_SubContractedServices_tbl_Services");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblSubContractedServices)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_SubContractedServices_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblSubsidiaryCompany>(entity =>
            {
                entity.HasKey(e => e.SubsidiaryId);

                entity.ToTable("tbl_SubsidiaryCompany");

                entity.Property(e => e.SubsidiaryId).HasColumnName("SubsidiaryID");

                entity.Property(e => e.SubsidiaryCompanyName).HasMaxLength(500);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblSubsidiaryCompany)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SubsidiaryCompany_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblSupplierIdentification>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.ToTable("tbl_SupplierIdentification");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.BankReference)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CatSpecId).HasColumnName("CatSpecID");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CompanyProfile)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CompanyRegNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CompanyWebsiteUrl)
                    .HasColumnName("CompanyWebsiteURL")
                    .HasMaxLength(100);

                entity.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");

                entity.Property(e => e.CorporateAffairsCommisionNo).HasMaxLength(20);

                entity.Property(e => e.DprcatId).HasColumnName("DPRCatID");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.HeadOfficeAddress)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ProdCatId).HasColumnName("ProdCatID");

                entity.Property(e => e.ProdServId).HasColumnName("ProdServID");

                entity.Property(e => e.ServCatId).HasColumnName("ServCatID");

                entity.Property(e => e.TaxClearanceCertificate)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ThirdPartyReference)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TprId).HasColumnName("TPR_ID");

                entity.HasOne(d => d.CatSpec)
                    .WithMany(p => p.TblSupplierIdentification)
                    .HasForeignKey(d => d.CatSpecId)
                    .HasConstraintName("FK_tbl_SupplierIdentification_tbl_CategorySpecialization");

                entity.HasOne(d => d.ContactPerson)
                    .WithMany(p => p.TblSupplierIdentification)
                    .HasForeignKey(d => d.ContactPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SupplierIdentification_tbl_ContactPersons");

                entity.HasOne(d => d.Dprcat)
                    .WithMany(p => p.TblSupplierIdentification)
                    .HasForeignKey(d => d.DprcatId)
                    .HasConstraintName("FK_tbl_DPRCategory_tbl_SupplierIdentification");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.TblSupplierIdentification)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SupplierIdentification_tbl_FormIdentification");

                entity.HasOne(d => d.ProdCat)
                    .WithMany(p => p.TblSupplierIdentification)
                    .HasForeignKey(d => d.ProdCatId)
                    .HasConstraintName("FK_tbl_SupplierIdentification_tbl_ProductCategory");

                entity.HasOne(d => d.ProdServ)
                    .WithMany(p => p.TblSupplierIdentification)
                    .HasForeignKey(d => d.ProdServId)
                    .HasConstraintName("FK_tbl_SupplierIdentification_tbl_ProductServiceCategory");

                entity.HasOne(d => d.ServCat)
                    .WithMany(p => p.TblSupplierIdentification)
                    .HasForeignKey(d => d.ServCatId)
                    .HasConstraintName("FK_tbl_SupplierIdentification_tbl_ServicesCategory");

                entity.HasOne(d => d.Tpr)
                    .WithMany(p => p.TblSupplierIdentification)
                    .HasForeignKey(d => d.TprId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SupplierIdentification_tbl_ThirdPartyReference");
            });

            modelBuilder.Entity<TblSupplierOwnership>(entity =>
            {
                entity.HasKey(e => e.OwnershipId);

                entity.ToTable("tbl_SupplierOwnership");

                entity.Property(e => e.OwnershipId).HasColumnName("OwnershipID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.MainShareholder).HasMaxLength(500);

                entity.Property(e => e.Shareholding).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblSupplierOwnership)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tbl_SupplierOwnership_tbl_Country");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblSupplierOwnership)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SupplierOwnership_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblSupplierProfile>(entity =>
            {
                entity.HasKey(e => e.SupplierProfileId);

                entity.ToTable("tbl_SupplierProfile");

                entity.Property(e => e.SupplierProfileId).HasColumnName("SupplierProfileID");

                entity.Property(e => e.CodeofConduct).HasMaxLength(100);

                entity.Property(e => e.DateofCreation).HasColumnType("datetime");

                entity.Property(e => e.MissionVisionStatement).HasMaxLength(100);

                entity.Property(e => e.NatureOfBusiness).IsRequired();

                entity.Property(e => e.OrganizationCharts).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblSupplierProfile)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_SupplierProfile_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblTenderAttachements>(entity =>
            {
                entity.HasKey(e => e.TenderAttId);

                entity.ToTable("tbl_TenderAttachements");

                entity.Property(e => e.TenderAttId).HasColumnName("TenderAttID");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DocTypeId).HasColumnName("DocTypeID");

                entity.Property(e => e.DocumentTitle).HasMaxLength(200);

                entity.Property(e => e.DocumentUrl)
                    .HasColumnName("DocumentURL")
                    .HasMaxLength(200);

                entity.Property(e => e.ModifiedBy).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.QuoMasterId).HasColumnName("QuoMasterID");

                entity.HasOne(d => d.DocType)
                    .WithMany(p => p.TblTenderAttachements)
                    .HasForeignKey(d => d.DocTypeId)
                    .HasConstraintName("FK_tbl_TenderAttachements_tbl_DocumentType");

                entity.HasOne(d => d.QuoMaster)
                    .WithMany(p => p.TblTenderAttachements)
                    .HasForeignKey(d => d.QuoMasterId)
                    .HasConstraintName("FK_tbl_TenderAttachements_tbl_QuotationMaster");
            });

            modelBuilder.Entity<TblThirdPartyReference>(entity =>
            {
                entity.HasKey(e => e.TprId);

                entity.ToTable("tbl_ThirdPartyReference");

                entity.Property(e => e.TprId).HasColumnName("TPR_ID");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.TprAddress)
                    .HasColumnName("TPR_Address")
                    .HasMaxLength(500);

                entity.Property(e => e.TprEmailAddress)
                    .HasColumnName("TPR_EmailAddress")
                    .HasMaxLength(100);

                entity.Property(e => e.TprName)
                    .HasColumnName("TPR_Name")
                    .HasMaxLength(500);

                entity.Property(e => e.TprOrganization)
                    .HasColumnName("TPR_Organization")
                    .HasMaxLength(100);

                entity.Property(e => e.TprPhoneNumber)
                    .HasColumnName("TPR_PhoneNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.TprWorkPhoneNumber)
                    .HasColumnName("TPR_WorkPhoneNumber")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.TblThirdPartyReference)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_tbl_ThirdPartyReference_tbl_FormIdentification");
            });

            modelBuilder.Entity<TblTypicalSubcontractedScope>(entity =>
            {
                entity.HasKey(e => e.SubConScopeId);

                entity.ToTable("tbl_TypicalSubcontractedScope");

                entity.Property(e => e.SubConScopeId).HasColumnName("SubConScopeID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SubConAddress).HasMaxLength(500);

                entity.Property(e => e.SubConName).HasMaxLength(500);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblTypicalSubcontractedScope)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tbl_TypicalSubcontractedScope_tbl_Country");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblTypicalSubcontractedScope)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_tbl_TypicalSubcontractedScope_tbl_Products");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblTypicalSubcontractedScope)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_TypicalSubcontractedScope_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblValueDetails>(entity =>
            {
                entity.HasKey(e => e.ValueId);

                entity.ToTable("tbl_ValueDetails");

                entity.Property(e => e.ValueId).HasColumnName("ValueID");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblVendorProjectConsortium>(entity =>
            {
                entity.HasKey(e => e.VenProConId);

                entity.ToTable("tbl_VendorProjectConsortium");

                entity.Property(e => e.VenProConId).HasColumnName("VenProConID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectConsortiumAddress).HasMaxLength(500);

                entity.Property(e => e.ProjectConsortiumName).HasMaxLength(200);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblVendorProjectConsortium)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_tbl_VendorProjectConsortium_tbl_SupplierIdentification");
            });

            modelBuilder.Entity<TblVendorRegFormApproval>(entity =>
            {
                entity.HasKey(e => e.VendorApprovalId);

                entity.ToTable("tbl_VendorRegFormApproval");

                entity.Property(e => e.VendorApprovalId).HasColumnName("VendorApprovalID");

                entity.Property(e => e.AdforeignCompanyName)
                    .HasColumnName("ADForeignCompanyName")
                    .HasMaxLength(100);

                entity.Property(e => e.AdforeignCompanyOther).HasColumnName("ADForeignCompanyOther");

                entity.Property(e => e.AdforeignCompanyProductSupplied)
                    .HasColumnName("ADForeignCompanyProductSupplied")
                    .HasMaxLength(100);

                entity.Property(e => e.AdforeignCompanyStatus)
                    .HasColumnName("ADForeignCompanyStatus")
                    .HasMaxLength(20);

                entity.Property(e => e.ApprovedBy).HasMaxLength(200);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.BankReference).HasMaxLength(100);

                entity.Property(e => e.BusinessExCompanyWorkedWith).HasMaxLength(100);

                entity.Property(e => e.BusinessExContinuityPolicy).HasMaxLength(100);

                entity.Property(e => e.BusinessExHasContinuityPolicy).HasMaxLength(10);

                entity.Property(e => e.BusinessExRegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.BusinessExScopeCovered).HasMaxLength(500);

                entity.Property(e => e.BusinessExTimeFrame).HasMaxLength(10);

                entity.Property(e => e.BusinessExTransactionReference).HasMaxLength(100);

                entity.Property(e => e.CodeofConduct).HasMaxLength(100);

                entity.Property(e => e.CorporateDistinctives).HasMaxLength(200);

                entity.Property(e => e.CsrsocRespEthHumanLaborLaws)
                    .HasColumnName("CSRSocRespEthHumanLaborLaws")
                    .HasMaxLength(100);

                entity.Property(e => e.Cymfgffcity)
                    .HasColumnName("CYMFGFFCity")
                    .HasMaxLength(50);

                entity.Property(e => e.CymfgfffactoryArea)
                    .HasColumnName("CYMFGFFFactoryArea")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CymfgffplantEquipmentNumber).HasColumnName("CYMFGFFPlantEquipmentNumber");

                entity.Property(e => e.CymfgffplantEquipmentType)
                    .HasColumnName("CYMFGFFPlantEquipmentType")
                    .HasMaxLength(50);

                entity.Property(e => e.Cymfgffutilization)
                    .HasColumnName("CYMFGFFUtilization")
                    .HasMaxLength(100);

                entity.Property(e => e.DirectServiceScopeMaterials).HasMaxLength(100);

                entity.Property(e => e.DirectServiceScopeSubCategories).HasMaxLength(100);

                entity.Property(e => e.FinancialAuditorAddress).HasMaxLength(200);

                entity.Property(e => e.FinancialAuditorContactNumber).HasMaxLength(20);

                entity.Property(e => e.FinancialAuditorName).HasMaxLength(100);

                entity.Property(e => e.FinancialStatementTaxIdnumber)
                    .HasColumnName("FinancialStatementTaxIDNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.FinancialStatementYear1).HasMaxLength(100);

                entity.Property(e => e.FinancialStatementYear2).HasMaxLength(100);

                entity.Property(e => e.FinancialStatementYear3).HasMaxLength(100);

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.FormIdentificationDate).HasColumnType("datetime");

                entity.Property(e => e.FormIdentificationEmailAddress).HasMaxLength(100);

                entity.Property(e => e.FormIdentificationName).HasMaxLength(100);

                entity.Property(e => e.FormIdentificationPhoneNumber).HasMaxLength(20);

                entity.Property(e => e.FormIdentificationPosition).HasMaxLength(100);

                entity.Property(e => e.FormIdentificationWorkPhoneNumber).HasMaxLength(20);

                entity.Property(e => e.HealthSafetyEnvironmentPolicy).HasMaxLength(100);

                entity.Property(e => e.HsecertficationValidityDate)
                    .HasColumnName("HSECertficationValidityDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.HsecertificationCertAuthority)
                    .HasColumnName("HSECertificationCertAuthority")
                    .HasMaxLength(100);

                entity.Property(e => e.HsecertificationName)
                    .HasColumnName("HSECertificationName")
                    .HasMaxLength(100);

                entity.Property(e => e.HsecompanyKpi)
                    .HasColumnName("HSECompanyKPI")
                    .HasMaxLength(100);

                entity.Property(e => e.HsecompanyYearN1results)
                    .HasColumnName("HSECompanyYearN1Results")
                    .HasMaxLength(100);

                entity.Property(e => e.HsefaxNumber)
                    .HasColumnName("HSEFaxNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.HsemanagerEmail)
                    .HasColumnName("HSEManagerEmail")
                    .HasMaxLength(200);

                entity.Property(e => e.HsemanagerName)
                    .HasColumnName("HSEManagerName")
                    .HasMaxLength(100);

                entity.Property(e => e.HsephoneNumber)
                    .HasColumnName("HSEPhoneNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.HsestaffTrainingPolicy)
                    .HasColumnName("HSEStaffTrainingPolicy")
                    .HasMaxLength(100);

                entity.Property(e => e.HsethirdPartyAudit)
                    .HasColumnName("HSEThirdPartyAudit")
                    .HasMaxLength(100);

                entity.Property(e => e.HseworkPhoneNumber)
                    .HasColumnName("HSEWorkPhoneNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.IsListedStockMarket).HasMaxLength(10);

                entity.Property(e => e.KnowledgeofDgssystemsContractNo)
                    .HasColumnName("KnowledgeofDGSSystemsContractNo")
                    .HasMaxLength(50);

                entity.Property(e => e.KnowledgeofDgssystemsDgsref)
                    .HasColumnName("KnowledgeofDGSSystemsDGSRef")
                    .HasMaxLength(50);

                entity.Property(e => e.KnowledgeofDgssystemsProdEquServ)
                    .HasColumnName("KnowledgeofDGSSystemsProdEquServ")
                    .HasMaxLength(100);

                entity.Property(e => e.KnowledgeofDgssystemsStartDate)
                    .HasColumnName("KnowledgeofDGSSystemsStartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MainContactPersonEmail).HasMaxLength(50);

                entity.Property(e => e.MainContactPersonName).HasMaxLength(100);

                entity.Property(e => e.MainContactPersonPhone).HasMaxLength(20);

                entity.Property(e => e.MainContactPersonPosition).HasMaxLength(50);

                entity.Property(e => e.MainContactPersonWorkPhone).HasMaxLength(20);

                entity.Property(e => e.OwnershipMainShareholders).HasMaxLength(100);

                entity.Property(e => e.OwnershipNationality).HasMaxLength(50);

                entity.Property(e => e.PercentageShareholding).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductQualityManagement).HasMaxLength(100);

                entity.Property(e => e.QualityCertficationValidityDate).HasColumnType("datetime");

                entity.Property(e => e.QualityCertificationCertOrganization).HasMaxLength(100);

                entity.Property(e => e.QualityCertificationName).HasMaxLength(100);

                entity.Property(e => e.QualityManagement).HasMaxLength(100);

                entity.Property(e => e.QualityManagerEmail).HasMaxLength(200);

                entity.Property(e => e.QualityManagerFaxNumber).HasMaxLength(20);

                entity.Property(e => e.QualityManagerName).HasMaxLength(100);

                entity.Property(e => e.QualityManagerPhoneNumber).HasMaxLength(20);

                entity.Property(e => e.QualityManagerWorkPhoneNo).HasMaxLength(20);

                entity.Property(e => e.QualityPolicy).HasMaxLength(100);

                entity.Property(e => e.SpdirectServiceScopeService)
                    .HasColumnName("SPDirectServiceScopeService")
                    .HasMaxLength(100);

                entity.Property(e => e.SpdirectServiceScopeServiceDetails).HasColumnName("SPDirectServiceScopeServiceDetails");

                entity.Property(e => e.SpofficeServiceCenterCity)
                    .HasColumnName("SPOfficeServiceCenterCity")
                    .HasMaxLength(50);

                entity.Property(e => e.SpofficeServiceCenterCountry)
                    .HasColumnName("SPOfficeServiceCenterCountry")
                    .HasMaxLength(50);

                entity.Property(e => e.SpsubContractedServices)
                    .HasColumnName("SPSubContractedServices")
                    .HasMaxLength(100);

                entity.Property(e => e.SpsubContractedServicesPercOutsourced)
                    .HasColumnName("SPSubContractedServicesPercOutsourced")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SpsubContractorAddress)
                    .HasColumnName("SPSubContractorAddress")
                    .HasMaxLength(200);

                entity.Property(e => e.SpsubContractorIsLocal).HasColumnName("SPSubContractorIsLocal");

                entity.Property(e => e.SpsubContractorName)
                    .HasColumnName("SPSubContractorName")
                    .HasMaxLength(100);

                entity.Property(e => e.SpsubContractorNationality)
                    .HasColumnName("SPSubContractorNationality")
                    .HasMaxLength(50);

                entity.Property(e => e.StaffTrainingPolicy).HasMaxLength(100);

                entity.Property(e => e.StaffTrainingPolicyThirdPartyAudit).HasMaxLength(100);

                entity.Property(e => e.StockMarketInfo).HasMaxLength(100);

                entity.Property(e => e.SubsidiaryCompanyName).HasMaxLength(100);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.ThirdPartyRefContactNo).HasMaxLength(20);

                entity.Property(e => e.ThirdPartyRefEmail).HasMaxLength(50);

                entity.Property(e => e.ThirdPartyRefName).HasMaxLength(100);

                entity.Property(e => e.ThirdPartyRefOrgAddress).HasMaxLength(200);

                entity.Property(e => e.TypicalSubContractedScopeAddress).HasMaxLength(100);

                entity.Property(e => e.TypicalSubContractedScopeName).HasMaxLength(100);

                entity.Property(e => e.TypicalSubContractedScopeNationality).HasMaxLength(50);

                entity.Property(e => e.TypicalSubContractedScopeProducts).HasMaxLength(50);

                entity.Property(e => e.VendorCompanyDateofCreation).HasColumnType("datetime");

                entity.Property(e => e.VendorCompanyDepartment).HasMaxLength(100);

                entity.Property(e => e.VendorCompanyName).HasMaxLength(100);

                entity.Property(e => e.VendorCompanyProfile).HasMaxLength(100);

                entity.Property(e => e.VendorCompanyRegistrationNumber).HasMaxLength(20);

                entity.Property(e => e.VendorCompanyWebsiteAddress).HasMaxLength(50);

                entity.Property(e => e.VendorCorporateAffairsCommisionNo).HasMaxLength(20);

                entity.Property(e => e.VendorFraudMalpracticePolicy).HasMaxLength(100);

                entity.Property(e => e.VendorHeadOfficeAddress).HasMaxLength(200);

                entity.Property(e => e.VendorMainCustomerCountry).HasMaxLength(50);

                entity.Property(e => e.VendorMainCustomerName).HasMaxLength(100);

                entity.Property(e => e.VendorMainCustomerValue).HasMaxLength(50);

                entity.Property(e => e.VendorMissionVisionStatement).HasMaxLength(100);

                entity.Property(e => e.VendorNatureofBusiness).HasMaxLength(500);

                entity.Property(e => e.VendorOrganizationChart).HasMaxLength(100);

                entity.Property(e => e.VendorThirdPartySocialAudit).HasMaxLength(100);

                entity.Property(e => e.VendorUsername).HasMaxLength(100);
            });

            modelBuilder.Entity<TblWorkflowProcessDef>(entity =>
            {
                entity.HasKey(e => e.WfdefId);

                entity.ToTable("tbl_WorkflowProcessDef");

                entity.Property(e => e.WfdefId).HasColumnName("WFDefID");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
