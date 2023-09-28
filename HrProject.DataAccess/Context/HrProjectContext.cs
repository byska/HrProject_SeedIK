using HrProject.DataAccess.Configurations;
using HrProject.Entities.Entities;
using HrProject.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.DataAccess.Context
{
    public class HrProjectContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionType { get; set; }
        public DbSet<AdvancePayment> AdvancePayments { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        
        public HrProjectContext(DbContextOptions<HrProjectContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AdvancePaymentConfiguration()).ApplyConfiguration(new ExpenseConfiguration()).ApplyConfiguration(new EmployeeConfiguration()).ApplyConfiguration(new PermissionConfiguration());

            builder.Entity<Job>().HasData(
                new Job() { Id = 1, IsActive = true, JobName = "Yazılım Mühendisi" },
                new Job() { Id = 2, IsActive = true, JobName = "Veri Bilimci" },
                 new Job() { Id = 3, IsActive = true, JobName = "Yönetici" }
                );
            builder.Entity<Company>().HasData(
                new Company() { Id = 1, IsActive = true, CompanyName = "Yasak Holding", Adres = "Altunizade Sokak No : 5 ", AktiflikDurumu = true,CalisanSayisi = 10,SozlesmeBaslangicTarihi = new DateTime(1998, 02, 16),SozlesmeBitisTarihi = new DateTime(2040, 02, 16) ,KurulusTarihi = new DateTime(1990, 02, 16), TelefonNo = "08508505050", VergiNo = "1240120512", Email = "holdingyasak@hotmail.com", MersisNo = "a001950190191534", Unvan = "YASSAK", LogoImage = "dglaşsgas"},
                new Company() { Id = 2, IsActive = true, CompanyName = "Bilge Adam", Adres = "Altunizade Sokak No : 5 ", AktiflikDurumu = true, CalisanSayisi = 10, SozlesmeBaslangicTarihi = new DateTime(1998, 02, 16), SozlesmeBitisTarihi = new DateTime(2040, 02, 16), KurulusTarihi = new DateTime(1990, 02, 16), TelefonNo = "08508505050", VergiNo = "1240120512", Email = "holdingyasak@hotmail.com", MersisNo = "a001950190191565", Unvan = "YASSAK", LogoImage = "dglaşsgas" }
                );
            builder.Entity<Department>().HasData(
                new Department() { Id = 1, IsActive = true, DepartmentName = "Yönetim" },
                new Department() { Id = 2, IsActive = true, DepartmentName = "Web" },
                new Department() { Id = 3, IsActive = true, DepartmentName = "Ar-Ge" }
                );
            builder.Entity<AppRole>().HasData(
                new AppRole() { Id = 1, IsActive = true, Name = "Çalışan" }
                );
            builder.Entity<AppUser>().HasData(
                new AppUser() { Id = 1, JobID = 1, CompanyID = 1, DepartmentID = 2, EmployeeImage = "", FirstName = "Beste", LastName = "Yasak", Email = "besteyasak@bilgeadamboost.com", BirthDate = new DateTime(1998, 02, 16), BirthPlace = "Sakarya", TC = "651466416", StartDate = new DateTime(2010, 10, 19), Address = "Altunizade", Salary = 60000, IsActive = true, Gender = Gender.Female },
                   new AppUser() { Id = 2, JobID = 2, CompanyID = 2, DepartmentID = 3, EmployeeImage = "", FirstName = "Alp", LastName = "Irmak", Email = "anilirmak@bilgeadamboost.com", BirthDate = new DateTime(1980, 07, 01), StartDate = new DateTime(2020, 01, 25), BirthPlace = "Antalya", TC = "2737373", Address = "Beşiktaş", Salary = 20000, IsActive = true, Gender = Gender.Male }
                );
            builder.Entity<PermissionType>().HasData(
                new PermissionType() { Id = 1, IsActive = true, PermissionName = "Yıllık İzin < 1", PermissionDay = 0, IsFileRequired = false, Gender = Gender.All },
                 new PermissionType() { Id = 2, IsActive = true, PermissionName = "Yıllık İzin < 5", PermissionDay = 14, IsFileRequired = false, Gender = Gender.All },
                  new PermissionType() { Id = 3, IsActive = true, PermissionName = "Yıllık İzin > 5", PermissionDay = 20, IsFileRequired = false, Gender = Gender.All },
                   new PermissionType() { Id = 4, IsActive = true, PermissionName = "Mazeret", PermissionDay = 20, IsFileRequired = true, Gender = Gender.All },
                    new PermissionType() { Id = 5, IsActive = true, PermissionName = "Annelik", PermissionDay = 32, IsFileRequired = true, Gender = Gender.Female },
                     new PermissionType() { Id = 6, IsActive = true, PermissionName = "Babalık İzni", PermissionDay = 5, IsFileRequired = true, Gender = Gender.Male },
                      new PermissionType() { Id = 7, IsActive = true, PermissionName = "Ölüm İzni", PermissionDay = 3, IsFileRequired = true, Gender = Gender.All }
                );
            builder.Entity<Permission>().HasData(
                new Permission() { Id = 1, AppUserID = 1, TypeId = 6, IsActive = true, StartDate = new DateTime(2023, 08, 20), EndDate = new DateTime(2023, 08, 25), Status = Status.Confirm, File = "" },
                new Permission() { Id = 2, AppUserID = 1, TypeId = 4, IsActive = true, StartDate = new DateTime(2023, 07, 26), EndDate = new DateTime(2023, 07, 17), Status = Status.Denied, File = "" },
                new Permission() { Id = 3, AppUserID = 1, TypeId = 5, IsActive = true, StartDate = new DateTime(2023, 08, 13), EndDate = new DateTime(2023, 10, 13), Status = Status.Pending, File = "" },
                new Permission() { Id = 4, AppUserID = 2, TypeId = 7, IsActive = true, StartDate = new DateTime(2023, 08, 20), EndDate = new DateTime(2023, 08, 25), Status = Status.Confirm, File = "" },
                new Permission() { Id = 5, AppUserID = 2, TypeId = 7, IsActive = true, StartDate = new DateTime(2023, 06, 18), EndDate = new DateTime(2023, 06, 21), Status = Status.Confirm, File = "" },
                new Permission() { Id = 6, AppUserID = 1, TypeId = 2, IsActive = true, StartDate = new DateTime(2023, 07, 15), EndDate = new DateTime(2023, 07, 25), Status = Status.Denied },
                new Permission() { Id = 7, AppUserID = 2, TypeId = 3, IsActive = true, StartDate = new DateTime(2023, 12, 24), EndDate = new DateTime(2023, 12, 29), Status = Status.Pending }
                );
            builder.Entity<AdvancePayment>().HasData(
                new AdvancePayment() { Id = 1, AppUserID = 1, IsActive = true, RequestDate = new DateTime(2023, 05, 20), Type = AdvancePaymentType.Personal, Status = Status.Confirm, Amount = 1500, Currency=Currency.TurkLirasi, Description = "ihtiyaç" },
                new AdvancePayment() { Id = 2, AppUserID = 2, IsActive = true, RequestDate = new DateTime(2023, 05, 18), Type = AdvancePaymentType.Personal, Status = Status.Denied, Amount = 15000, Currency = Currency.TurkLirasi, Description = "ihtiyaç" },
                new AdvancePayment() { Id = 3, AppUserID = 1, IsActive = true, Type = AdvancePaymentType.Personal, Status = Status.Pending, Amount = 1500, Currency = Currency.TurkLirasi, Description = "ihtiyaç" },
                new AdvancePayment() { Id = 4, AppUserID = 2, IsActive = true, RequestDate = new DateTime(2023, 05, 20), Type = AdvancePaymentType.Corporative, Status = Status.Confirm, Amount = 10000, Currency = Currency.Euro, Description = "Konaklama" },
                new AdvancePayment() { Id = 5, AppUserID = 1, IsActive = true, RequestDate = new DateTime(2023, 05, 15), Type = AdvancePaymentType.Corporative, Status = Status.Confirm, Amount = 2500, Currency = Currency.Dolar, Description = "seyahat" },
                new AdvancePayment() { Id = 6, AppUserID = 2, IsActive = true, Type = AdvancePaymentType.Corporative, Status = Status.Confirm, Amount = 500, Currency = Currency.TurkLirasi, Description = "ihtiyaç" }
                );
            builder.Entity<Expense>().HasData(
                new Expense() { Id = 1, AppUserID = 1,  IsActive = true, Type = ExpenseType.Trip, Currency = Currency.Dolar, Status = Status.Denied, Amount = 1500, ExpenseImage = "" },
                new Expense() { Id = 2, AppUserID = 1, IsActive = true, Type = ExpenseType.Accommodation, Currency = Currency.TurkLirasi, Status = Status.Pending, Amount = 2500, ExpenseImage = "" },
                new Expense() { Id = 3, AppUserID = 1, IsActive = true, Type = ExpenseType.FoodAndBeverage, Currency = Currency.Euro, Status = Status.Confirm, Amount = 500, ExpenseImage = "" },
                new Expense() { Id = 4, AppUserID = 2, IsActive = true, Type = ExpenseType.Trip, Currency = Currency.TurkLirasi, Status = Status.Confirm, Amount = 500, ExpenseImage = "" },
                new Expense() { Id = 5, AppUserID = 2, IsActive = true, Type = ExpenseType.Accommodation, Currency = Currency.Euro, Status = Status.Denied, RequestDate = new DateTime(2023, 05, 15), Amount = 200, ExpenseImage = "" }
                );
        }
        //public int PermissionDay(AppUser user)
        //{
        //    if (DateTime.Now.Year - user.StartDate.Year < 5 && 1 < DateTime.Now.Year - user.StartDate.Year)
        //    { return 14; }
        //    else if (DateTime.Now.Year - user.StartDate.Year > 5)
        //    { return 20; }
        //    else { return 0; }
        //}
    }
}
