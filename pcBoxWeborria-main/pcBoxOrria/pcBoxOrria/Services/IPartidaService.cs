using pcBoxOrria.Models;

namespace pcBoxOrria.Services
{
    /// <summary>
    /// "IPartidaService" interfaze honek lau metodo izen ditu eta metodo bakoitzak "Partida" klaseko lista bat itzuli behar du. Metodo hauek "PartidaService" klasean inplementatuko dira.  
    /// </summary>
    public interface IPartidaService
    {
        Task<List<Partida>> GetPartidaMahiKingdom();
        Task<List<Partida>> GetPartidaZombieKiller();
        Task<List<Partida>> GetPartidaPouni();
        Task<List<Partida>> GetPartidaJohnny();
    }
}
