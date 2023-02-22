using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pcBoxOrria.Models;
using pcBoxOrria.Services;
using pcBoxOrria.ViewModels;

namespace pcBoxOrria.Controllers
{
    /// <summary>
    /// Foroaren komentarioak ikusteko eta komentarioak igoteko erabiltzen den kontrolatzailea da.
    /// </summary>
    public class ForumController : Controller
    {
        private readonly IKomentarioaService _komentarioaService;
        public ForumController(IKomentarioaService komentarioaService)
        {
            _komentarioaService = komentarioaService;
        }
        /// <summary>
        /// Metododo onek guk egindako mongo resta apian dauden komentario guztiak irakurri eta bistaratzen ditu.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Komentarioa()
        {
            var komentarioaVM = new KomentarioaViewModel();
            List<Komentarioa> komentarioGuztiak = new List<Komentarioa>();
            komentarioGuztiak = await _komentarioaService.GetKomentarioak();
            komentarioaVM.KomentarioaViewModelList = komentarioGuztiak;
            komentarioGuztiak.Sort((x, y) => y.id.CompareTo(x.id));
            return View(komentarioaVM);
        }
        /// <summary>
        /// Metodo onek guk egindako mongo rest apiaren bitartez komentarioak igoteak ahalbidetzen du.
        /// </summary>
        /// <param name="user">Loginean dagoen erabiltzailea hartzen du</param>
        /// <param name="komentarioa">Idatzitako komentarioa</param>
        /// <returns></returns>
        public IActionResult PostKomentarioa(string user, string komentarioa)
        {
            Komentarioa komentarioaObject = new Komentarioa();
            komentarioaObject.user = user;
            komentarioaObject.comentario = komentarioa;
            return View();
        }

        // POST: ForumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: ForumController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ForumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
