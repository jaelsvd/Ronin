using App.Entities;
using System.Collections.Generic;

namespace App.ViewModels
{
    public class ReportePartViewModel
    {
        #region Constructor
        public ReportePartViewModel()
        {
            Pedimento = new List<Pedimento>();
            Partida = new List<Partida>();
        }
        #endregion

        #region Propiedades
        public List<Pedimento> Pedimento { get; set; }
        public List<Partida> Partida { get; set; }
        #endregion
    }
}