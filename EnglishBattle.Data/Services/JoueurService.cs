using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBattle.Data.Services
{
    public class JoueurService
    {
        private EnglishBattleEntities context;


        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="context"></param>
        public JoueurService(EnglishBattleEntities context)
        {
            this.context = context;
        }

        ///  <summary>
        ///  Retourne un joueur en donnant l'id du joueur
        ///  </summary>
        ///  <param  id="id">id</param>
        ///  <returns>joueur</returns>
        public Joueur GetJoueur(int id)
        {
            using (context)
            {
                return context.Joueurs.Find(id);
            }
        }

        ///  <summary>
        ///  Retourne  un joueur en donnant son email et son mot de passe
        ///  </summary>
        ///  <param  email="email">email</param>
        ///  <param  motDePasse="motDePasse">motDePasse</param>
        ///  <returns>joueur</returns>
        public Joueur GetJoueur(string email, string motDePasse)
        {
            using (context)
            {
                IQueryable<Joueur> queryable = from joueurs in context.Joueurs
                                                       where joueurs.email == email
                                                       && joueurs.motDePasse == motDePasse
                                                       select joueurs;
                return queryable.FirstOrDefault();
            }
        }

        ///  <summary>
        ///  Retourne une liste de joueurs triée par le score (hall of fame)
        ///  </summary>
        ///  <returns>Liste de joueurs </returns>
        public List<Joueur> GetJoueursTriesParScore()
        {
            using (context)
            {   
                // todo : tri descendant sur le score
                return context.Joueurs.ToList();
            }

        }

        ///  <summary>
        ///  Crée un nouveau joueur
        ///  </summary>
        public void CreateJoueur(Joueur joueur)
        {
            using (context)
            {
                context.Joueurs.Add(joueur);
                context.SaveChanges();
            }
        }

        ///  <summary>
        ///  met à jour les données d'un joueur
        ///  </summary>
        public void UpdateJoueur(Joueur joueurMaj)
        {
            using (context)
            {
                context.Entry(joueurMaj).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        ///  <summary>
        ///  supprime un joueur
        ///  </summary>
        public void DeleteJoueur(Joueur joueur)
        {
            using (context)
            {
                context.Entry(joueur).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
