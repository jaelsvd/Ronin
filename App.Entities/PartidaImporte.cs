using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities
{
    [Table("DsPartidaImporte")]
    public class PartidaImporte
    {
        /// <summary>
        /// Identificador de la entidad
        /// </summary>
        [Key]
        public int Id { get; set;  }

        #region Propiedades Importe
        /// <summary>
        /// Clave
        /// </summary>
        
        [DisplayName("Clave")]
        public int FormaPagoClave { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        [MaxLength(250, ErrorMessage = "La descripcion debe ser menor de 250 caracteres")]
        [DisplayName("Descripción")]
        public string FormaPagoDesc { get; set; }
        /// <summary>
        /// Importe
        /// </summary>
        //[MaxLength(13, ErrorMessage = "La cantidad de los digitos debe ser menor de 13")]
        [DisplayName("Importe")]
        public decimal Importe { get; set; }
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
