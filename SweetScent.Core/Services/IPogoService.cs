using SweetScent.Core.Containers;
using System.Threading.Tasks;

namespace SweetScent.Core.Services
{
    public interface IPogoService
    {
        Task<PogoMapResponse> GetMapData();
    }
}