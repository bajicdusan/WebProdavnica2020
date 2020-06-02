using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebProdavnica2020.Models;

namespace WebProdavnica2020.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProdavnicadbContext db;

        public HomeController(ILogger<HomeController> logger, ProdavnicadbContext _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index(int id = 0)
        {
            ViewBag.id = id;
            ViewBag.Kategorije = db.Kategorije.ToList();
            IEnumerable<Proizvod> listaProizvoda = db.Proizvodi;
            if (id != 0)
            {
                listaProizvoda = listaProizvoda
                    .Where(p => p.KategorijaId == id);
            }

            return View(listaProizvoda.ToList());

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
