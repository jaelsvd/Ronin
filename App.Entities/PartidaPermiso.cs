using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPartidaPermiso")]
    public class PartidaPermiso
    {
        [Key]
        public int Id { get; set; }
        public string PermisoClave { get; set; }
        public string PermisoDesc { get; set; }
        public string NumeroPermiso { get; set; }
        public string FirmaDescargo { get; set; }
        public decimal ValorComercialEnDolar { get; set; }
        public decimal CantidadUMTUMC { get; set; }

        #region Relacion
        /// <summary>
        /// Llave Foranea Partida
        /// </summary>
        public int PartidaId { get; set; }
        public virtual Partida Partida { get; set; }
        #endregion
    }
}
