using App.Entities;
using App.Entities.Dashboard;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            Dashboard = new List<Dashboard>();
            Pedimento = new List<Pedimento>();
        }
        public List<Dashboard> Dashboard { get; set; } 
        public List<Pedimento> Pedimento { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Importacion { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Exportacion { get; set; }
        public decimal ImportacionValComercial { get; set; }
        public decimal ExportacionValComercial { get; set; }
        public decimal ValorAgregadoImp { get; set; }
        public decimal ValorAgregadoExp { get; set; }

    }
}