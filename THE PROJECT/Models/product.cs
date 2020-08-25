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
    using CsvHelper.Configuration.Attributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.billsDetails = new HashSet<billsDetail>();
        }
    
        public int id { get; set; }
        [Required(ErrorMessage = "please inseart the name of product")]
        public string name { get; set; }
        
       
        public string code { get; set; }
        [Range(500,20000 )]
        public Nullable<decimal> price { get; set; }
        public Nullable<int> quantity { get; set; }
        public string notes { get; set; }
        public string image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<billsDetail> billsDetails { get; set; }
    }
}
