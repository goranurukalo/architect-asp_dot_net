//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebSiteASP.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class PollQuestion
    {
        public PollQuestion()
        {
            this.PollAnswers = new HashSet<PollAnswer>();
        }
    
        public int idPollQuestion { get; set; }
        public string question { get; set; }
        public Nullable<int> idLastUserChange { get; set; }
        public Nullable<System.DateTime> LastTimeChange { get; set; }
    
        public virtual ICollection<PollAnswer> PollAnswers { get; set; }
    }
}