using SuperheroAPI.DOTs;
using SuperheroAPI.Entites;

namespace SuperheroAPI.Repositories
{
    public interface ICardsRepositories
    {
        Task<List<Card>> GetCardsAsync();
        Task<Card> GetByIdAsync(long id);

        Task AddAsync(Card card);
        Task UpdateAsync(Card card);
        Task DeleteAsync(Card card);
        Task<List<Card>> SearchAsync(string? cardNumber, string? accountNumber, string? nationalNumber);
    }
}
