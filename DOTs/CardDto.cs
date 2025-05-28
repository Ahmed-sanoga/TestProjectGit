using SuperheroAPI.Entites;

namespace SuperheroAPI.DOTs
{
    public class CardDto
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public int CustomerId { set; get; }
        public string MaskCardNumber { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string NationalNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime ExpireDate { get; set; }
        public string CustomerFullName { get; set; }

    }
    public class AddCardDto
    {
       
        public string CardNumber { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string NationalNumber { get; set; } = string.Empty;
        public int    CustomerId { set; get; }
        public int    ProductId { get; set; }
        public bool   IsActive { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
