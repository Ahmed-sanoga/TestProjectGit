namespace SuperheroAPI.Entites
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NationalNumber { get; set; }

        // علاقة واحد إلى متعدد
        public ICollection<Card> Cards { get; set; } 
    }
}
