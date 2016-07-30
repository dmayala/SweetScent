using SweetScent.Core.Containers;
using System.Threading.Tasks;

namespace SweetScent.Core.Services
{
    public interface IPogoService
    {
        Task LoginAsync(string username, string password);
        Task<PogoMapResponse> GetMapData();
        void SetInitialLocation(double lat, double lon, double alt);
    }
}