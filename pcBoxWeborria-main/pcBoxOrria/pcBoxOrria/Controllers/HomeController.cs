using Microsoft.AspNetCore.Mvc;
using pcBoxOrria.Models;
using System.Diagnostics;

namespace pcBoxOrria.Controllers
{
    /// <summary>
    /// Home controller bista basikoak erakusten dute.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        /// <summary>
        /// Konstruktore onek logeatuta zaudenean gauzak egiteko balio du.
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Metodo onek index orrialdearen bista bistaratzen du.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Metodo onek privacy orrialdearen bista erakutsiko du.
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// Metodo onek errore bat gertatzen denean salto egiten du.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}