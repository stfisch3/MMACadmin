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
    
    public partial class Env
    {
        public Env()
        {
            this.ReqSets = new HashSet<ReqSet>();
        }
    
        public int EnvID { get; set; }
        public string EnvName { get; set; }
    
        public virtual ICollection<ReqSet> ReqSets { get; set; }
    }
}
