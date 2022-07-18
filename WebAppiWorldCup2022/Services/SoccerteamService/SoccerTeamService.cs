using Microsoft.EntityFrameworkCore;
using WebAppiWorldCup2022.Data;
using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.ViewModels.SoccerTeamViewmodels;

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

        public async Task<SoccerTeam> SoccerTeamById(int id)
        {
            return await _context.SoccerTeam.Include(x => x.IdGroupsNavigation)
                 .SingleOrDefaultAsync(x => x.IdSoccerTeam == id);
        }

        public async Task<SoccerTeam>CreateSoccerTeam(SoccerTeamViewModel soccerTeam)
        {
            var soccerTeamNew = new SoccerTeam
            {
                 Country= soccerTeam.Country,
                 IdGroups = soccerTeam.IdGroup
           };
            await _context.AddAsync(soccerTeamNew);
            await _context.SaveChangesAsync();
            return soccerTeamNew;
        }

        public async Task<SoccerTeam> UpdateSoccerTeam(SoccerTeamViewModel soccerTeam)
        {
            var updateSoccerTeam = await SoccerTeamById((int)soccerTeam.idCountry);  
            if(updateSoccerTeam != null)
            {
                updateSoccerTeam.IdSoccerTeam = (int)soccerTeam.idCountry;
                updateSoccerTeam.Country = soccerTeam.Country;
                updateSoccerTeam.IdGroups = soccerTeam.IdGroup;
            }
            await _context.SaveChangesAsync();
            return updateSoccerTeam;
        }

        public async Task<SoccerTeam> DeleteSoccerTeam(int id)
        {
            var delete = await SoccerTeamById(id);
            if (delete != null)
            {
                _context.SoccerTeam.Remove(delete);
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
