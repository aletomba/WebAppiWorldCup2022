using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.Services.SoccerteamService;
using WebAppiWorldCup2022.ViewModels.SoccerTeamViewmodels;

namespace WebAppiWorldCup2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoccerTeamController : ControllerBase
    {
        private readonly ISoccerTeamService _service;
        private readonly IMapper _mapper;
        public SoccerTeamController(ISoccerTeamService service, IMapper mapper)
        {
            _service = service; 
            _mapper = mapper;   
        }

       
        [HttpGet]
        public async Task<IEnumerable<SoccerTeamViewModel>> Get()
        {
            try
            {
                var soccerTeam = await _service.GetSoccerTeam();
                var soccerTeamView = _mapper.Map<IEnumerable<SoccerTeamViewModel>>(soccerTeam);
                return soccerTeamView;
            }
            catch (Exception)
            {
                return Enumerable.Empty<SoccerTeamViewModel>();
            }
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<SoccerTeamViewModel>> Get(int id)
        {
            try
            {
                var soccerteam = await _service.SoccerTeamById(id);
                return _mapper.Map<SoccerTeamViewModel>(soccerteam);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<SoccerTeamViewModel>> Post(SoccerTeamViewModel soccerTeam)
        {
            try
            {
                var newMatch = await _service.CreateSoccerTeam(soccerTeam);
                return _mapper.Map<SoccerTeamViewModel>(newMatch);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SoccerTeamController>/5
        [HttpPut]
        public async Task<ActionResult<SoccerTeamViewModel>> Put(SoccerTeamViewModel soccerTeam)
        {
            if (soccerTeam == null)
            {
                return BadRequest();
            }
            try
            {
                var soccerUpdate = await _service.UpdateSoccerTeam(soccerTeam);
                if (soccerUpdate == null)
                {
                    return NotFound("aca error");

                }
                else
                {
                    return Ok(_mapper.Map<SoccerTeamViewModel>(soccerUpdate));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        // DELETE api/<SoccerTeamController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var delete = await _service.DeleteSoccerTeam(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Equipo Eliminado");
        }
    }
}
