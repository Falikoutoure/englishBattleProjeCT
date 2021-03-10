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
        public ActionResult Logout()
        {
            Session["joueur"] = null;
            return RedirectToAction("Index", "Account");
        }

        // GET: Index
        public ActionResult Index()
        {
            ViewBag.title = "Connexion";
            return View();
        }

        // POST : Index
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                JoueurService joueurService = new JoueurService(new EnglishBattleEntities());

                Joueur joueur = joueurService.GetJoueur(model.Email, model.Password);

                if (joueur != null)
                {
                    Session["joueur"] = joueur;

                    return RedirectToAction("Index", "Partie");
                }
                else
                {
                    // Nettoie le model pour toutes les propriétés soient vide
                    ModelState.Clear();

                    ViewBag.Errors = "Email ou mot de passe incorrect";
                }
            }

            return View();
        }

        // GET: Subscription
        public ActionResult Subscription()
        {
            ViewBag.title = "Inscription";
            return View();
        }

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

        [HttpGet]
        public ActionResult GetVilles()
        {
            VilleService villeService = new VilleService(new EnglishBattleEntities());

            IEnumerable<SelectListItem> villes = (IEnumerable<SelectListItem>)villeService.GetList();
            return Json(villes, JsonRequestBehavior.AllowGet);
            
        }
    }
}