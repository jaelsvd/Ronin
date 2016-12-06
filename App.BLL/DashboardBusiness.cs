using App.DAL;
using App.Entities;
using App.Entities.Dashboard;
using System.Collections.Generic;

namespace App.BLL
{

    public class DashboardBusiness
    {
        private PartidaRepository _partidaRepo;
        private PedimentoRepository _pedimentoRepo;
        private ReportesRepository _reporteRepo;
        private DashboardRepository _dashboardRepo;
        

        public DashboardBusiness()
        {
            _partidaRepo = new PartidaRepository();
            _pedimentoRepo = new PedimentoRepository();
            _reporteRepo = new ReportesRepository();
            _dashboardRepo = new DashboardRepository();
        }

        public List<Dashboard> TraerImpExp()
        {
            List<Dashboard> listaVacia = new List<Dashboard>();

            var reporte = _dashboardRepo.TraerValores();

            foreach (var operacion in reporte)
            {
               
                operacion.Importacion = operacion.ImportacionValComercial - operacion.ValorAgregadoImp;
                operacion.Exportacion = operacion.ExportacionValComercial - operacion.ValorAgregadoExp;

                listaVacia.Add(operacion);
            }

            return listaVacia;
        }

        public decimal TraerImportacion()
        {
            decimal importacion = 0;
            var reporte = _dashboardRepo.TraerValores();
            

            foreach(var operacion in reporte)
            {
                operacion.Importacion = operacion.ImportacionValComercial - operacion.ValorAgregadoImp;

                importacion= operacion.Importacion;        
            }
            
            return importacion;
        }

        public decimal TraerExportacion()
        {
            decimal exportacion = 0;

            var reporte = _dashboardRepo.TraerValores();

            foreach(var operacion in reporte)
            {
                operacion.Exportacion = operacion.ExportacionValComercial - operacion.ValorAgregadoExp;

                exportacion = operacion.Exportacion;
            }

            return exportacion;
        }

        public List<Pedimento> TraerPerimentos()
        {
            return _dashboardRepo.TraerPedimentos();
        }

    }
}
