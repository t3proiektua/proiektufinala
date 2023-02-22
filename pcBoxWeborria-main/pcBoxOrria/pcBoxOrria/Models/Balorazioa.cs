using System.ComponentModel.DataAnnotations;
namespace pcBoxOrria.Models
{
    /// <summary>
    /// klase onek balorazioak sortzeko eta irakurtzeko erabiliko dugun modeloa da.  
    /// </summary>
    public class Balorazioa
    {
        [Key]
        public int _id { get; set; }
        public string jokua { get; set; }
        public int question1 { get; set; }
        public int question2 { get; set; }
        public int question3 { get; set; }
        public int question4 { get; set; }
        public float total { get; set; }
        public string user { get; set; }
        public Balorazioa() { }
    }
}
