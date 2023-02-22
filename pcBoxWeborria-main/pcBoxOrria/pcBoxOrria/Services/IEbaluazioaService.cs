using pcBoxOrria.Models;

namespace pcBoxOrria.Services
{
    public interface IEbaluazioaService
    {
        Task<List<Balorazioa>> GetAllEbaluazioak();
    }
}
