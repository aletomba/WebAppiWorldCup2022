using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.ViewModels.PLayerViewModel;

namespace WebAppiWorldCup2022.Services.PlayerServices
{
    public interface IPLayerService
    {
        Task<IEnumerable<Player>> GetPLayers();
        Task<Player> CreatePlayer(CreateUpdatePLayer player);
        

    }
}
