namespace HrProject.UI.Areas.Admin.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
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
        public string Adres { get; set; }
        public string Email { get; set; }
        public int CalisanSayisi { get; set; }
        public DateTime KurulusTarihi { get; set; }
        public DateTime SozlesmeBaslangicTarihi { get; set; }
        public DateTime SozlesmeBitisTarihi { get; set; }
        public bool AktiflikDurumu { get; set; }

    }
}
