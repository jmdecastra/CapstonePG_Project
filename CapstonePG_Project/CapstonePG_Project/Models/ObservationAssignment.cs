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
    
    public partial class ObservationAssignment
    {
        public ObservationAssignment()
        {
            this.CycleFrequencies = new HashSet<CycleFrequency>();
        }
    
        public string obsAssignmentID { get; set; }
        public string observationSheetID { get; set; }
        public string obsAssignmentDesc { get; set; }
        public System.DateTime assignmentTime { get; set; }
        public int obsAssignmentSeq { get; set; }
    
        public virtual ICollection<CycleFrequency> CycleFrequencies { get; set; }
        public virtual ObservationSheet ObservationSheet { get; set; }
    }
}
