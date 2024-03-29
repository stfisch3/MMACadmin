//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MMACadmin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjectRelease
    {
        public ProjectRelease()
        {
            this.ReqSets = new HashSet<ReqSet>();
        }
    
        public int ReleaseID { get; set; }
        public string ReleaseName { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string Owner { get; set; }
        public string BackUpOwner { get; set; }
        public int ProjectID { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual ICollection<ReqSet> ReqSets { get; set; }
    }
}
