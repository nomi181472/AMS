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
    public class WorkingProfileConfiguration : IEntityTypeConfiguration<WorkingProfile>
    {
        public void Configure(EntityTypeBuilder<WorkingProfile> builder)
        {
            builder
                .HasOne<FiscalYear>()
                .WithMany()
                .HasForeignKey(wp => wp.FiscalYearId);
        }
    }
}
