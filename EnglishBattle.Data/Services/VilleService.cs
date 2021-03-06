﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBattle.Data.Services
{
    public class VilleService
    {
        private EnglishBattleEntities context;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="context"></param>
        public VilleService(EnglishBattleEntities context)
        {
            this.context = context;
        }

        ///  <summary>
        ///  Retourne une ville en donnant l'id
        ///  </summary>
        ///  <param  id="id">id</param>
        ///  <returns>ville</returns>
        public Ville GetVille(int id)
        {
            using (context)
            {
                return context.Villes.Find(id);
            }
        }

        ///  <summary>
        ///  Retourne  une  liste  de villes
        ///  </summary>
        ///  <returns>Liste de villes</returns>
        public List<Ville> GetList()
        {
            using (context)
            {
                return context.Villes.ToList();
            }
        }
    }
}
