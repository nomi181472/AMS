﻿// <auto-generated />
using System;
using DA.AppDbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DA.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240807093023_alterDeductionEntity")]
    partial class alterDeductionEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DA.Models.DomainModels.Allowance", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Allowances");
                });

            modelBuilder.Entity("DA.Models.DomainModels.AllowanceWorkingProfileManagement", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AllownaceId")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("WorkingProfileId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AllownaceId");

                    b.HasIndex("WorkingProfileId");

                    b.ToTable("AllowanceWorkingProfileManagements");
                });

            modelBuilder.Entity("DA.Models.DomainModels.Deduction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Deductions");
                });

            modelBuilder.Entity("DA.Models.DomainModels.DeductionRule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EndTime")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StartTime")
                        .HasColumnType("integer");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("DeductionRules");
                });

            modelBuilder.Entity("DA.Models.DomainModels.FiscalYear", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FiscalYears");
                });

            modelBuilder.Entity("DA.Models.DomainModels.Leave", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Leaves");
                });

            modelBuilder.Entity("DA.Models.DomainModels.LeaveWorkingProfileManagement", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<string>("LeaveId")
                        .HasColumnType("text");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("WorkingProfileId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LeaveId");

                    b.HasIndex("WorkingProfileId");

                    b.ToTable("LeaveWorkingProfileManagements");
                });

            modelBuilder.Entity("DA.Models.DomainModels.Shift", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<int>("NumDays")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<DateTime?>("TimeIn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("TimeOut")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("DA.Models.DomainModels.ShiftDeductionScheduler", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeductionId")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<string>("ShiftId")
                        .HasColumnType("text");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("WorkingProfileId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DeductionId");

                    b.HasIndex("ShiftId");

                    b.HasIndex("WorkingProfileId");

                    b.ToTable("ShiftDeductionSchedulers");
                });

            modelBuilder.Entity("DA.Models.DomainModels.WorkingProfile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("FiscalYearId")
                        .HasColumnType("text");

                    b.Property<int?>("GraceTimeIn")
                        .HasColumnType("integer");

                    b.Property<int?>("GraceTimeOut")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("WorkingDays")
                        .HasColumnType("integer");

                    b.Property<int?>("WorkingHours")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FiscalYearId");

                    b.ToTable("WorkingProfiles");
                });

            modelBuilder.Entity("DA.Models.DomainModels.AllowanceWorkingProfileManagement", b =>
                {
                    b.HasOne("DA.Models.DomainModels.Allowance", "Allowance")
                        .WithMany("AllowanceWorkingProfileManagements")
                        .HasForeignKey("AllownaceId");

                    b.HasOne("DA.Models.DomainModels.WorkingProfile", "WorkingProfile")
                        .WithMany("AllowanceWorkingProfileManagements")
                        .HasForeignKey("WorkingProfileId");

                    b.Navigation("Allowance");

                    b.Navigation("WorkingProfile");
                });

            modelBuilder.Entity("DA.Models.DomainModels.LeaveWorkingProfileManagement", b =>
                {
                    b.HasOne("DA.Models.DomainModels.Leave", "Leave")
                        .WithMany("LeaveWorkingProfileManagements")
                        .HasForeignKey("LeaveId");

                    b.HasOne("DA.Models.DomainModels.WorkingProfile", "WorkingProfile")
                        .WithMany("LeaveWorkingProfileManagements")
                        .HasForeignKey("WorkingProfileId");

                    b.Navigation("Leave");

                    b.Navigation("WorkingProfile");
                });

            modelBuilder.Entity("DA.Models.DomainModels.ShiftDeductionScheduler", b =>
                {
                    b.HasOne("DA.Models.DomainModels.Deduction", "Deduction")
                        .WithMany("ShiftDeductionScheduler")
                        .HasForeignKey("DeductionId");

                    b.HasOne("DA.Models.DomainModels.Shift", "Shift")
                        .WithMany("ShiftDeductionScheduler")
                        .HasForeignKey("ShiftId");

                    b.HasOne("DA.Models.DomainModels.WorkingProfile", "WorkingProfile")
                        .WithMany("ShiftDeductionScheduler")
                        .HasForeignKey("WorkingProfileId");

                    b.Navigation("Deduction");

                    b.Navigation("Shift");

                    b.Navigation("WorkingProfile");
                });

            modelBuilder.Entity("DA.Models.DomainModels.WorkingProfile", b =>
                {
                    b.HasOne("DA.Models.DomainModels.FiscalYear", "FiscalYear")
                        .WithMany("WorkingProfiles")
                        .HasForeignKey("FiscalYearId");

                    b.Navigation("FiscalYear");
                });

            modelBuilder.Entity("DA.Models.DomainModels.Allowance", b =>
                {
                    b.Navigation("AllowanceWorkingProfileManagements");
                });

            modelBuilder.Entity("DA.Models.DomainModels.Deduction", b =>
                {
                    b.Navigation("ShiftDeductionScheduler");
                });

            modelBuilder.Entity("DA.Models.DomainModels.FiscalYear", b =>
                {
                    b.Navigation("WorkingProfiles");
                });

            modelBuilder.Entity("DA.Models.DomainModels.Leave", b =>
                {
                    b.Navigation("LeaveWorkingProfileManagements");
                });

            modelBuilder.Entity("DA.Models.DomainModels.Shift", b =>
                {
                    b.Navigation("ShiftDeductionScheduler");
                });

            modelBuilder.Entity("DA.Models.DomainModels.WorkingProfile", b =>
                {
                    b.Navigation("AllowanceWorkingProfileManagements");

                    b.Navigation("LeaveWorkingProfileManagements");

                    b.Navigation("ShiftDeductionScheduler");
                });
#pragma warning restore 612, 618
        }
    }
}
