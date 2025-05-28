namespace SuperheroAPI.DOTs
{
    public class CardWithCustomerDto
    {
        public long Id { get; set; }
        public string CardNumber { get; set; }
        public string MaskCardNumber { get; set; }
        public string AccountNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ExpireDate { get; set; }

        public string CustomerName { get; set; }
    }
}
