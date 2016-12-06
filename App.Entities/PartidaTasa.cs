using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPartidaTasa")]
    public class PartidaTasa
    {
        /// <summary>
        /// Identificador de la tabla PartidaTasa
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        #region Tipo de Tasa
        /// <summary>
        /// Clave
        /// </summary>
        public int TasaClave { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        [MaxLength(250, ErrorMessage = "La descripcion debe ser menor de 250 caracteres")]
        public string TasaDesc { get; set; }
        /// <summary>
        /// Tasa Aplicable
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TasaAplicable { get; set; }

        #endregion

        /// <summary>
        /// Error
        /// </summary>
        public bool TieneError { get; set; }


        #region Relacion
        /// <summary>
        /// Llave Foranea Partida
        /// </summary>
        public int PartidaGravamenId { get; set; }
        public virtual PartidaGravamen PartidaGravamen { get; set; }
        #endregion
    }
}
