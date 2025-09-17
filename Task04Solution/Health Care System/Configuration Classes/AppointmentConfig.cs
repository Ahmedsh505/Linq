using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Health_Care_System.Models;

namespace Health_Care_System.Configuration_Classes
{
    public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Date).IsRequired();

            builder.HasOne(a => a.Patient)
                   .WithMany()
                   .HasForeignKey(a => a.PatientId);

            builder.HasOne(a => a.Doctor)
                   .WithMany()
                   .HasForeignKey(a => a.DoctorId);
        }
    }
}
