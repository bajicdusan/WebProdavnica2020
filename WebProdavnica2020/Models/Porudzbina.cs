﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProdavnica2020.Models
{
    [Table("Porudzbina")]
    public partial class Porudzbina
    {
        public Porudzbina()
        {
            Stavke = new HashSet<Stavka>();
        }

        [Key]
        public int PorudzbinaId { get; set; }
        [Required]
        [StringLength(450)]
        public string KupacId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DatumKupovine { get; set; }

        [ForeignKey(nameof(KupacId))]
        [InverseProperty("Porudzbine")]
        public virtual Kupac Kupac { get; set; }
        [InverseProperty(nameof(Stavka.Porudzbina))]
        public virtual ICollection<Stavka> Stavke { get; set; }
    }
}