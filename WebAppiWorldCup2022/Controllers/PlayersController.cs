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
using WebAppiWorldCup2022.Services.PlayerServices;
using WebAppiWorldCup2022.ViewModels.PLayerViewModel;

namespace WebAppiWorldCup2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly Fixture_WorldCupContext _context;
        private readonly IMapper _mapper;
        private readonly IPLayerService _service;
        public PlayersController(Fixture_WorldCupContext context,IMapper mapper, IPLayerService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service; 
        }

      
        [HttpGet]
        public async Task<IEnumerable<PlayerView>> GetPlayer()
        {
            try
            {

                var player = await _service.GetPLayers();
                return _mapper.Map<IEnumerable<PlayerView>>(player);

            }
            catch (Exception)
            {
                return Enumerable.Empty<PlayerView>();
            }

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
        public async Task<ActionResult<CreateUpdatePLayer>> PostPlayer(CreateUpdatePLayer createPLayer) 
        {
            try
            {
               var player= await _service.CreatePlayer(createPLayer);
               return _mapper.Map<CreateUpdatePLayer>(player);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
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
