using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPedimentoFactura")]
    public class PedimentoFactura
    {
        [Key]
        public int Id { get; set; }

        public DateTime? FechaFacturacion { get; set; }
        public string NumeroFactura { get; set; }
        public string TerminoFacturacionClave { get; set; }
        public string TerminoFacturacionDesc { get; set; }
        public string MonedaClave { get; set; }
        public string MonedaDesc { get; set; }
        public decimal ValDolares { get; set; }
        public decimal ValMonedaExt { get; set; }

        public string IdFiscalProvComp { get; set; }
        public string ProveedorComp { get; set; }

        #region Relaciones
        /// <summary>
        /// Llave Foranea Pedimento
        /// </summary>
        public int PedimentoId { get; set; }
        public virtual Pedimento Pedimento { get; set; }
        #endregion
    }
}
