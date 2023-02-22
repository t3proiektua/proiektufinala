using pcBoxOrria.Models;

namespace pcBoxOrria.ViewModels
{
    /// <summary>
    /// KomentarioaViewModel klaseak, "user" eta "komentarioa" atributuak ditu, hauetan erabiltzailearen izena eta komentarioa gordeko dira. Era berean, "KomentarioaViewModelList" atributuak "Komentarioa" motako objektuen zerrenda izango da.
    /// </summary>
    public class KomentarioaViewModel
    {
        public string user { get; set; }
        public string komentarioa { get; set; }
        public IList<Komentarioa> KomentarioaViewModelList { get; set; }
    }
}
