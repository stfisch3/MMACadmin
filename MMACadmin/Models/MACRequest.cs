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
    
    public partial class MACRequest
    {
        public int MACID { get; set; }
        public string AccSystem { get; set; }
        public string AccEnv { get; set; }
        public string AccGroup { get; set; }
        public string AccServer { get; set; }
        public string AccDB { get; set; }
        public string AccJust { get; set; }
        public bool isElevated { get; set; }
        public string ReqSetID { get; set; }
    
        public virtual ReqSet ReqSet { get; set; }
    }
}