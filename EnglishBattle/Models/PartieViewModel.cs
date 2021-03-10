using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnglishBattle.Models
{
    public class QuestionViewModel
    {
        [Required]
        [Display(Name = "Participe passé")]
        public string ReponseParticipePasse { get; set; }

        [Required]
        [Display(Name = "Preterit")]
        public string Password { get; set; }
    }
}