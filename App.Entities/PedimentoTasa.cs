using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPedimentoTasa")]
    public class PedimentoTasa
    {

        /// <summary>
        /// Id de tabla Pedimentotasa
        /// </summary>
        [Key]
        public int Id { get; set; }

        #region Tasas a Nivel de Pedimento y Cuadro de Liquidación
        /// <summary>
        /// Tasa Aplicable
        /// </summary>
        public decimal TasasTasaAplicable { get; set; }
        /// <summary>
        /// Importe
        /// </summary>
        public decimal TasasImporte { get; set; }

        #region claveContribucion
        /// <summary>
        /// Clave de contribución en tasas
        /// </summary>
        public int TasasClaveContribucionClave { get; set; }
        /// <summary>
        /// Descripcion de Tasas Contribución
        /// </summary>
        [MaxLength(250, ErrorMessage = "La descripción no debe ser mayor de 250 carácteres")]
        public string TasasClaveContribucionDesc { get; set; }

        #endregion

        #region tipo de tasa
        /// <summary>
        /// Clave de Tipo Tasa
        /// </summary>
        public int TasasTipoTasaClave { get; set; }
        /// <summary>
        /// Descripción de forma de tipo tasa
        /// </summary>
        [MaxLength(250, ErrorMessage = "La descripción no debe ser mayor de 250 carácteres")]
        public string TasasTipoTasaDesc { get; set; }

        #endregion

        #region formaPago
        /// <summary>
        /// Clave de Tipo de forma de Pago
        /// </summary>
        public int TasasFormaPagoClave { get; set; }
        /// <summary>
        /// Descripción de forma de pago
        /// </summary>
        [MaxLength(250, ErrorMessage = "La descripción no debe ser mayor de 250 carácteres")]
        public string TasasFormaPagoDesc { get; set; }

        #endregion

        #endregion

        #region Relaciones
        /// <summary>
        /// Llave Foranea Pedimento
        /// </summary>
        public int PedimentoId { get; set; }
        public virtual Pedimento Pedimento { get; set; }
        #endregion
    }
}
