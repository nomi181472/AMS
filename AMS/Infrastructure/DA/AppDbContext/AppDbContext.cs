using DA.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DA.AppDbContexts
{
    public class AppDbContext:DbContext
    {
        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Deduction> Deductions { get; set; }
        public DbSet<ShiftDeductionScheduler> ShiftDeductionSchedulers { get; set; }
        public DbSet<AllowanceWorkingProfileManagement> AllowanceWorkingProfileManagements { get; set; }
        public DbSet<Leave> Leaves { get; set; }   
        public DbSet<LeaveWorkingProfileManagement> LeaveWorkingProfileManagements { get; set; }
        public DbSet<WorkingProfile> WorkingProfiles { get; set; }

        public DbSet<FiscalYear> FiscalYears { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}




