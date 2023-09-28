using HrProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.DataAccess.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).UseIdentityColumn();
            builder.Property(x=> x.FirstName).HasMaxLength(50);
            builder.Property(x=> x.SecondFirstName).HasMaxLength(50);
            builder.Property(x=> x.LastName).HasMaxLength(50);
            builder.Property(x=> x.SecondFirstName).HasMaxLength(50);
            builder.Property(x => x.TC).IsFixedLength().HasMaxLength(11);
            builder.Property(x=> x.Address).HasMaxLength(100);


            builder.HasOne(x => x.Job).WithMany(x => x.AppUsers).HasForeignKey(x => x.JobID);

            builder.HasOne(x => x.Department).WithMany(x => x.AppUsers).HasForeignKey(x => x.DepartmentID);

            builder.HasOne(x => x.Company).WithMany(x => x.AppUsers).HasForeignKey(x => x.CompanyID);

            //builder.HasMany(x => x.Permissions).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserID);

            //builder.HasMany(x => x.Expenses).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserID);

            //builder.HasMany(x => x.AdvancePayments).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserID);
        }
    }
}
