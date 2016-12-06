using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPedimentoTransporte")]
    public class PedimentoTransporte
    {
        [Key]
        public int Id { get; set; }
        public string IdentificadorTransporte { get; set; }
        public string PaisTransporteClave { get; set; }
        public string PaisTransporteDesc { get; set; }
        public string NombreTransporte { get; set; }
        public string RFCTransporte { get; set; }
        public string CURPTransportista { get; set; }
        public string DomFiscalTransportista { get; set; }
        public string CandadosTransporte { get; set; }
        #region Relaciones
        /// <summary>
        /// Llave Foranea Pedimento
        /// </summary>
        public int PedimentoId { get; set; }
        public virtual Pedimento Pedimento { get; set; }
        #endregion
    }
}
