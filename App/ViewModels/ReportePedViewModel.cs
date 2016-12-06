using App.Entities;
using System.Collections.Generic;

namespace App.ViewModels
{
    public class ReportePedViewModel
    {
        #region Constructores
        public ReportePedViewModel()
        {
            Pedimento = new List<Pedimento>();
            PedimentoTasa = new List<PedimentoTasa>();
            PartidaTasa = new List<PartidaTasa>();
            PartidaGravamen = new List<PartidaGravamen>();
        }
        #endregion

        #region Propiedades
        public List<Pedimento> Pedimento { get; set; }
        public List<PedimentoTasa> PedimentoTasa { get; set; }
        public List<PartidaTasa> PartidaTasa { get; set; }
        public List<PartidaGravamen> PartidaGravamen { get; set; }
        public List<decimal> Iva { get; set; }
        #endregion

    }
}