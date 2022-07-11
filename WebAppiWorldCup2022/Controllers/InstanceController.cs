using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAppiWorldCup2022.Services.InstanceService;
using WebAppiWorldCup2022.ViewModels.InstancesViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppiWorldCup2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstanceController : ControllerBase
    {
        private readonly IInstansService _service;
        private readonly IMapper _mapper;


        public InstanceController(IInstansService service, IMapper mapper)
        {
            _service = service; 
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task< IEnumerable<InstanceView>> Get()
        {
            var instance = await _service.GetInstances();
            return _mapper.Map<IEnumerable<InstanceView>>(instance);
        }

     
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InstanceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InstanceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InstanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
