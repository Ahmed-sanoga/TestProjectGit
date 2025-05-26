using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroAPI.Data;
using SuperheroAPI.Entites;

namespace SuperheroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillainController : ControllerBase
    {
        private readonly DataContext _context;

        public VillainController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Villain>>> GetAllVillains()
        {
            return Ok(await _context.Villains.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Villain>> GetVillain(int id)
        {
            var villain = await _context.Villains.FindAsync(id);
            if (villain == null)
                return NotFound("Villain not found");

            return Ok(villain);
        }

        [HttpPost]
        public async Task<ActionResult<List<Villain>>> AddVillain(Villain villain)
        {
            _context.Villains.Add(villain);
            await _context.SaveChangesAsync();
            return Ok(await _context.Villains.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Villain>>> UpdateVillain(Villain updatedVillain)
        {
            var dbVillain = await _context.Villains.FindAsync(updatedVillain.Id);
            if (dbVillain == null)
                return NotFound("Villain not found");

            dbVillain.Name = updatedVillain.Name;
            dbVillain.Power = updatedVillain.Power;
            dbVillain.Weakness = updatedVillain.Weakness;

            await _context.SaveChangesAsync();
            return Ok(await _context.Villains.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Villain>>> DeleteVillain(int id)
        {
            var dbVillain = await _context.Villains.FindAsync(id);
            if (dbVillain == null)
                return NotFound("Villain not found");

            _context.Villains.Remove(dbVillain);
            await _context.SaveChangesAsync();
            return Ok(await _context.Villains.ToListAsync());
        }
    }
}
