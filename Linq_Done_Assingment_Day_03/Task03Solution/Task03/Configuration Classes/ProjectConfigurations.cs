using Task03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03.Configuration_Classes
{
    internal class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            // Id → PK with identity (10,10)
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                   .UseIdentityColumn(seed: 10, increment: 10);

            // Name → varchar(50), required, default “OurProject”
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasColumnType("varchar")
                   .HasMaxLength(50)
                   .HasDefaultValue("OurProject");

            // Cost → Money datatype
            builder.Property(p => p.Cost)
                   .HasColumnType("money");

            // Range constraint for cost
            builder.HasCheckConstraint("CK_Project_Cost_Range",
                "Cost BETWEEN 500000 AND 3500000");
        }
    }
}
