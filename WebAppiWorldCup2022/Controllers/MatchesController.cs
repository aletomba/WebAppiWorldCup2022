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
using WebAppiWorldCup2022.Models.ViewModels.MatchViewModels;
using WebAppiWorldCup2022.Services;

namespace WebAppiWorldCup2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {        
        private readonly Fixture_WorldCupContext _context;
        private readonly IMapper _mapper;
        private readonly ImatchService _service;
       
        public MatchesController(Fixture_WorldCupContext context, IMapper mapper, ImatchService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service; 
           
        }

     
        [HttpGet] //falta control de errores
        public async Task<IEnumerable<MatchViewModel>> GetMatch()
        {
            var match = await _service.GetMatch();
            return _mapper.Map<IEnumerable<MatchViewModel>>(match);
        }


        [HttpGet("{id}")] //falta mapear y crear service
        public async Task<ActionResult<Match>> GetMatch(int id)
        {
            if (_context.Match == null)
            {
                return NotFound();
            }
            var match = await _context.Match.FindAsync(id);

            if (match == null)
            {
                return NotFound();
            }

            return match;
        }

        
        [HttpPut("{id}")] //falta mapear y crear service
        public async Task<IActionResult> PutMatch(int id, Match match)
        {
            if (id != match.IdMatch)
            {
                return BadRequest();
            }

            _context.Entry(match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(id))
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


        [HttpPost] //:funcionando con services la creacion de partido
        public async Task<ActionResult<CreateMatchViewModel>> PostMatch(CreateMatchViewModel matchViews)
        {
            if(matchViews == null)
            {
                throw new ArgumentNullException(nameof(matchViews));    
            }
            try
            {
                var match = await _service.PostMatch(matchViews);
                var matchView = _mapper.Map<CreateMatchViewModel>(match);              

                return Ok(matchView);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }       


        [HttpDelete("{id}")]//Delete : falta mapear y crear servicio
        public async Task<IActionResult> DeleteMatch(int id)
        {
            if (_context.Match == null)
            {
                return NotFound();
            }
            var match = await _context.Match.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            _context.Match.Remove(match);
            await _context.SaveChangesAsync();

            return NoContent();
        }  


        private bool MatchExists(int id)
        {
            return (_context.Match?.Any(e => e.IdMatch == id)).GetValueOrDefault();
        }
    }
}
