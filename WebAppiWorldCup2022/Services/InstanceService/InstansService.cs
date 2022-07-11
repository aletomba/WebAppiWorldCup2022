using Microsoft.EntityFrameworkCore;
using WebAppiWorldCup2022.Data;
using WebAppiWorldCup2022.Models;

namespace WebAppiWorldCup2022.Services.InstanceService
{
    public class InstansService : IInstansService
    {
        private readonly Fixture_WorldCupContext _context;
        public InstansService(Fixture_WorldCupContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<Instance>> GetInstances()
        {
           return await _context.Instance.ToListAsync();
        }
    }
}
