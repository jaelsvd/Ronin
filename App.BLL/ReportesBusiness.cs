using App.DAL;
using App.Entities;
using App.Entities.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL
{
   public class ReportesBusiness
    {
        private PartidaRepository _partidaRepo;
        private PedimentoRepository _pedimentoRepo;
        private ReportesRepository _reporteRepo;
       
        public ReportesBusiness()
        {
            _partidaRepo = new PartidaRepository();
            _pedimentoRepo = new PedimentoRepository();
            _reporteRepo = new ReportesRepository();          
        }
        public List<ResumenPedimento> ResumenPedimento()
        {
            return _reporteRepo.ResumenPedimento();
        }

        public List<ReporteIva> ReporteIva()
        {
            return _reporteRepo.ReporteIva();
        }

        public List<ReporteCertificacion> TraerReporteCertificacion()
        {
            List<ReporteCertificacion> listaVacia = new List<ReporteCertificacion>();

            var reporte = _reporteRepo.ReporteCertificacion();

            foreach (var operacion in reporte)
            {
                operacion.Importacion = operacion.ImportacionValComer - operacion.ValorAgregadoImp;
                operacion.Exportacion = operacion.ExportacionValComer - operacion.ValorAgregadoExp;

                listaVacia.Add(operacion);
            }

            return listaVacia;
        }
        public List<ImpVSExp> TraerReporteImpVsExp()
        {
            List<ImpVSExp> listaVacia = new List<ImpVSExp>();

            var reporte = _reporteRepo.ReporteAnalisisImpExp();


            foreach ( var operacion in reporte)
            {
                operacion.Importacion = operacion.ImportacionValComercial - operacion.ValorAgregadoImp;
                operacion.Exportacion = operacion.ExportacionValComercial - operacion.ValorAgregadoExp;
                listaVacia.Add(operacion);
            }
            return listaVacia;
        }
        public List<ImpVSExpAnual> TraerReporteImpVsExpAnual()
        {
            List<ImpVSExpAnual> listaVacia = new List<ImpVSExpAnual>();

            var reporte = _reporteRepo.ReporteAnalisisImpExpAnual();

            foreach (var operacion in reporte)
            {
                operacion.Exportacion = operacion.ExportacionValComercial - operacion.ValorAgregadoExp;
                operacion.Importacion = operacion.ImportacionValComercial - operacion.ValorAgregadoImp;
                operacion.ExportConVAMenosImport = operacion.ExportacionValComercial - operacion.Importacion;
                operacion.ExportSinVAMenosImport = operacion.Exportacion - operacion.Importacion;
                listaVacia.Add(operacion);
            }
            return listaVacia;
        }

        public List<Pedimento> ReporteFacturas()
        {
            return _pedimentoRepo.TraerTodo();
        }

    }
}
