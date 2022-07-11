using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.Models.ViewModels;
using WebAppiWorldCup2022.Services.RoundOf16Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppiWorldCup2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchKeyController : ControllerBase
    {
                                                   
        private readonly IMapper _mapper;
        private readonly IRoundOfSixteen _service;
        public MatchKeyController(IMapper mapper, IRoundOfSixteen service)
        {
            _mapper = mapper;
            _service = service;
        }
        
        [HttpGet]
        //public async Task<IActionResult<Matchkey>> Get()
        //{
        //    return;
        //}



        // GET api/<MatchKeyController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Matchkey>> Get(int id)
        {
            var teamMaxPoint = await _service.GetWinner();
            var key = _mapper.Map<IEnumerable<Matchkey>>(teamMaxPoint);
            return key;
        }



        [HttpPost]
        public async Task<Matchkey> Post(/*int g*/)
        {
            Matchkey matchkey = new Matchkey();
            var Winners = await _service.GetWinner();
            //var view = _mapper.Map<IEnumerable<Matchkey>>(Winners);
            //
            matchkey.SoccerTeam1 = Winners[0].Country;
            matchkey.SoccerTeam2= Winners[1].Country;   
            
            return matchkey;

        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

     
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
