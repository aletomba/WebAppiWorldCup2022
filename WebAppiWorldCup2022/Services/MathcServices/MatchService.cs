using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppiWorldCup2022.Data;
using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.Models.ViewModels;

namespace WebAppiWorldCup2022.Services.MathcServices
{
    public class MatchService:ImatchService
    {
        private readonly Fixture_WorldCupContext _context;

        public MatchService(Fixture_WorldCupContext context)
        {
            _context = context;
           
        }

        public async Task<IEnumerable<Match>> GetMatch()
        {
           return  await _context.Match.Include(x => x.IdStadiumNavigation)                                                
                                       .Include(x => x.IdInstanceNavigation)                                             
                                       .Include(x=>x.IdScoccerTeamLocalNavigation)                                                
                                       .Include(x=>x.IdSoccerteamVisitNavigation)
                                       .ToListAsync();
        }

        public async Task<Match> PostMatch(CreateMatchViewModel matchView)
        {
            var match = new Match()
            {                
                IdStadium = (int)matchView.Stadium,
                IdInstance = (int)matchView.Instance,
                IdScoccerTeamLocal = (int)matchView.SoccerTeamLocal,
                IdSoccerteamVisit = (int)matchView.SoccerTeamVisit,
                MatchDay = DateTime.Parse(matchView.MatchDay)

            };           
            await _context.Match.AddAsync(match);
            await _context.SaveChangesAsync();
            return match;
        }

     
    }
}
