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
    
    public partial class Warehouse
    {
        public Warehouse()
        {
            this.MachineTiming = new HashSet<MachineTiming>();
            this.ObservationSheets = new HashSet<ObservationSheet>();
            this.PreferredMethods = new HashSet<PreferredMethod>();
            this.WarehouseMethods = new HashSet<WarehouseMethod>();
        }
    
        public string whID { get; set; }
        public string whName { get; set; }
        public string whUpperLeftX { get; set; }
        public string whUpperLeftY { get; set; }
        public string whLowerRightX { get; set; }
        public string whLowerRightY { get; set; }
        public string whAisleIDLength { get; set; }
        public string whBayIDLength { get; set; }
        public string whPostIDLength { get; set; }
        public string whNamingOrder { get; set; }
    
        public virtual ICollection<MachineTiming> MachineTiming { get; set; }
        public virtual ICollection<ObservationSheet> ObservationSheets { get; set; }
        public virtual ICollection<PreferredMethod> PreferredMethods { get; set; }
        public virtual ICollection<WarehouseMethod> WarehouseMethods { get; set; }
    }
}
