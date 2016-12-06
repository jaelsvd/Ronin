using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPedimentoImpExpFechas")]
    public class PedimentoImpExpFechas
    {
        [Key]
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd} HH:mm:ss", ApplyFormatInEditMode = true)]
        public DateTime ImpExpFechasFecha { get; set; }
        [DisplayName("Clave")]
        public int ImpExpFechasFechaEntradaTipoClave { get; set; }
        [DisplayName("Descripción")]
        public string ImpExpFechasFechaTipoDesc { get; set; }

        
        #region Relaciones
        /// <summary>
        /// Llave foranea de Pedimento
        /// </summary>
        public int PedimentoId { get; set; }
        public virtual Pedimento Pedimento { get; set; }
        #endregion
    }
}
