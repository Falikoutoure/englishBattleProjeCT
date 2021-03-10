using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBattle.Data.Services
{
    public class QuestionService
    {
        private EnglishBattleEntities context;


        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="context"></param>
        public QuestionService(EnglishBattleEntities context)
        {
            this.context = context;
        }

        ///  <summary>
        ///  Crée une nouvelle question
        ///  </summary>
        public void CreateNewQuestion(Question question)
        {
            using (context)
            {
                context.Questions.Add(question);
                context.SaveChanges();
            }
        }

        ///  <summary>
        ///  Retourne  la liste de toutes les questions
        ///  </summary>
        ///  <returns>Liste des question</returns>
        public List<Question> GetList()
        {
            using (context)
            {
                return context.Questions.ToList();
            }
        }
    }
}
