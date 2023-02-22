using pcBoxOrria.Models;
using System.Reflection;

namespace pcBoxOrria.Services
{
    /// <summary>
    /// Eskaintzen den interfazeak IKomentarioaService izena du. Hau Komentarioa motako objektuak kudeatzeko metodoak biltzen ditu.
    /// GetKomentarioak metodoak Komentarioa objektu motako lista bat itzultzen du.
    /// PostKomentarioa metodoak Komentarioa objektua hartu eta REST API bidez zerbitzarira bidaltzen du.
    /// </summary>
    public interface IKomentarioaService
    {
        Task<List<Komentarioa>> GetKomentarioak();
        Task PostKomentarioa(Komentarioa komentarioa);
    }
}
