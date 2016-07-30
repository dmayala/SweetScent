using SweetScent.Core.Containers;
using System.Threading;
using System.Threading.Tasks;

namespace SweetScent.Core.Services
{
    public interface IPogoService
    {
        Task LoginAsync(string username, string password);
        Task<PogoMapResponse> GetMapData(CancellationToken token = default(CancellationToken));
        void SetInitialLocation(double lat, double lon, double alt);
    }
}