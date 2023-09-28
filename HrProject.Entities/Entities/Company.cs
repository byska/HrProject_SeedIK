using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Entities.Entities
{
    public class Company : BaseEntity
    {
        public Company()
        {
            AppUsers = new List<AppUser>();
            //Departments= new List<Department>();
            //Jobs= new List<Job>();
        }
        public string CompanyName { get; set; }
        //public virtual List<Job> Jobs { get; set; }
        //public virtual List<Department> Departments { get; set; }
        public virtual List<AppUser> AppUsers { get; set; }

        // Şirket bilgileri güncelleme

        public string Unvan { get; set; }

        private string _mersisNo;
        public string MersisNo
        {
            get { return _mersisNo; }
            set
            {
                if (value?.Length != 16)
                {
                    throw new ArgumentException("Mersis no 16 haneli olmalıdır.");
                }
                _mersisNo = value;
            }
        }

        private string _vergiNo;
        public string VergiNo
        {
            get { return _vergiNo; }
            set
            {
                if (value?.Length != 10)
                {
                    throw new ArgumentException("Vergi no 10 haneli olmalıdır.");
                }
                _vergiNo = value;
            }
        }
        public string LogoImage { get; set; }
        public string TelefonNo { get; set; }
        public string Adres { get; set;}
        public string Email { get; set;}
        public int CalisanSayisi { get; set; }
        public DateTime KurulusTarihi{ get; set; }
        public DateTime SozlesmeBaslangicTarihi{ get; set; }
        public DateTime SozlesmeBitisTarihi{ get; set; }
        public bool AktiflikDurumu{ get; set; }

    }
}
