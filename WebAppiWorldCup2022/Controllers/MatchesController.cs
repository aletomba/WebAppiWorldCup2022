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
using WebAppiWorldCup2022.ViewModels.MatchViewModels;

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

     
        [HttpGet] //funcionando
        public async Task<IEnumerable<CreateUpdateViewModel>> GetMatch()
        {
            try
            {
                var match = await _service.GetMatch();
                return _mapper.Map<IEnumerable<CreateUpdateViewModel>>(match);
            }
            catch (Exception)
            {
                return Enumerable.Empty<CreateUpdateViewModel>();   
            }
        }


        [HttpGet("{id}")] //funcionando
        public async Task<ActionResult<MatchViewModel>> GetMatch(int id)
        {
            try
            {
                var matchId = await _service.GetMatchById(id);
                var MatchView = _mapper.Map<MatchViewModel>(matchId);
                return MatchView;
            }
            catch (Exception ex)
            {
               return NotFound("No se encuentra el partido "+ ex.Message);
            }

           
           
           
        }


        [HttpPut] //funcionando
        public async Task<ActionResult<CreateUpdateViewModel>> PutMatch(CreateUpdateViewModel match)
        {          

            if (match == null)
            {
                return BadRequest();
            }
            try
            {
                var matchUpdate = await _service.PutMatch(match);
                if (matchUpdate == null)
                {
                    return NotFound("aca error");

                }
                else
                {
                    return Ok (_mapper.Map<CreateUpdateViewModel>(matchUpdate));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }          
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


        [HttpDelete("{id}")]//funcionando
        public async Task<ActionResult<Match>> DeleteMatch(int id)
        {
            try
            {
               await  _service.DeleteMatch(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            return Ok("Partido Eliminado");
    
        }  


        private bool MatchExists(int id)
        {
            return (_context.Match?.Any(e => e.IdMatch == id)).GetValueOrDefault();
        }
    }
}
