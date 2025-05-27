namespace SuperheroAPI.DOTs
{
    public class CardDto
    {
        public int Id { get; set; }
        public string MaskCardNumber { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string NationalNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
