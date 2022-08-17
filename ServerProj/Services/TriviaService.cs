using Domain.Model.Trivia;
using ServerProj.Handlers;
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
        Question question = null;
        public TriviaService()
        {
            questions = new Question[10];
            questions = MockQuestions.questions;
            // database
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
