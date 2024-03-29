//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace efattempt1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Personal
    {
        private string userRole;
        private string firstName;
        private string lastName;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personal()
        {
            this.Betygs = new HashSet<Betyg>();
        }

        public Personal(string userRole, string firstName, string lastName, string personnummer,int nextid)
        {
            Befattning = userRole;
            PersonID = nextid;
            Förnamn = firstName;
            Efternamn = lastName;
            Personnummer = personnummer;
        }

        [Key]
        public int PersonID { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Personnummer { get; set; }
        public string Befattning { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Betyg> Betygs { get; set; }
    }
}
