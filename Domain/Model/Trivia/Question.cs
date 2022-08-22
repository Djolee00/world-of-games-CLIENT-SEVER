using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Trivia
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Answer answer { get; set; }

        public Question()
        {
                
        }

        public Question(int id, string text, Answer answer)
        {
            Id = id;
            Text = text;
            this.answer = answer;
        }
    }
}
