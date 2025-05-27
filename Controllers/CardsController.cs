using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroAPI.Data;  
using SuperheroAPI.Entites;
using SuperheroAPI.Repositories;
using SuperheroAPI.DOTs;


namespace SuperheroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly CardsDbContext _context;
        private readonly ICardsRepositories _repository;
        private readonly IMapper _mapper;

        public CardsController( ICardsRepositories repository ,IMapper mapper)
        {
           
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/cards
        [HttpGet]
        public async Task<ActionResult<List<CardDto>>> GetAllCards()
        {
            var cards = await _repository.GetCardsAsync();
            var cardDtos = _mapper.Map<List<CardDto>>(cards);
            return Ok(cardDtos);
        }

        // GET: api/cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            var card = await _repository.GetByIdAsync(id); 
            var carddto = _mapper.Map<CardDto>(card);
            if (card == null)
                return NotFound("Card not found");

            return Ok(carddto);
        }

        // POST: api/cards
        [HttpPost]
        public async Task<ActionResult<List<Card>>> AddCard(Card card)
        {
            await _repository.AddAsync(card);
      

            return Ok(await _repository.GetCardsAsync());
        }

        // PUT: api/cards
        [HttpPut]
        public async Task<ActionResult<List<Card>>> UpdateCard(Card updatedCard)
        {
            var dbCard = await _repository.GetByIdAsync(updatedCard.Id);
            if (dbCard == null)
                return NotFound("Card not found");

            // تحديث الخصائص
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

            await _repository.UpdateAsync(dbCard); // مهم جدًا

            return Ok(await _repository.GetCardsAsync());
        }

        // DELETE: api/cards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Card>>> DeleteCard(long id)
        {
            var dbCard = await _context.Cards.FindAsync(id);
            if (dbCard == null)
                return NotFound("Card not found");

            _context.Cards.Remove(dbCard);
        

            return Ok(await _context.Cards.ToListAsync());
        }

        // GET: api/cards/search?cardNumber=123456&accountNumber=abc123&nationalNumber=987654
        [HttpGet("search")]
        public async Task<ActionResult<List<Card>>> SearchCards(
    [FromQuery] string? cardNumber,
    [FromQuery] string? accountNumber,
    [FromQuery] string? nationalNumber)
        {
            var results = await _repository.SearchAsync(cardNumber, accountNumber, nationalNumber);

            if (results.Count == 0)
                return NotFound("No matching cards found.");

            return Ok(results);
        }

    }
}

