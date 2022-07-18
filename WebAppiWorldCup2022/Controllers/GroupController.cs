using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAppiWorldCup2022.Data;
using WebAppiWorldCup2022.Services.GroupService;
using WebAppiWorldCup2022.ViewModels.GroupsViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppiWorldCup2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _service;
        private readonly IMapper _mapper;

        public GroupController(IGroupService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;   
        }
        
        [HttpGet]
        public async Task<IEnumerable<GroupView>> Get()
        {
            var group = await _service.GetGroups();
            return _mapper.Map<IEnumerable<GroupView>>(group); 
        }

        // GET api/<GroupController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GroupController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GroupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GroupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
