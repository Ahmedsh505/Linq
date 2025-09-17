using Library_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library_System.Configuration_Classes
{
    public class BorrowConfig : IEntityTypeConfiguration<Borrow>
    {
        public void Configure(EntityTypeBuilder<Borrow> builder)
        {
            builder.HasKey(br => br.Id);
            builder.Property(br => br.BorrowDate).IsRequired();

            builder.HasOne(br => br.Book)
                   .WithMany()
                   .HasForeignKey(br => br.BookId);

            builder.HasOne(br => br.Member)
                   .WithMany()
                   .HasForeignKey(br => br.MemberId);
        }
    }
}
