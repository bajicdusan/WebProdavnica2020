﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProdavnica2020.Models;
using WebProdavnica2020.Servisi;

namespace WebProdavnica2020.Controllers
{
    public class KorpaController : Controller
    {
        private readonly KorpaServis ks;
        private Korpa k;
        private ProdavnicadbContext db;

        public KorpaController(ProdavnicadbContext _db, KorpaServis _ks)
        {
            db = _db;
            ks = _ks;
            k = ks.CitajKorpu();
        }
        public IActionResult Index()
        {
            return View(k);
        }


        public IActionResult DodajStavku(int ProizvodId)
        {
            Proizvod p1 = db.Proizvodi.Find(ProizvodId);

            if (p1 != null)
            {
                k.DodajStavku(p1, 1);
                ks.CuvajKorpu(k);
            }

            return RedirectToAction("Index");
        }




        public IActionResult PromeniStavku(int ProizvodId, int kolicina)
        {
            Proizvod p1 = db.Proizvodi.Find(ProizvodId);
            if (p1 != null)
            {
                k.PromeniStavku(p1, kolicina);
                ks.CuvajKorpu(k);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ObrisiStavku(int ProizvodId)
        {
            Proizvod p1 = db.Proizvodi.Find(ProizvodId);

            if (p1 != null)
            {
                k.ObrisiStavku(p1.ProizvodId);
                ks.CuvajKorpu(k);
            }
            return RedirectToAction("Index");
        }

    }
}
