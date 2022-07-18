using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebAppiWorldCup2022.Data;
using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.Models.ViewModels;
using WebAppiWorldCup2022.ViewModels.MatchViewModels;

namespace WebAppiWorldCup2022.Services.MathcServices
{
    public class MatchService : ImatchService
    {
        private readonly Fixture_WorldCupContext _context;

        public MatchService(Fixture_WorldCupContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Match>> GetMatch()
        {
            try
            {
                return await _context.Match.Include(x => x.IdStadiumNavigation)
                                            .Include(x => x.IdInstanceNavigation)
                                            .Include(x => x.IdScoccerTeamLocalNavigation)
                                            .Include(x => x.IdSoccerteamVisitNavigation)
                                            .ToListAsync();
            }
            catch
            {
                return Enumerable.Empty<Match>();
            }
        }

        public async Task<Match> GetMatchById(int id)
        {

            var matchId = await _context.Match.Include(x => x.IdStadiumNavigation)
                                              .Include(x => x.IdInstanceNavigation)
                                              .Include(x => x.IdScoccerTeamLocalNavigation)
                                              .Include(x => x.IdSoccerteamVisitNavigation).
                                               SingleOrDefaultAsync(x => x.IdMatch == id);

            if (matchId == null)
            {
                throw new Exception();
            }

            return matchId;

        }

        public async Task<Match> PostMatch(CreateMatchViewModel matchView)
        {
            var match = new Match()
            {
                IdStadium = (int)matchView.Stadium,
                IdInstance = (int)matchView.Instance,
                IdScoccerTeamLocal = (int)matchView.SoccerTeamLocal,
                IdSoccerteamVisit = (int)matchView.SoccerTeamVisit,
                MatchDay = DateTime.Parse(matchView.MatchDay),

            };
            await _context.Match.AddAsync(match);
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task<Match> PutMatch(CreateUpdateViewModel updateMatch)
        {
            var match = await GetMatchById(updateMatch.IdMatch);
            if (match != null)
            {
                match.IdMatch = updateMatch.IdMatch;
                match.IdStadium = updateMatch.Stadium;
                match.IdInstance = updateMatch.Instance;
                match.IdScoccerTeamLocal = updateMatch.SoccerTeamLocal;
                match.IdSoccerteamVisit = updateMatch.SoccerTeamVisit;
                match.MatchDay = DateTime.Parse(updateMatch.MatchDay);

            }
            await _context.SaveChangesAsync();
            return match;

        }

        public async Task<Match> DeleteMatch(int id)
        {

            var delete = await GetMatchById(id);
            if (delete != null)
            {
                _context.Match.Remove(delete);
                await _context.SaveChangesAsync();
            }
            else
            {

                throw new Exception();
            }
            
            return delete;
        }
    }
}
