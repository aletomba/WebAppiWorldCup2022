using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.Services.SoccerteamService;
using WebAppiWorldCup2022.ViewModels.SoccerTeamViewmodels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            var soccerTeam = await _service.GetSoccerTeam();
            var soccerTeamView = _mapper.Map<IEnumerable<SoccerTeamViewModel>>(soccerTeam);
            return soccerTeamView;
        }

        // GET api/<SoccerTeamController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SoccerTeamController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SoccerTeamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SoccerTeamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
