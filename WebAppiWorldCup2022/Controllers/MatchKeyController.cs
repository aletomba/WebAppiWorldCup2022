using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult<Matchkey>> Get()
        {
            return
        }



        // GET api/<MatchKeyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        
        [HttpPost]
        public async Task<Matchkey> Post(Matchkey key1)
        {
            return await _roundOfSexteen.GetKey(key1);
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
