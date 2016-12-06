using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPedimentoDescargo")]
    public class PedimentoDescargo
    {
        [Key]
        public int Id { get; set; }

        public int PatenteOriginal { get; set; }
        public int PedimentoOriginal { get; set; }
        public int AduanaOrigClave { get; set; }
        public string AduanaOrigDesc { get; set; }
        public string ClaveDocOrigClave { get; set; }
        public string ClaveDocOrigDesc { get; set; }
        public DateTime? FechaPagoOriginal { get; set; }
        public string FraccionOriginal { get; set; }
        public string UnidadMedOrigClave { get; set; }
        public string UnidadMedOrigDesc { get; set; }
        public decimal Cantidad { get; set; }

        #region Relaciones
        /// <summary>
        /// Llave Foranea Pedimento
        /// </summary>
        public int PedimentoId { get; set; }
        public virtual Pedimento Pedimento { get; set; }
        #endregion
    }
}
