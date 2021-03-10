using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBattle.Data.Services
{
    public class VerbeService
    {
        private EnglishBattleEntities context;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="context"></param>
        public VerbeService(EnglishBattleEntities context)
        {
            this.context = context;
        }

        ///  <summary>
        ///  Retourne  la liste de toutes les verbes
        ///  </summary>
        ///  <returns>Liste des verbes</returns>
        public List<Verbe> GetVerbes()
        {
            using (context)
            {
                return context.Verbes.ToList();
            }
        }
    }
}
