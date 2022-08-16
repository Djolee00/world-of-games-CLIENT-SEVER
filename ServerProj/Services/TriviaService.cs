using Domain.Model.Trivia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProj.Services
{
    public class TriviaService
    {
        Question[] questions;
        int questionNumber = 0;
        public TriviaService()
        {
            questions = new Question[10];
            Answer ans = new Answer("a", "b", "c", "d");
            for(int i = 0; i < questions.Length;i++)
                questions[i] = new Question(i, i+".pitanje", ans);
            // database
        }

        public string GetAQueston()
        {
            var question = questions[questionNumber++];
            return SplitQuestionIntoString(question);
        }

        private string SplitQuestionIntoString(Question question) =>
           $"{question.Id};{question.Text};{question.answer.Answer1};{question.answer.Answer2};{question.answer.Answer3};{question.answer.Answer4}";

        

    }
}
