using DA.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models.DomainModelsConfigurations
{
    public class ShiftDeductionSchedulerConfiguration : IEntityTypeConfiguration<ShiftDeductionScheduler>
    {
        public void Configure(EntityTypeBuilder<ShiftDeductionScheduler> builder)
        {
            
            builder.HasOne(x => x.Shift).WithMany(x => x.Schedulers).HasForeignKey(x => x.ShiftId);
            builder.HasOne(x => x.Deduction).WithMany(x => x.Schedulers).HasForeignKey(x => x.DeductionId);
            builder.HasOne(x => x.WorkingProfile).WithMany(x => x.Schedulers).HasForeignKey(x => x.WorkingProfileId);
            
        }
    }
}
