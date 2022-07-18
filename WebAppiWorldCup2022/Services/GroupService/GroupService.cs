using Microsoft.EntityFrameworkCore;
using WebAppiWorldCup2022.Data;
using WebAppiWorldCup2022.Models;

namespace WebAppiWorldCup2022.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly Fixture_WorldCupContext _contex;
        public GroupService(Fixture_WorldCupContext contex)
        {
            _contex = contex;   
        }

        public async Task<IEnumerable<Groups>> GetGroups()
        {
            return await _contex.Groups.ToListAsync();
        }
    }
}
