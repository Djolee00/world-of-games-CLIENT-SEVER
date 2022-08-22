using Domain.Model.Trivia;
using Microsoft.EntityFrameworkCore;
using Repository;
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
            questions = Server.questions;
            Random rnd = new Random();
            ShuffleQuestions(rnd, questions);
        }
        


        private void ShuffleQuestions(Random rng, Question[] q)
        {
            int n = q.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                var temp = q[n];
                q[n] = q[k];
                q[k] = temp;
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
