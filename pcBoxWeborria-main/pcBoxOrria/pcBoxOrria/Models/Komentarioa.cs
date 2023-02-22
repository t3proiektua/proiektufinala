using System.ComponentModel.DataAnnotations;
namespace pcBoxOrria.Models
{
    /// <summary>
    /// klase onek komentarioa sortzeko eta irakurtzeko erabiliko dugun modeloa da.  
    /// </summary>
    public class Komentarioa
    {
        [Key]
        public int id;
        public string comentario;
        public string filtro;
        public string user;
        public Komentarioa(){}
    }
}
