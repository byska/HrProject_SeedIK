using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.DTOs.DTOs
{
    public class CompanyDTO
    {
        public string CompanyName { get; set; }
        public string Unvan { get; set; }
        public string MersisNo { get; set; }
        public string VergiNo { get; set; }
        public string LogoImage { get; set; }
        public string TelefonNo { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public int CalisanSayisi { get; set; }
        public DateTime KurulusTarihi { get; set; }
        public DateTime SozlesmeBaslangicTarihi { get; set; }
        public DateTime SozlesmeBitisTarihi { get; set; }
        public bool AktiflikDurumu { get; set; }
    }
}
