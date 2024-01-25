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
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Betyg
    {

        public int BetygID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> KursID { get; set; }
        public Nullable<int> LarareID { get; set; }
        public Nullable<int> Betyget { get; set; }
        public Nullable<System.DateTime> SattDatum { get; set; }

        [ForeignKey("KursID")]
        public virtual Kurser Kurser { get; set; }

        [ForeignKey("LarareID")]
        public virtual Personal Personal { get; set; }

        [ForeignKey("StudentID")]
        public virtual Studenter Studenter { get; set; }

    }
}