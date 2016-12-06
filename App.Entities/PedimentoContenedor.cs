using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPedimentoContenedor")]
    public class PedimentoContenedor
    {
        [Key]
        public int Id { get; set; }

        public string IdContenedor { get; set; }
        public int TipoContenerdorClave { get; set; }
        public string TipoContenedorDesc { get; set; }


        #region Relaciones
        /// <summary>
        /// Llave Foranea Pedimento
        /// </summary>
        public int PedimentoId { get; set; }
        public virtual Pedimento Pedimento { get; set; }
        #endregion
    }
}
