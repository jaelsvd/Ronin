using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities;
using App.Entities.Reportes;
namespace App.DAL
{
   public  class ReportesRepository : Conexion
    {
        
        private ResumenPedimento _resumenPedi;
        public ReportesRepository()
        {
            
            _resumenPedi = new ResumenPedimento();
        }
        
        public List<ResumenPedimento> ResumenPedimento()
        {
            List<ResumenPedimento> listaResumenPedimento = new List<Entities.Reportes.ResumenPedimento>();

            var query = _context.Pedimentos.Select(ped => new ResumenPedimento
            {   
                Id = ped.Id,
                NumPedimento = ped.NumPedimento,
                TipoPed = ped.EncabezadoOpClave,
                Operacion = ped.EncabezadoOpDesc,
                Clave = ped.EncabezadoClavDocClave,
                CantidadPartidas = ped.CantidadPartidas,
                Patente = ped.Patente,
                FechaPago = ( _context.PedimentoImpExpFechas.Where( x => x.ImpExpFechasFechaEntradaTipoClave == 2 && x.PedimentoId == ped.Id )).Select( x=> x.ImpExpFechasFecha).FirstOrDefault(),
                ValorAduana = ped.ValorAduanaTotal,
                CURP = ped.CurpApoderadoMandatario,
               Iva = _context.PartidaImportes.Where( x=> x.PartidaGravamen.Partida.PedimentoId == ped.Id && (new string[] { "A1", "C1" }).Contains(x.PartidaGravamen.Partida.Pedimento.EncabezadoClavDocClave))
                    .Select( x=> x.Importe).Sum(),
               DTA =  _context.PedimentoTasas.Where( x => x.TasasClaveContribucionClave == 1 && x.Pedimento.Id == ped.Id).Select( x=> x.TasasImporte).Sum(),
               Multas = _context.PedimentoTasas.Where(x => x.TasasClaveContribucionClave == 11 && x.Pedimento.Id == ped.Id).Select(x => x.TasasImporte).Sum(),
               PRV = _context.PedimentoTasas.Where(x => x.TasasClaveContribucionClave == 15 && x.Pedimento.Id == ped.Id).Select(x => x.TasasImporte).Sum(),
               IGIIGE = _context.PedimentoTasas.Where(x => x.TasasClaveContribucionClave == 6 && x.Pedimento.Id == ped.Id).Select(x => x.TasasImporte).Sum(),
               ContribucionEfectivo = _context.PedimentoTasas.Where( x => x.TasasFormaPagoClave == 0 && x.Pedimento.Id == ped.Id).Select( x => x.TasasImporte).Sum()


            }).ToList() ;

            return query;
            
        }


        public List<ReporteIva> ReporteIva()
        {
            var query =

                _context.PedimentoImpExpFechas.Where(x => x.ImpExpFechasFechaEntradaTipoClave == 2
               && (new int[] { 21, 0 }).Contains(x.Pedimento.Partida.FirstOrDefault().PartidaGravamen.FirstOrDefault().PartidaImporte.FirstOrDefault().FormaPagoClave)
                ).GroupBy(g => new
                {
                    Anio = g.ImpExpFechasFecha.Year,
                    Mes = g.ImpExpFechasFecha.Month,
                    g.Pedimento.Partida.FirstOrDefault().PartidaGravamen.FirstOrDefault().PartidaImporte.FirstOrDefault().FormaPagoDesc
                }).Select(x => new ReporteIva
                {
                    Anio = x.Key.Anio,
                    Mes = x.Key.Mes,
                    FormaPagoDesc = x.Key.FormaPagoDesc,
                    Importe = _context.PartidaImportes.Where(p =>
                  (new int[] { 21, 0 }).Contains(p.FormaPagoClave)
                   && x.Key.Anio == _context.PedimentoImpExpFechas.Where(f => f.ImpExpFechasFechaEntradaTipoClave == 2 && f.PedimentoId == p.PartidaGravamen.Partida.PedimentoId).Select(f => f.ImpExpFechasFecha).FirstOrDefault().Year
                   && x.Key.Mes == _context.PedimentoImpExpFechas.Where(f => f.ImpExpFechasFechaEntradaTipoClave == 2 && f.PedimentoId == p.PartidaGravamen.Partida.PedimentoId).Select(f => f.ImpExpFechasFecha).FirstOrDefault().Month
                   && p.FormaPagoDesc == x.Key.FormaPagoDesc
                     ).Select(p => p.Importe).Sum(),

                    CantidadPedimentos = _context.PartidaImportes.Where(p =>
                  (new int[] { 21, 0 }).Contains(p.FormaPagoClave)
                   && x.Key.Anio == _context.PedimentoImpExpFechas.Where(f => f.ImpExpFechasFechaEntradaTipoClave == 2 && f.PedimentoId == p.PartidaGravamen.Partida.PedimentoId).Select(f => f.ImpExpFechasFecha).FirstOrDefault().Year
                   && x.Key.Mes == _context.PedimentoImpExpFechas.Where(f => f.ImpExpFechasFechaEntradaTipoClave == 2 && f.PedimentoId == p.PartidaGravamen.Partida.PedimentoId).Select(f => f.ImpExpFechasFecha).FirstOrDefault().Month
                   && p.FormaPagoDesc == x.Key.FormaPagoDesc
                     ).Select(p => p.PartidaGravamen.Partida.Pedimento.NumPedimento).Distinct().Count(),

                }).ToList();

            return query;
        }

        
        public List<ReporteCertificacion> ReporteCertificacion()
        {
            DateTime fecha = DateTime.Now;
            DateTime fechaFinal = new DateTime(fecha.Year, fecha.Month-1,DateTime.DaysInMonth(fecha.Year,fecha.Month-1) );
            DateTime fechaInicio = new DateTime(fechaFinal.Year-1,fechaFinal.Month,1);
            var query = _context.PedimentoImpExpFechas.Where(x => x.PedimentoId == x.Pedimento.Id 
            && x.ImpExpFechasFecha >= fechaInicio 
            && x.ImpExpFechasFecha <= fechaFinal
            && x.ImpExpFechasFechaEntradaTipoClave == 2
            )
               .GroupBy(g => new
               {
                   Anio = g.ImpExpFechasFecha.Year,
                   Mes = g.ImpExpFechasFecha.Month,

               })
                .Select(x => new ReporteCertificacion
                {
                    Anio = x.Key.Anio,
                    Mes = x.Key.Mes,

                    ImportacionValComer = _context.PedimentoImpExpFechas.Where(y =>
                       y.Pedimento.EncabezadoOpClave == 1 &&
                       y.Pedimento.EncabezadoClavDocClave == "IN" ||
                       y.Pedimento.EncabezadoClavDocClave == "V1" &&
                       y.ImpExpFechasFecha.Year == x.Key.Anio &&
                       y.ImpExpFechasFecha.Month == x.Key.Mes &&
                       y.ImpExpFechasFechaEntradaTipoClave == 2 
                       ).Select(y => y.Pedimento.ValorComercialTotal).Sum(),
                    ExportacionValComer = _context.PedimentoImpExpFechas.Where(y =>
                       y.Pedimento.EncabezadoOpClave == 2 &&
                       y.Pedimento.EncabezadoClavDocClave == "RT" ||
                       y.Pedimento.EncabezadoClavDocClave == "V1" &&
                       y.ImpExpFechasFecha.Year == x.Key.Anio &&
                       y.ImpExpFechasFecha.Month == x.Key.Mes &&
                       y.ImpExpFechasFechaEntradaTipoClave == 2
                       ).Select(y => y.Pedimento.ValorComercialTotal).Sum(),
                    ValorAgregadoImp = _context.Partidas.Where(y =>
                       y.Pedimento.EncabezadoOpClave == 1
                        ).Select(y => y.ValorAgregado).Sum(),
                    ValorAgregadoExp = _context.Partidas.Where(y =>
                       y.Pedimento.EncabezadoOpClave == 2
                        ).Select(y => y.ValorAgregado).Sum()
                }).ToList();

            return query;       
        }
        
        public List<ImpVSExp> ReporteAnalisisImpExp()
        {
          

            var query = _context.PedimentoImpExpFechas.Where(x => x.ImpExpFechasFechaEntradaTipoClave == 2 && (x.Pedimento.EncabezadoClavDocClave == "IN" || x.Pedimento.EncabezadoClavDocClave == "RT" || x.Pedimento.EncabezadoClavDocClave == "V1") )
                .GroupBy(g => new
                {
                    Anio = g.ImpExpFechasFecha.Year,
                    Clave = g.Pedimento.EncabezadoClavDocClave,
                })
                .Select(x => new ImpVSExp
                {
                    Anio = x.Key.Anio,
                    Clave = x.Key.Clave,

                    ImportacionValComercial = _context.PedimentoImpExpFechas.Where(y =>
                       y.Pedimento.EncabezadoOpClave == 1 &&
                       y.Pedimento.EncabezadoClavDocClave == "IN" ||
                       y.Pedimento.EncabezadoClavDocClave == "V1" &&
                       y.ImpExpFechasFecha.Year == x.Key.Anio &&
                       y.Pedimento.EncabezadoClavDocClave == x.Key.Clave &&
                       y.ImpExpFechasFechaEntradaTipoClave == 2
                       ).Select(y => y.Pedimento.ValorComercialTotal).Sum(),
                    ExportacionValComercial = _context.PedimentoImpExpFechas.Where(y =>
                       y.Pedimento.EncabezadoOpClave == 2 &&
                       y.Pedimento.EncabezadoClavDocClave == "RT" ||
                       y.Pedimento.EncabezadoClavDocClave == "V1" &&
                       y.ImpExpFechasFecha.Year == x.Key.Anio &&
                       y.Pedimento.EncabezadoClavDocClave == x.Key.Clave &&
                       y.ImpExpFechasFechaEntradaTipoClave == 2
                       ).Select(y => y.Pedimento.ValorComercialTotal).Sum(),
                    ValorAgregadoImp = _context.Partidas.Where(y =>
                       y.Pedimento.EncabezadoOpClave == 1 &&
                       y.Pedimento.EncabezadoClavDocClave == "IN" || 
                       y.Pedimento.EncabezadoClavDocClave == "V1"
                        ).Select(y => y.ValorAgregado).Sum(),
                    ValorAgregadoExp = _context.Partidas.Where(y =>
                       y.Pedimento.EncabezadoOpClave == 2 &&
                       y.Pedimento.EncabezadoClavDocClave == "RT" ||
                       y.Pedimento.EncabezadoClavDocClave == "V1"
                        ).Select(y => y.ValorAgregado).Sum()
                }).ToList();

            return query;
           

        }
        public List<ImpVSExpAnual> ReporteAnalisisImpExpAnual()
        {
            var query = _context.PedimentoImpExpFechas.Where(x=> x.ImpExpFechasFechaEntradaTipoClave ==2 && (x.Pedimento.EncabezadoClavDocClave == "IN" || x.Pedimento.EncabezadoClavDocClave == "RT" || x.Pedimento.EncabezadoClavDocClave == "V1"))
                .GroupBy(g => new
                {
                    Anio = g.ImpExpFechasFecha.Year,
                })
                .Select(x => new ImpVSExpAnual
                {   
                    
                    Anio = x.Key.Anio,
                    ImportacionValComercial = _context.PedimentoImpExpFechas.Where(y =>
                        y.Pedimento.EncabezadoOpClave == 1 &&
                        y.Pedimento.EncabezadoClavDocClave == "IN" ||
                        y.Pedimento.EncabezadoClavDocClave == "V1" &&
                        y.ImpExpFechasFecha.Year == x.Key.Anio &&
                        y.ImpExpFechasFechaEntradaTipoClave == 2
                        ).Select(y => y.Pedimento.ValorComercialTotal).Sum(),
                    ExportacionValComercial = _context.PedimentoImpExpFechas.Where(y =>
                        y.Pedimento.EncabezadoOpClave == 2 &&
                        y.Pedimento.EncabezadoClavDocClave == "RT" ||
                        y.Pedimento.EncabezadoClavDocClave == "V1" &&
                        y.ImpExpFechasFecha.Year == x.Key.Anio &&
                        y.ImpExpFechasFechaEntradaTipoClave == 2
                        ).Select(y => y.Pedimento.ValorComercialTotal).Sum(),
                    ValorAgregadoImp = _context.Partidas.Where(y =>
                        y.Pedimento.EncabezadoOpClave == 1 &&
                        y.Pedimento.EncabezadoClavDocClave == "IN" ||
                        y.Pedimento.EncabezadoClavDocClave == "V1" &&
                        y.Pedimento.PedimentoImpExpFechas.Where(z=> z.ImpExpFechasFechaEntradaTipoClave ==2 ).Select(z=> z.ImpExpFechasFecha).FirstOrDefault().Year   == x.Key.Anio
                        ).Select(y => y.ValorAgregado).Sum(),
                    ValorAgregadoExp = _context.Partidas.Where(y =>
                        y.Pedimento.EncabezadoOpClave == 2 &&
                        y.Pedimento.EncabezadoClavDocClave == "RT" || 
                        y.Pedimento.EncabezadoClavDocClave == "V1" &&
                        y.Pedimento.PedimentoImpExpFechas.Where(z => z.ImpExpFechasFechaEntradaTipoClave == 2).Select(z => z.ImpExpFechasFecha).FirstOrDefault().Year == x.Key.Anio
                        ).Select(y => y.ValorAgregado).Sum()
                }).ToList();

            return query;
        }

       
    }
}

