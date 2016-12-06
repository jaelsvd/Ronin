using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPartidaIdentificador")]
    public class PartidaIdentificador
    {   
        /// <summary>
        /// Identifiador de la tabla Partida Identificador
        /// </summary>
        [Key]
        public int Id { get; set; }
    

        #region Propiedades Identificadores
        #region Clave Identifcador
        /// <summary>
        /// Clave 
        /// </summary>
        [StringLength(2, ErrorMessage = "La clave del identificador tiene que ser de 2 digitos")]
        public string IdentificadorClaveIdentificadorClave { get; set; }
        /// <summary>
        ///  Descripcion
        /// </summary>
        [MaxLength(250, ErrorMessage = "La descripcion debe ser menor de 250")]
        public string IdentificadorClaveIdentificadorDesc { get; set; }
        #endregion
        /// <summary>
        /// Complemento 1
        /// </summary>
        [MaxLength(20, ErrorMessage = "El complemento debe tener 20 caracteres")]
        public string IdentificadorComplemento1 { get; set; }

        /// <summary>
        /// Complemento 2
        /// </summary>
        [MaxLength(30, ErrorMessage = "El complemento debe tener 30 caracteres")]
        public string IdentificadorComplemento2 { get; set; }

        /// <summary>
        /// Complemento 3
        /// </summary>
        [MaxLength(40, ErrorMessage = "El complemento debe tener 40 caracteres")]
        public string IdentificadorComplemento3 { get; set; }
        #endregion

        /// <summary>
        /// Fecha de registro en la Base de Datos
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        #region Relaciones
        /// <summary>
        /// Llave Foranea Pedimento
        /// </summary>
        public int PartidaId { get; set; }
        public virtual Partida Partida { get; set; }
        #endregion
    }
}
