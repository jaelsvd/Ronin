using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPedimentoDestinatario")]
    public class PedimentoDestinatario
    {
        [Key]
        public int Id { get; set; }

        public string IdFiscal { get; set; }
        public string NombreDestinatario { get; set; }
        public string Calle { get; set; }
        public string NumExt { get; set; }
        public string NumInt { get; set; }
        public string CdMunicipio { get; set; }
        public string CP { get; set; }
        public string EntidadFederativa { get; set; }
        public string PaisClave { get; set; }
        public string PaisDesc { get; set; }


        #region Relaciones
        /// <summary>
        /// Llave Foranea Pedimento
        /// </summary>
        public int PedimentoId { get; set; }
        public virtual Pedimento Pedimento { get; set; }
        #endregion
    }
}
