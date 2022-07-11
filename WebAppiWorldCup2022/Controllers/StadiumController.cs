using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAppiWorldCup2022.Services.StadiumService;
using WebAppiWorldCup2022.ViewModels.StadiumViewMoldels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppiWorldCup2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IStadiumService _service;
        private readonly IMapper _mapper;
        public StadiumController(IStadiumService service, IMapper mapper)
        {
            _service = service; 
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task<IEnumerable<StadiumView>> Get()
        {
            var stadium = await _service.GetStadium();
            return  _mapper.Map<IEnumerable<StadiumView>>(stadium);
        }

        // GET api/<StadiumController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StadiumController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StadiumController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StadiumController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
