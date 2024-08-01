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
    public class LeaveWorkingProfileManagementConfiguration : IEntityTypeConfiguration<LeaveWorkingProfileManagement>
    {
        public void Configure(EntityTypeBuilder<LeaveWorkingProfileManagement> builder)
        {
            builder
              .HasOne<Leave>()
              .WithMany()
              .HasForeignKey(lwm => lwm.LeaveId);

            builder
                .HasOne<WorkingProfile>()
                .WithMany()
                .HasForeignKey(lwm => lwm.WorkingProfileId);
        }
    }
}
