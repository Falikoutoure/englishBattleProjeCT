using EnglishBattle.Data;
using EnglishBattle.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnglishBattle.Controllers
{
    public class PartieController : Controller
    {
        // GET: Partie
        public ActionResult Index()
        {

            Joueur joueur = (Joueur)Session["joueur"];

            // récupération des verbes
            VerbeService verbeService = new VerbeService(new EnglishBattleEntities());
            List<Verbe> verbes = verbeService.GetVerbes();

            // création d'une nouvelle partie
            PartieService partieService = new PartieService(new EnglishBattleEntities());
            Partie partie = new Partie();
            partie.idJoueur = joueur.id;
            partieService.CreateNewPartie(partie);

            // Ajout d'une nouvelle question a la partie
            Partie partieEnCours = (Partie)Session["partie"];
            QuestionService questionService = new QuestionService(new EnglishBattleEntities());
            Question newQuestion = new Question();
            newQuestion.idPartie = partieEnCours.id;
            newQuestion.idVerbe = verbes.ElementAt(0).id;

            questionService.CreateNewQuestion(newQuestion);

            ViewBag.title = "Nouvelle partie";

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.QuestionViewModel model)
        {
            /*if (ModelState.IsValid)
            {
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
            }*/

            return View();
        }
    }
}