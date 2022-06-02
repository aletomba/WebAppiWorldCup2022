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
using WebAppiWorldCup2022.Services.RoundOf16Services;

namespace WebAppiWorldCup2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly Fixture_WorldCupContext _context;
        private readonly IMapper _mapper;
       
        public IncidentsController(Fixture_WorldCupContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;           
        }
        
   
        [HttpGet]

        public async Task<IEnumerable<IncidentViewModel>> GetIncidents()
        {
            //  if (_context.Incidents == null)
            //  {
            //      return NotFound();
            //  }

            var incidents = await _context.Incidents.Include(x => x.IdMatchNavigation)
                                                       .ThenInclude(p => p.IdScoccerTeamLocalNavigation)
                                                    .Include(x => x.IdMatchNavigation)
                                                        .ThenInclude(p => p.IdSoccerteamVisitNavigation)
                                                    .Include(x => x.IdMatchNavigation)
                                                        .ThenInclude(p => p.IdStadiumNavigation)
                                                    .Include(x => x.IdMatchNavigation)
                                                        .ThenInclude(p => p.IdInstanceNavigation).ToListAsync();

            var incidentsView = _mapper.Map<IEnumerable<IncidentViewModel>>(incidents);

            return incidentsView;

        }       
      
      

    
        [HttpPost]
        public async Task<ActionResult<Incidents>> PostIncidents(Incidents incidents)
        {
            if (_context.Incidents == null)
            {
                return Problem("Entity set 'Fixture_WorldCupContext.Incidents'  is null.");
            }
            _context.Incidents.Add(incidents);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncidents", new { id = incidents.IdIncidents }, incidents);
        }


      
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidents(int id)
        {
            if (_context.Incidents == null)
            {
                return NotFound();
            }
            var incidents = await _context.Incidents.FindAsync(id);
            if (incidents == null)
            {
                return NotFound();
            }

            _context.Incidents.Remove(incidents);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool IncidentsExists(int id)
        {
            return (_context.Incidents?.Any(e => e.IdIncidents == id)).GetValueOrDefault();
        }
    }
}
