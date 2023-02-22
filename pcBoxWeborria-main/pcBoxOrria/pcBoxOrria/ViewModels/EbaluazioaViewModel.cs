using pcBoxOrria.Models;

namespace pcBoxOrria.ViewModels
{
    /// <summary>
    /// EbaluazioaViewModel klaseak partida motako objektuak erabiliko dituen erabiltzaile-interfazea definitzen du. Klase honek EbaluazioaViewModelList izeneko propietatea du, eta IList<Ebaluazioa> motako objektu multzo bat gordetzen du.
    /// </summary>
    public class EbaluazioaViewModel
    {
        public IList<Balorazioa> EbaluazioaViewModelList { get; set; }
    }
}
