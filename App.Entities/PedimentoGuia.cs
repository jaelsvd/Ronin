using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace App.Entities
{
    [Table("DsPedimentoGuia")]
    public class PedimentoGuia
    {
        [Key]
        public int Id { get; set; }

        public string GuiaManifesto { get; set; }

        public string TipoGuia { get; set; }



        #region Relaciones
        /// <summary>
        /// Llave Foranea Pedimento
        /// </summary>
        public int PedimentoId { get; set; }
        public virtual Pedimento Pedimento { get; set; }
        #endregion
    }
}
