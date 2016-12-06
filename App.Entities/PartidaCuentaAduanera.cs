using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPartidaCuentaAduanera")]
    public class PartidaCuentaAduanera
    {
        [Key]
        public int Id { get; set; }

        public int InsEmClave { get; set; }
        public string InsEmDescripcion { get; set; }
        public int NumCuenta { get; set; }
        public string FolioConstancia { get; set; }
        public DateTime? FechaConstancia { get; set; }
        public string TipoCuentaDesc { get; set; }
        public string TipoGarantia { get; set; }
        public decimal GarantiaTotalGarantia { get; set; }
        public decimal GarantiaCantidadUMC { get; set; }


        #region Relacion
        /// <summary>
        /// Llave Foranea Partida
        /// </summary>
        public int PartidaId { get; set; }
        public virtual Partida Partida { get; set; }
        #endregion
    }
}
