using Microsoft.EntityFrameworkCore;
using SuperheroAPI.Data;
using SuperheroAPI.Entites;
using SuperheroAPI.DOTs;
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
            return await _context.Cards.Include(c => c.Customer).ToListAsync();
        }
        public async Task<Card?> GetByIdAsync(long id)
        {
            return await _context.Cards.Include(c => c.Customer).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Card card)
        {
            _context.Cards.Add(new Card()
            {

                CardNumber =card.CardNumber,
                AccountNumber=card.AccountNumber,
                NationalNumber=card.NationalNumber,
                CustomerId = card.CustomerId,
                ProductId = card.ProductId,
                IsActive = card.IsActive
            }
                
                
                );
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
            return await _context.Cards
                .Include(c => c.Customer)
                .Where(c =>
                    (cardNumber == null || c.CardNumber.Contains(cardNumber)) &&
                    (accountNumber == null || c.AccountNumber.Contains(accountNumber)) &&
                    (nationalNumber == null || c.NationalNumber.Contains(nationalNumber)))
                .ToListAsync();
        }
    }
    }

