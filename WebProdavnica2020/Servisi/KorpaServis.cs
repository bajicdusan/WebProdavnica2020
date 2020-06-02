using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebProdavnica2020.Ekstenzije;
using WebProdavnica2020.Models;

namespace WebProdavnica2020.Servisi
{
    public class KorpaServis
    {
        private readonly IHttpContextAccessor accessor;

        public KorpaServis(IHttpContextAccessor _accessor)
        {
            accessor = _accessor;
        }

        public void CuvajKorpu(Korpa k)
        {
            ISession sesija = accessor.HttpContext.Session;
            sesija.SerijalizujKorpu(k);
        }

        public Korpa CitajKorpu()
        {
            Korpa k = null;
            ISession sesija = accessor.HttpContext.Session;
            if (sesija.DeserijalizujKorpu() != null)
            {
                k = sesija.DeserijalizujKorpu();
            }
            else
            {
                k = new Korpa();
            }

            return k;
        }

        public void ObrisiKorpu()
        {
            ISession sesija = accessor.HttpContext.Session;
            sesija.Clear();
        }

    }
}
