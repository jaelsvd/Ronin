using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPartidaDatosVehiculo")]
    public class PartidaDatosVehiculo
    {
        [Key]
        public int Id { get; set; }

        public string VinNumeroSerie { get; set; }
        public long Kilometraje { get; set; }


        #region Relacion
        /// <summary>
        /// Llave foranea Partida
        /// </summary>
        public int PartidaId { get; set; }
        public Partida Partida { get; set; }
        #endregion
    }
}
