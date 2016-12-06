using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPartidaMetodoValoracion")]
    public class PartidaMetodoValoracion
    {
        [Key]
        public int Id { get; set; }
        #region Metodo de Valoracion
        /// <summary>
        /// Descripcion
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripcion debe ser menor de 250 caracteres")]
        [DisplayName("Descripción")]
        public string MetodoValorDesc { get; set; }
        public int MetodoValorClave { get; set; }
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
