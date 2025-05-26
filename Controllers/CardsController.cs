using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroAPI.Data;  
using SuperheroAPI.Entites; 

namespace SuperheroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly CardsDbContext _context;

        public CardsController(CardsDbContext context)
        {
            _context = context;
        }

        // GET: api/cards
        [HttpGet]
        public async Task<ActionResult<List<Card>>> GetAllCards()
        {
            var cards = await _context.Cards.ToListAsync();
            return Ok(cards);
        }

        // GET: api/cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(long id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
                return NotFound("Card not found");

            return Ok(card);
        }

        // POST: api/cards
        [HttpPost]
        public async Task<ActionResult<List<Card>>> AddCard(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cards.ToListAsync());
        }

        // PUT: api/cards
        [HttpPut]
        public async Task<ActionResult<List<Card>>> UpdateCard(Card updatedCard)
        {
            var dbCard = await _context.Cards.FindAsync(updatedCard.Id);
            if (dbCard == null)
                return NotFound("Card not found");

            // قم بتحديث الخصائص
            dbCard.CardNumber = updatedCard.CardNumber;
            dbCard.MaskCardNumber = updatedCard.MaskCardNumber;
            dbCard.AccountNumber = updatedCard.AccountNumber;
            dbCard.ProductId = updatedCard.ProductId;
            dbCard.IsActive = updatedCard.IsActive;
            dbCard.IsExpired = updatedCard.IsExpired;
            dbCard.ExpireDate = updatedCard.ExpireDate;
            dbCard.IsReplaced = updatedCard.IsReplaced;
            dbCard.ReplacedAt = updatedCard.ReplacedAt;
            dbCard.CreationDate = updatedCard.CreationDate;
            dbCard.NationalNumber = updatedCard.NationalNumber;
            dbCard.CurrentThirdPartyStatus = updatedCard.CurrentThirdPartyStatus;

            await _context.SaveChangesAsync();

            return Ok(await _context.Cards.ToListAsync());
        }

        // DELETE: api/cards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Card>>> DeleteCard(long id)
        {
            var dbCard = await _context.Cards.FindAsync(id);
            if (dbCard == null)
                return NotFound("Card not found");

            _context.Cards.Remove(dbCard);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cards.ToListAsync());
        }

        // GET: api/cards/search?cardNumber=123456&accountNumber=abc123&nationalNumber=987654
        [HttpGet("search")]
        public async Task<ActionResult<List<Card>>> SearchCards(
            [FromQuery] string? cardNumber,
            [FromQuery] string? accountNumber,
            [FromQuery] string? nationalNumber)
        {
            var query = _context.Cards.AsQueryable();

            if (!string.IsNullOrEmpty(cardNumber))
                query = query.Where(c => c.CardNumber == cardNumber);

            if (!string.IsNullOrEmpty(accountNumber))
                query = query.Where(c => c.AccountNumber == accountNumber);

            if (!string.IsNullOrEmpty(nationalNumber))
                query = query.Where(c => c.NationalNumber == nationalNumber);

            var results = await query.ToListAsync();

            if (results.Count == 0)
                return NotFound("No matching cards found.");

            return Ok(results);
        }

    }
}

