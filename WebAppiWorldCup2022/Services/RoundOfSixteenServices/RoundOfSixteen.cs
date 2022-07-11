using Microsoft.EntityFrameworkCore;
using WebAppiWorldCup2022.Data;
using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.Models.ViewModels;
using WebAppiWorldCup2022.Services.RoundOf16Services;

namespace WebAppiWorldCup2022.Services.RoundOfSixteenServices
{
    public class RoundOfSixteen : IRoundOfSixteen
    {
        private readonly Fixture_WorldCupContext _context;

        public RoundOfSixteen(Fixture_WorldCupContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SoccerTeam>> GetPoints()
        {
            return await _context.SoccerTeam.Include(x=>x.IdGroupsNavigation).ToListAsync();
        }

        public async Task<List<SoccerTeam>> GetWinner(/*int g*/)
        {
            
            var match = await this.GetPoints();
            match = (from a in match
                     orderby a.Points descending
                     where a.IdGroupsNavigation.IdGroups == a.IdGroupsNavigation.IdGroups 
                     select a);

            return match.ToList();                    
          //probar hacer mas partidos a ver si los trae ordenados a los otros grupos
        }
    }
}
