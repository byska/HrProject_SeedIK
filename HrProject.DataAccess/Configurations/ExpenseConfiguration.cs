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
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ExpenseImage).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne(x => x.AppUser).WithMany(x => x.Expenses).HasForeignKey(x => x.AppUserID);
        }
    }
}
