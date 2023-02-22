using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pcBoxOrria.Models;
using pcBoxOrria.Services;
using pcBoxOrria.ViewModels;

namespace pcBoxOrria.Controllers
{
    /// <summary>
    /// Ebaluazion nota ikusteko eta notak aldatzeko erabiltzen den kontrolatzailea da.
    /// </summary>
    public class EbaluazioaController : Controller
    {
        private readonly IEbaluazioaService _ebaluazioaService;

        public EbaluazioaController(IEbaluazioaService ebaluazioaService)
        {
            _ebaluazioaService = ebaluazioaService;
        }
        public async Task<ActionResult> JokoEbaluazioa()
        {
            var komentarioaVM = new EbaluazioaViewModel();
            List<Balorazioa> komentarioGuztiak = new List<Balorazioa>();
            komentarioGuztiak = await _ebaluazioaService.GetAllEbaluazioak();
            komentarioaVM.EbaluazioaViewModelList = komentarioGuztiak;
            return View(komentarioaVM);
        }
        // GET: EbaluazioaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EbaluazioaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EbaluazioaController/Create
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

        // GET: EbaluazioaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EbaluazioaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: EbaluazioaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EbaluazioaController/Delete/5
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
