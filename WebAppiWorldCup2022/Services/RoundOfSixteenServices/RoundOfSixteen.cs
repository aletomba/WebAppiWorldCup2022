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
        
        public async Task<IEnumerable<Incidents>> GetIncidents()
        {
            return await _context.Incidents.Include(x => x.IdMatchNavigation)
                                                       .ThenInclude(p => p.IdScoccerTeamLocalNavigation)
                                                    .Include(x => x.IdMatchNavigation)
                                                        .ThenInclude(p => p.IdSoccerteamVisitNavigation)
                                                    .Include(x => x.IdMatchNavigation)
                                                        .ThenInclude(p => p.IdStadiumNavigation)
                                                    .Include(x => x.IdMatchNavigation)
                                                        .ThenInclude(p => p.IdInstanceNavigation).ToListAsync();
        }

        public async Task<Matchkey> GetKey(Matchkey matchkey)
        {
            var groups = await this.GetIncidents();
            if(groups == null)
            {
                throw new FileNotFoundException();
            }
            else
            {
                foreach (Incidents team in groups) 
                {
                    
                    if(team.IdMatchNavigation.IdScoccerTeamLocalNavigation.Goal >
                        team.IdMatchNavigation.IdSoccerteamVisitNavigation.Goal)
                    {
                        matchkey.SoccerTeam1 = team.IdSocceteamNavigation.Country;
                    }
                    else
                    {
                        var group = team.IdSocceteamNavigation.IdGroupsNavigation.NameGroup;

                       //if(team.IdSocceteamNavigation.Goal is group)
                       // {
                            
                       // }
                    }
                }
                return matchkey;    
            }
        }
    }
}
