using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSiteASP.DataLayer;

namespace WebSiteASP.BusinessLayer
{
    public class PollVoteDb : DbItem
    {
        public int IdAnswer{ get; set; }
        public string IpAddress { get; set; }
        public int IdQuestion { get; set; }
        public int? IdUserLastChange { get; set; }
        public DateTime? LastTimeChanged { get; set; }

    }
    public class OpPollVoteInsert : Operacija
    {
        public PollVoteDb Vote { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            int num = (from votes in entiteti.PollVotes
                       join answer in entiteti.PollAnswers on votes.idAnswer equals answer.idPollAnswer
                       where Vote.IpAddress == votes.ipAddress && Vote.IdQuestion == answer.idPollQuestion
                      select votes).Count();
            OperacijaRezultat result = new OperacijaRezultat() { Poruka = "inserting poll vote" };
            if (num == 0)
            {
                entiteti.spInsertPollVote(Vote.IpAddress, Vote.IdAnswer);
                result.Status = true;
            }
            else
            {
                result.Status = false;
            }
            
            return result;
        }
    }
}