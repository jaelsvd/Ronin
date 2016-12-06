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
    [Table("DsPartidaGravamen")]
    public class PartidaGravamen
    {
        public PartidaGravamen()
        {
            this.PartidaTasa = new HashSet<PartidaTasa>();
            this.PartidaImporte = new HashSet<PartidaImporte>();
        }

        /// <summary>
        /// Identificador de la tabla
        /// </summary>
        [Key]
        public int Id { get; set; }
        #region  Propiedades Gravamenes

        /// <summary>
        /// Clave 
        /// </summary>
        
        [DisplayName("Clave")]
        public int ClaveGravamenClave { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        [MaxLength(250, ErrorMessage = "La descripcion debe ser menor de 250 caracteres")]
        [DisplayName("Descripción")]
        public string ClaveGravamenDesc { get; set; }

        #endregion

        /// <summary>
        /// Error
        /// </summary>
        public bool TieneError { get; set; }
        /// <summary>
        /// Fecha de registro en la Base de Datos 
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        #region Relaciones
        /// <summary>
        /// Llave foranea Partida
        /// </summary>
        public int PartidaId { get; set; }
        public Partida Partida { get; set; }

        public virtual ICollection<PartidaTasa> PartidaTasa { get;set;}
        public virtual ICollection<PartidaImporte> PartidaImporte { get; set; }

        #endregion
    }
}
