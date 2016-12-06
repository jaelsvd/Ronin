using App.Entities;
using System.Collections.Generic;
using App.Entities.Reportes;

namespace App.ViewModels
{
    public class ReporteImpExpViewModel
    {
        #region Constructor
        public ReporteImpExpViewModel()
        {
            ImpVSExp = new List<ImpVSExp>();
            ImpVSExpAnual = new List<ImpVSExpAnual>();
        }
        #endregion

        #region Propiedades

        public List<ImpVSExp> ImpVSExp { get; set; }
        public List<ImpVSExpAnual> ImpVSExpAnual { get; set; }


        #endregion

    }
}