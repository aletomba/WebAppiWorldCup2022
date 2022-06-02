using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppiWorldCup2022.Data;
using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.Models.ViewModels;

namespace WebAppiWorldCup2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly Fixture_WorldCupContext _context;
        private readonly IMapper _mapper;
        public PlayersController(Fixture_WorldCupContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayer()
        {
          if (_context.Player == null)
          {
              return NotFound();
          }
            return await _context.Player.ToListAsync();
        }

  
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
          if (_context.Player == null)
          {
              return NotFound();
          }
            var player = await _context.Player.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Player player)
        {
            if (id != player.IdPlayer)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

       
        [HttpPost]
        public async Task<ActionResult<PersonCreateViewModel>> PostPlayer(PersonCreateViewModel createViewModel)
        {
          if (_context.Player == null)
          {
              return Problem("Entity set 'Fixture_WorldCupContext.Player'  is null.");
          }
          var Player = _context.Player.Include(x => x.IdPersonNavigation).ToListAsync();
          var CreatePlayer = _mapper.Map<Player>(Player);
            _context.Player.Add(CreatePlayer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = CreatePlayer.IdPlayer }, CreatePlayer);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            if (_context.Player == null)
            {
                return NotFound();
            }
            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Player.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerExists(int id)
        {
            return (_context.Player?.Any(e => e.IdPlayer == id)).GetValueOrDefault();
        }
    }
}
