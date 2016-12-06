namespace App.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class AgentesAduanales
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255)]
        public string RepLegal { get; set; }

        [Required]
        [StringLength(4)]
        public string Patente { get; set; }

        [StringLength(20)]
        public string TaxID { get; set; }

        public bool Broker { get; set; }

        public bool CTPAT { get; set; }

        public bool OEA { get; set; }
    }
}
