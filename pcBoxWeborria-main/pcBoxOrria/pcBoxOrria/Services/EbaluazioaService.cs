using pcBoxOrria.Models;

namespace pcBoxOrria.Services
{
    /// <summary>
    /// Ebaluazioaren puntuazioak ikusteko eta puntuazioak igoteko erabiltzen den kontrolatzailea da.
    /// </summary>
    public class EbaluazioaService : IEbaluazioaService
    {
        private Uri url = new Uri("http://localhost:8081/");

        public async Task<List<Balorazioa>> GetAllEbaluazioak()
        {
            List<Balorazioa> balorazioaList = new List<Balorazioa>();
            Uri urlBalorazioak = new Uri(url, "inkestak/inkestaGuztiak");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(urlBalorazioak))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    balorazioaList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Balorazioa>>(apiResponse);
                }
            }
            return balorazioaList;
        }
    }
}
