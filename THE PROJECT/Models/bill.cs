//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace THE_PROJECT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bill()
        {
            this.billsDetails = new HashSet<billsDetail>();
        }
    
        public int id { get; set; }
        public System.DateTime date { get; set; }
        public string notes { get; set; }
        public int customers_id { get; set; }
        public decimal total { get; set; }
        public Nullable<decimal> discount { get; set; }
        public decimal total_af_dis { get; set; }
        public int users_id { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<billsDetail> billsDetails { get; set; }
    }
}
