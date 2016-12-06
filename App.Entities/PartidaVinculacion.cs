using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPartidaVinculacion")]
    public class PartidaVinculacion
    {
        [Key]
        public int Id { get; set; }
        #region Vinculacion
        /// <summary>
        /// Descripcion
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripcion debe ser menor de 250 caracteres")]
        [DisplayName("Descripción")]
        public string VinculacionDesc { get; set; }
        public int VinculacionClave { get; set; }
        #endregion

        #region Relacion
        /// <summary>
        /// Llave Foranea Partida
        /// </summary>
        public int PartidaId { get; set; }
        public virtual Partida Partida { get; set; }
        #endregion
    }
}
