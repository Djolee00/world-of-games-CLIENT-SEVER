using Domain.Model.Trivia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProj.Handlers
{
    public static class MockQuestions
    {
        public static Question[] questions =
        {
            new Question(1,"Prvo pitanje",new Answer("Prvi odgvor;","Drugi odgovor","Treci odgovor","Cetvrti odgovor")),
            new Question(2,"Drugo pitanje",new Answer("Prvi odgvor","Drugi odgovor;","Treci odgovor","Cetvrti odgovor")),
            new Question(3,"Trece pitanje",new Answer("Prvi odgvor","Drugi odgovor;","Treci odgovor","Cetvrti odgovor")),
            new Question(4,"Cetvrto pitanje",new Answer("Prvi odgvor","Drugi odgovor","Treci odgovor","Cetvrti odgovor;")),
            new Question(5,"Peto pitanje",new Answer("Prvi odgvor;","Drugi odgovor","Treci odgovor","Cetvrti odgovor")),
            new Question(6,"Sesto pitanje",new Answer("Prvi odgvor","Drugi odgovor","Treci odgovor;","Cetvrti odgovor")),
            new Question(7,"Sedmo pitanje",new Answer("Prvi odgvor","Drugi odgovor;","Treci odgovor","Cetvrti odgovor")),
            new Question(8,"Osmo pitanje",new Answer("Prvi odgvor","Drugi odgovor","Treci odgovor;","Cetvrti odgovor")),
            new Question(9,"Deveto pitanje",new Answer("Prvi odgvor","Drugi odgovor","Treci odgovor","Cetvrti odgovor;")),
            new Question(10,"Deseto pitanje",new Answer("Prvi odgvor;","Drugi odgovor","Treci odgovor","Cetvrti odgovor"))
        };
    }
}
