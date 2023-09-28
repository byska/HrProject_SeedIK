using HrProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.DataAccess.Configurations
{
    public class AdvancePaymentConfiguration : IEntityTypeConfiguration<AdvancePayment>
    {
        public void Configure(EntityTypeBuilder<AdvancePayment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder.HasOne(x=>x.AppUser).WithMany(x=>x.AdvancePayments).HasForeignKey(x=>x.AppUserID);

        }
    }
}
