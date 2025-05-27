namespace SuperheroAPI.Entites
{
    
    
        public class Card
        {
            public long Id { get; set; }

            public string CardNumber { get; set; }

            public string? MaskCardNumber { get; set; }

            public string AccountNumber { get; set; }

            public int ProductId { get; set; }

            public bool IsActive { get; set; }

            public bool IsExpired { get; set; }

            public DateTime? ExpireDate { get; set; }

            public bool IsReplaced { get; set; }

            public DateTime? ReplacedAt { get; set; }

            public DateTime CreationDate { get; set; }

            public string? NationalNumber { get; set; }

            public string? CurrentThirdPartyStatus { get; set; }
        
    }
    
}
