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
    public class AllowanceWorkingProfileManagementConfiguration : IEntityTypeConfiguration<AllowanceWorkingProfileManagement>
    {
        public void Configure(EntityTypeBuilder<AllowanceWorkingProfileManagement> builder)
        {
            builder
             .HasOne<Allowance>()
             .WithMany()
             .HasForeignKey(awm => awm.AllownaceId);

            builder
                .HasOne<WorkingProfile>()
                .WithMany()
                .HasForeignKey(awm => awm.WorkingProfileId);

        }
    }
}
