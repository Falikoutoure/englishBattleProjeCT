using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnglishBattle.Data;
using EnglishBattle.Data.Services;

namespace EnglishBattle.Controllers
{
    public class AccountController : Controller
    {
        // GET: Subscription
        public ActionResult Subscription()
        {
            return View();
        }

        /*[HttpGet]
        public ActionResult GetVilles(string id)
        {
            if (!string.IsNullOrWhiteSpace(iso3) && iso3.Length == 3)
            {
                var repo = new RegionsRepository();

                IEnumerable<SelectListItem> regions = repo.GetRegions(iso3);
                return Json(regions, JsonRequestBehavior.AllowGet);
            }
            return null;
        }*/

        // POST: Subscription
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Subscription (Models.SubscriptionViewModel model)
        {
            // Validation coté serveur
            if (ModelState.IsValid)
            {
                // inscription en base données d'un joueur
                JoueurService joueurService = new JoueurService(new EnglishBattleEntities());

                Joueur joueur = new Joueur();

                joueur.nom = model.Nom;
                joueur.prenom = model.Prenom;
                joueur.email = model.Email;
                joueur.motDePasse = model.MotDePasse;
                joueur.niveau = model.Niveau;
                joueur.idVille = model.IdVilleSelectionnee;

                joueurService.CreateJoueur(joueur);

                // rediriger sur la page d'acceuil
                return RedirectToAction("Index", "Home");
            }

            // Si on arrive ici c'est que les données du formulaire n'est pas validé
            return View();
        }
    }
}