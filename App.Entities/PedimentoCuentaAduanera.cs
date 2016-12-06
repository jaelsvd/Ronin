using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPedimentoCuentaAduanera")]
    public class PedimentoCuentaAduanera
    {
        [Key]
        public int Id { get; set; }

        public int InstEmisoraClave { get; set; }
        public string InstEmisoraDesc { get; set; }
        public string InstEmisoraNumCuenta { get; set; }
        public string InstEmisoraFolioConstancia { get; set; }
        public DateTime? FechaConstancia { get; set; }
        public string TipoCuentaDesc { get; set; }
        public string TipoGarantiaDesc { get; set; }
        public decimal CuentaTotalGarantia { get; set; }
        public decimal CuentaCantidadUMC { get; set; }


        #region Relaciones
        /// <summary>
        /// Llave Foranea Pedimento
        /// </summary>
        public int PedimentoId { get; set; }
        public virtual Pedimento Pedimento { get; set; }
        #endregion
    }
}
