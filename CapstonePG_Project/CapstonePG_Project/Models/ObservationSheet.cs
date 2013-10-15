//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapstonePG_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ObservationSheet
    {
        public ObservationSheet()
        {
            this.ObservationAssignments = new HashSet<ObservationAssignment>();
            this.ObservationTransactions = new HashSet<ObservationTransaction>();
        }
    
        public string observationSheetID { get; set; }
        public string whID { get; set; }
        public string prefMethID { get; set; }
        public string observationSheetName { get; set; }
        public string observatuonSheetDesc { get; set; }
        public bool warningFlag { get; set; }
    
        public virtual ICollection<ObservationAssignment> ObservationAssignments { get; set; }
        public virtual PreferredMethod PreferredMethod { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<ObservationTransaction> ObservationTransactions { get; set; }
    }
}
