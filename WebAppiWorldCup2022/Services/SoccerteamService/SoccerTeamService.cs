using Microsoft.EntityFrameworkCore;
using WebAppiWorldCup2022.Data;
using WebAppiWorldCup2022.Models;

namespace WebAppiWorldCup2022.Services.SoccerteamService
{
    public class SoccerTeamService : ISoccerTeamService
    {
        private readonly Fixture_WorldCupContext _context;

        public SoccerTeamService(Fixture_WorldCupContext context)
        {
           _context = context;
        }
        public async Task<IEnumerable<SoccerTeam>> GetSoccerTeam()
        {
            return await _context.SoccerTeam.Include(x=>x.IdGroupsNavigation).ToListAsync(); 
        }

        public Task<IEnumerable<SoccerTeam>> CreateSoccerTeam()
        {
            throw new NotImplementedException();
        }
    }
}
