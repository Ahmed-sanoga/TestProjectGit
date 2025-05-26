using Microsoft.AspNetCore.Mvc;
using SuperheroAPI.DTOs;
using SuperheroAPI.Entites;
using SuperheroAPI.Repositories;
using AutoMapper;

namespace SuperheroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperController : ControllerBase
    {
        private readonly ISuperheroRepository _repository;
        private readonly IMapper _mapper;

        public SuperController(ISuperheroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // ✅ Get All Heroes
        [HttpGet]
        public async Task<ActionResult<List<SuperheroDto>>> GetALLHeroes()
        {
            var heroes = await _repository.GetAllAsync();
            var heroDtos = _mapper.Map<List<SuperheroDto>>(heroes);
            return Ok(heroDtos);
        }

        // ✅ Get Hero by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperheroDto>> GetHero(int id)
        {
            var hero = await _repository.GetByIdAsync(id);
            if (hero == null)
                return NotFound("Hero not found");

            return Ok(_mapper.Map<SuperheroDto>(hero));
        }

        // ✅ Add Hero
        [HttpPost]
        public async Task<ActionResult> AddHero(CreateSuperheroDto dto)
        {
            var hero = _mapper.Map<Superhero>(dto);
            await _repository.AddAsync(hero);
            return Ok("Hero added successfully");
        }

        // ✅ Update Hero
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHero(int id, CreateSuperheroDto dto)
        {
            var hero = await _repository.GetByIdAsync(id);
            if (hero == null)
                return NotFound("Hero not found");

            _mapper.Map(dto, hero); // تحديث القيم من dto إلى الكائن الموجود

            await _repository.UpdateAsync(hero);
            return Ok("Hero updated successfully");
        }

        // ✅ Delete Hero
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHero(int id)
        {
            var hero = await _repository.GetByIdAsync(id);
            if (hero == null)
                return NotFound("Hero not found");

            await _repository.DeleteAsync(hero);
            return Ok("Hero deleted successfully");
        }
    }
}
