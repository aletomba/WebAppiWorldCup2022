using Microsoft.EntityFrameworkCore;
using WebAppiWorldCup2022.Data;
using WebAppiWorldCup2022.Models;

namespace WebAppiWorldCup2022.Services.StadiumService
{
    public class StadiumService : IStadiumService
    {

        private readonly Fixture_WorldCupContext _context;

        public StadiumService(Fixture_WorldCupContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<Stadium>> GetStadium()
        {
            return await _context.Stadium.ToListAsync();
        }
    }
}
