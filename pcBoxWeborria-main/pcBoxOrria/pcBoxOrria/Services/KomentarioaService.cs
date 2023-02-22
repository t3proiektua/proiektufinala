using MongoDB.Bson.IO;
using Newtonsoft.Json;
using pcBoxOrria.Models;
using System.Text;

namespace pcBoxOrria.Services
{
    /// <summary>
    /// Kodea "Komentarioa" objektuen zerrenda bat bueltatzen duen "GetKomentarioak" eta "Komentarioa" objektua bidaltzen duen "PostKomentarioa" metodoak ditu. "HttpClient" klasea erabiliz, "/comentarioak/comentarioGuztiak" eta "/comentarioak/comentarioBerria" URL-ak erabiltzen ditu datuak irakurri eta bidaltzeko
    /// </summary>
    public class KomentarioaService : IKomentarioaService
    {
        private Uri url = new Uri("http://localhost:8081");
        /// <summary>
        /// "GetKomentarioak" metodoak "Komentarioa" objektuen lista bat bueltatzen du. Metodoak "/comentarioak/comentarioGuztiak" izeneko URL-tik "HttpClient" klasea erabiliz jasotako datuak irakurri eta deserializatzen ditu, eta hala ere, beste metodo batzuetan erabil daitezkeen "Komentarioa" objektuen lista bat bueltatzen du.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Komentarioa>> GetKomentarioak()
        {
            List<Komentarioa> komentarioaList = new List<Komentarioa>();
            Uri urlKomentarioak = new Uri(url, "/comentarioak/comentarioGuztiak");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(urlKomentarioak))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    komentarioaList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Komentarioa>>(apiResponse);
                }
            }
            return komentarioaList;
        }
        /// <summary>
        /// "PostKomentarioa" metodoak "void" itzultzen du eta "Komentarioa" objektua hartzen du parametro bezala. Metodoak "HttpClient" klasea erabiliz POST eskaera bat bidaltzen du "/comentarioak/comentarioBerria" izeneko URL-era, erantzuna jasotzen du eta estatua egiaztatzen du.
        /// </summary>
        /// <param name="komentarioa"></param>
        /// <returns></returns>
        public async Task PostKomentarioa(Komentarioa komentarioa)
        {
            using(var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(komentarioa), Encoding.UTF8, "application/json");
                Uri urlKomentarioaGehitu = new Uri(url, "/comentarioak/comentarioBerria?user="+ komentarioa.user + "&filtro=" + "X" + "&comentario=" + komentarioa.comentario);
                var response = await httpClient.PostAsync(urlKomentarioaGehitu, content);
                string responseContent = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
