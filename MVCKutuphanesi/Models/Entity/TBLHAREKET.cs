//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCKutuphanesi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLHAREKET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLHAREKET()
        {
            this.TBLCEZALAR = new HashSet<TBLCEZALAR>();
        }
    
        public int ID { get; set; }
        public Nullable<int> KITAP { get; set; }
        public Nullable<int> UYE { get; set; }
        public Nullable<int> PERSONEL { get; set; }
        public Nullable<System.DateTime> ALISTARIHI { get; set; }
        public Nullable<System.DateTime> IADETARIHI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLCEZALAR> TBLCEZALAR { get; set; }
        public virtual TBLKITAP TBLKITAP { get; set; }
        public virtual TBLUYE TBLUYE { get; set; }
    }
}
