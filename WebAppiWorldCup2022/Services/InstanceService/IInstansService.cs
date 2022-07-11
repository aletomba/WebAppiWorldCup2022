using WebAppiWorldCup2022.Models;

namespace WebAppiWorldCup2022.Services.InstanceService
{
    public interface IInstansService
    {
        Task<IEnumerable<Instance>> GetInstances();
    }
}
