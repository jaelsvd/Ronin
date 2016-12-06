using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPedimentoIdentificador")]
    public class PedimentoIdentificador
    {
        /// <summary>
        /// Identificador de la tabla
        /// </summary>
        [Key]
        public int Id { get; set; }

        #region Identificadores

        [StringLength(20)]
        public string IdentificadorComplemento1 { get; set; }
        [StringLength(30)]
        public string IdentificadorComplemento2 { get; set; }
        [StringLength(40)]
        public string IdentificadorComplemento3 { get; set; }


        #region Claveidentificador
        [StringLength(2)]
        public string ClaveIdentificadorClave { get; set; }
        [MaxLength(250, ErrorMessage = "La descripción no debe ser mayor de 250 carácteres")]
        public string ClaveIdentificadorDesc { get; set; }

        #endregion

        #endregion


        #region Relaciones
        /// <summary>
        /// LLave Foranea Pedimento
        /// </summary>
        public int PedimentoId { get; set; }
        public virtual Pedimento Pedimento { get; set; }
        #endregion
    }
}
