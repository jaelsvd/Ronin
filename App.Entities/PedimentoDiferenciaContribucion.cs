using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPedimentoDiferenciaContribucion")]
    public class PedimentoDiferenciaContribucion
    {
        [Key]
        public int Id { get; set; }
        public decimal ImportePago { get; set; }
        public int ClaveGravamen1Clave { get; set; }
        public string ClaveGravamen1Desc { get; set; }
        public int FormaPagoClave { get; set; }
        public string FormaPagoDesc { get; set; }

        #region Relaciones
        /// <summary>
        /// Llave Foranea Pedimento
        /// </summary>
        public int PedimentoId { get; set; }
        public virtual Pedimento Pedimento { get; set; }
        #endregion

    }
}
