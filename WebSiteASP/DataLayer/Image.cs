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
    
    public partial class Image
    {
        public int idImage { get; set; }
        public int idProject { get; set; }
        public string smallPictureUrl { get; set; }
        public string bigPictureUrl { get; set; }
        public string imgAlt { get; set; }
        public string imageName { get; set; }
        public Nullable<int> idLastUserChange { get; set; }
        public Nullable<System.DateTime> LastTimeChange { get; set; }
    
        public virtual Project Project { get; set; }
    }
}
