using pcBoxOrria.Models;
namespace pcBoxOrria.ViewModels
{
    /// <summary>
    /// PartidaViewModel klaseak partida motako objektuak erabiliko dituen erabiltzaile-interfazea definitzen du. Klase honek PartidaViewModelList izeneko propietatea du, eta IList<Partida> motako objektu multzo bat gordetzen du.
    /// </summary>
    public class PartidaViewModel
    {
        public IList<Partida> PartidaViewModelList { get; set; }
    }
}
