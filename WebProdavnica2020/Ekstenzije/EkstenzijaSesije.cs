﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebProdavnica2020.Models;

namespace WebProdavnica2020.Ekstenzije
{
    public static class EkstenzijaSesije
    {
        public static void SerijalizujKorpu(this ISession sesija, Korpa k)
        {
            sesija.SetString("KorpaKljuc", JsonConvert.SerializeObject(k));
        }

        public static Korpa DeserijalizujKorpu(this ISession sesija)
        {
            string jsonString = sesija.GetString("KorpaKljuc");

            if (jsonString != null)
            {
                return JsonConvert.DeserializeObject<Korpa>(jsonString);
            }
            return null;
        }

    }
}
