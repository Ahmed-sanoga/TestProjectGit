using Microsoft.EntityFrameworkCore;
using SuperheroAPI.Data;
using SuperheroAPI.Entites;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuperheroAPI.Repositories
{
    public class CardsRepsitories : ICardsRepositories
    {
        private readonly CardsDbContext _context;

        public CardsRepsitories(CardsDbContext context)
        {
            _context = context;
        }
        public async Task<List<Card>> GetCardsAsync()
        {
            return await _context.Cards.ToListAsync();
        }
        public async Task<Card> GetByIdAsync(long id)
        {

            return await _context.Cards.FindAsync(id);
        }
        public async Task AddAsync(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Card card)
        {
            _context.Cards.Update(card);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Card card)
        {
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Card>> SearchAsync(string? cardNumber, string? accountNumber, string? nationalNumber)
        {
            var query = _context.Cards.AsQueryable();

            if (!string.IsNullOrEmpty(cardNumber))
                query = query.Where(c => c.CardNumber == cardNumber);

            if (!string.IsNullOrEmpty(accountNumber))
                query = query.Where(c => c.AccountNumber == accountNumber);

            if (!string.IsNullOrEmpty(nationalNumber))
                query = query.Where(c => c.NationalNumber == nationalNumber);

            return await query.ToListAsync();
        }
    }
}
