using Domain.Model.Trivia;
using ServerProj.Handlers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProj.Services
{
    public class TriviaService
    {
        Question[] questions;
        int questionNumber = 0;
        Question question = null;

        

        public TriviaService()
        {
            questions = new Question[10];
            questions = MockQuestions.questions;
            // database
        }

        private void ReadFromDatabase()
        {
            var connection = ConfigurationManager.ConnectionStrings["rmtDatabaseConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                using(SqlCommand cmd = new SqlCommand("",con))
                {
                    cmd.CommandText = "SELECT * FROM Question";

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                    }
                }
            }
        }

        public string GetAQuestion()
        {
            var question = questions[questionNumber++];
            this.question = question;
            return SplitQuestionIntoString(question);
        }


        public string GetAAnswer()
        {
            var answers = new List<string>();
            answers.Add(question.answer.Answer1);
            answers.Add(question.answer.Answer2);
            answers.Add(question.answer.Answer3);
            answers.Add(question.answer.Answer4);

            return answers.FirstOrDefault(a => a.Contains(';')).TrimEnd(';');
        }

        private string SplitQuestionIntoString(Question question) =>
           $"{question.Id};{question.Text};{question.answer.Answer1};{question.answer.Answer2};{question.answer.Answer3};{question.answer.Answer4}";

        

    }
}
