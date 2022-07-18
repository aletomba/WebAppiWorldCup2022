using Microsoft.EntityFrameworkCore;
using WebAppiWorldCup2022.Data;
using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.ViewModels.PLayerViewModel;

namespace WebAppiWorldCup2022.Services.PlayerServices
{
    public class PlayerService : IPLayerService
    {
        private readonly Fixture_WorldCupContext _context;
        public PlayerService(Fixture_WorldCupContext context)
        {
            _context = context; 
        }

        public async Task<Player> CreatePlayer(CreateUpdatePLayer player)
        {
            if (player != null)
            {
                var newPlayer = new Player
                {
                    IdPerson = player.IdPerson,
                    IdSoccerTeam = player.Country,
                    Position = player.Position,
                };
                await _context.Player.AddAsync(newPlayer);
                await _context.SaveChangesAsync();
                return newPlayer;
            }
            else
            {
                throw new Exception("Problema guardando player");
            }

        }


        public async Task<IEnumerable<Player>> GetPLayers()
        {
            return await _context.Player.Include(x => x.IdPersonNavigation).Include(x => x.IdSoccerTeamNavigation).ToListAsync();
        }
    }
}
