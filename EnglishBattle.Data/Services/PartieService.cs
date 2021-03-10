using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBattle.Data.Services
{
    public class PartieService
    {
        private EnglishBattleEntities context;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="context"></param>
        public PartieService(EnglishBattleEntities context)
        {
            this.context = context;
        }

        ///  <summary>
        ///  Crée une nouvelle partie
        ///  </summary>
        public void CreateNewPartie(Partie partie)
        {
            using (context)
            {
                context.Parties.Add(partie);
                context.SaveChanges();
            }
        }
    }
}
