using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSiteASP.DataLayer;

namespace WebSiteASP.BusinessLayer
{
    public class PollQuestionDb : DbItem
    {
        public int? IdPollQuestion { get; set; }
        public string PollQuestion { get; set; }
        public int? IdUserLastChange { get; set; }
        public DateTime? LastTimeChanged { get; set; }

    }

    public class PollDb : DbItem
    {
        public int IdPollQuestion { get; set; }
        public string PollQuestion { get; set; }

        public PollAnswersDb[] answers { get; set; }
    }

    public class PollAnswersDb : DbItem
    {
        public int IdPollAnswer { get; set; }
        public string PollAnswer { get; set; }
        public int? IdUserLastChange { get; set; }
        public DateTime? LastTimeChanged { get; set; }

    }
    public class KriterijumPoll : KriterijumZaSelekciju
    {
        public int? IdPollQuestion { get; set; }
    }

    public abstract class OpPollBase : Operacija
    {
        public KriterijumPoll Kriterijum { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            IEnumerable<PollAnswersDb> iePollAnswers;
            PollDb[] iePollQuestions;
            if (Kriterijum != null)
            {
                iePollQuestions = (from pollq in entiteti.PollQuestions
                         where (Kriterijum.IdPollQuestion != null ? true : Kriterijum.IdPollQuestion == pollq.idPollQuestion)
                         select new PollDb()
                         {
                             IdPollQuestion = pollq.idPollQuestion,
                             PollQuestion = pollq.question
                         }).ToArray();
                iePollAnswers = (from polla in entiteti.PollAnswers
                                 where (polla.idPollQuestion == iePollQuestions[0].IdPollQuestion)
                                 select new PollAnswersDb()
                                 {
                                     IdPollAnswer = polla.idPollAnswer,
                                     PollAnswer = polla.answer
                                 });
                iePollQuestions[0].answers = iePollAnswers.ToArray();
            }
            else
            {

                iePollQuestions = (from pollq in entiteti.PollQuestions
                                   select new PollDb()
                                   {
                                       IdPollQuestion = pollq.idPollQuestion,
                                       PollQuestion = pollq.question
                                   }).OrderBy(x => Guid.NewGuid()).Take(1).ToArray();
                int id = iePollQuestions[0].IdPollQuestion;
                iePollAnswers = (from polla in entiteti.PollAnswers
                                 where (polla.idPollQuestion == id)
                                 select new PollAnswersDb()
                                 {
                                     IdPollAnswer = polla.idPollAnswer,
                                     PollAnswer = polla.answer
                                 });
                iePollQuestions[0].answers = iePollAnswers.ToArray();
            }
            OperacijaRezultat result = new OperacijaRezultat() {Status = true, Poruka = "poll select" };


            result.DbItems = iePollQuestions.ToArray();
            result.CheckDbItems();

            return result;
        }
    }
    public class OpPollSelect : OpPollBase
    {
    }

    public class OpPollInsert : OpPollBase
    {
        public PollDb Poll { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Poll != null)
            {
                int id = entiteti.spInsertPollQuestion(Poll.PollQuestion);
                foreach (PollAnswersDb a in Poll.answers)
                    entiteti.spInsertPollAnswer(id, a.PollAnswer);
            }
            return base.izvrsi(entiteti);
        }
    }

    public class OpPollQuestionSelect : Operacija
    {
        public KriterijumPoll Kriterijum { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            IEnumerable<PollQuestionDb> iePollQuestions;

            if (Kriterijum != null)
            {
                iePollQuestions = from pq in entiteti.PollQuestions
                                  where (Kriterijum.IdPollQuestion == null ? true : Kriterijum.IdPollQuestion == pq.idPollQuestion)
                                  select new PollQuestionDb()
                                  {
                                      IdPollQuestion = pq.idPollQuestion,
                                      PollQuestion = pq.question
                                  };
            }
            else
            {
                iePollQuestions = from pq in entiteti.PollQuestions
                                  select new PollQuestionDb()
                                  {
                                      IdPollQuestion = pq.idPollQuestion,
                                      PollQuestion = pq.question
                                  };
            }

            OperacijaRezultat result = new OperacijaRezultat() { Status = true, Poruka = "poll select" };

            result.DbItems = iePollQuestions.ToArray();
            result.CheckDbItems();

            return result;
        }
    }

    public class OpPollInsertOnlyQuestion : OpPollQuestionSelect
    {
        public PollQuestionDb PollQuestion { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (PollQuestion != null)
                entiteti.spInsertPollQuestion(PollQuestion.PollQuestion);
            return base.izvrsi(entiteti);
        }
    }
    

    public class OpPollUpdateOnlyQuestion : OpPollQuestionSelect
    {
        public PollQuestionDb PollQuestion { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (PollQuestion != null)
                entiteti.spUpdatePollQuestion(PollQuestion.IdPollQuestion, PollQuestion.PollQuestion, PollQuestion.IdUserLastChange);
            return base.izvrsi(entiteti);
        }
    }

    public class OpPollSelectOnlyAnswer : Operacija
    {
        public PollQuestionDb PollQuestion { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            IEnumerable<PollAnswersDb> iePollAnswers;
            if (PollQuestion != null)
            {
                iePollAnswers = (from polla in entiteti.PollAnswers
                                 where (polla.idPollQuestion == PollQuestion.IdPollQuestion)
                                 select new PollAnswersDb()
                                 {
                                     IdPollAnswer = polla.idPollAnswer,
                                     PollAnswer = polla.answer
                                 });
            }
            else
            {
                iePollAnswers = (from polla in entiteti.PollAnswers
                                 select new PollAnswersDb()
                                 {
                                     IdPollAnswer = polla.idPollAnswer,
                                     PollAnswer = polla.answer
                                 });
            }
            OperacijaRezultat result = new OperacijaRezultat() { Status = true, Poruka = "poll answers select" };

            result.DbItems = iePollAnswers.ToArray();
            result.CheckDbItems();

            return result;
        }
    }
    public class OpPollDeleteQuestion : OpPollQuestionSelect
    {
        public PollQuestionDb PollQuestion { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (PollQuestion != null)
                entiteti.spDeletePollQuestion(PollQuestion.IdPollQuestion);
            return base.izvrsi(entiteti);
        }
    }
    public class OpPollInsertOnlyAnswer : OpPollSelectOnlyAnswer
    {
        public PollAnswersDb Answer { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Answer != null && PollQuestion != null)
                entiteti.spInsertPollAnswer(PollQuestion.IdPollQuestion, Answer.PollAnswer);
            return base.izvrsi(entiteti);
        }
    }
    public class OpPollUpdateOnlyAnswer : OpPollSelectOnlyAnswer
    {
        public PollAnswersDb Answer { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Answer != null && PollQuestion != null)
                entiteti.spUpdatePollAnswer(Answer.IdPollAnswer, Answer.PollAnswer,Answer.IdUserLastChange);
            return base.izvrsi(entiteti);
        }
    }

    public class OpPollDeleteOnlyAnswer : OpPollSelectOnlyAnswer
    {
        public PollAnswersDb Answer { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Answer != null && PollQuestion != null)
                entiteti.spDeletePollAnswer(Answer.IdPollAnswer);
            return base.izvrsi(entiteti);
        }
    }
}