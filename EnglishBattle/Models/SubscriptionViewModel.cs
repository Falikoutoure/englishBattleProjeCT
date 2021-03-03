using EnglishBattle.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EnglishBattle.Models
{
    public class SubscriptionViewModel
    {
        [Required] // indique que ce champ est obligatoire
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "Prénom")] // texte utiliser dans le label associé au champ
        public string Prenom { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress] // valide si l'email est valide
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)] // indique que ce champ sera de type password
        [StringLength(14, ErrorMessage = "Le mot de passe doit compris entre {2} et {1}", MinimumLength = 6)]
        public string MotDePasse { get; set; }

        [Required]
        [Display(Name = "Confirmer le mot de passe")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("MotDePasse", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmationMotDePasse { get; set; }

        [Required]
        [Display(Name = "Niveau")]
        public int Niveau { get; set; }

        [Required]
        [Display(Name = "Ville")]
        public int IdVilleSelectionnee { get; set; }
        public IEnumerable<SelectListItem> Villes { get; set; }
    }
}