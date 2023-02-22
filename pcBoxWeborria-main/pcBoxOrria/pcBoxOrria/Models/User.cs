namespace pcBoxOrria.Models
{
    /// <summary>
    /// klase onek erabiltzailea sortzeko eta irakurtzeko erabiliko dugun modeloa da.  
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string izena { get; set; }
        public string taldea { get; set; }
        public string pasahitza { get; set; }
    }
}
