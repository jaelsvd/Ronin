using System;
using System.Collections.Generic;
using System.Linq;
using App.Entities.Dashboard;
using App.Entities;



namespace App.DAL
{
    public class DashboardRepository : Conexion
    {
        #region Instancias
       
        #endregion

        #region Constructor
        public DashboardRepository()
        {
          
        }
        #endregion

        public List<Dashboard> TraerValores()
        {


            var query = _context.Pedimentos.Where(x=> x.EncabezadoClavDocClave == "IN" ||
            x.EncabezadoClavDocClave == "RT" ||
            x.EncabezadoClavDocClave == "V1")
            .Select(x => new Dashboard
                {
                   
                    ImportacionValComercial = _context.Pedimentos.Where(y =>
                       y.EncabezadoOpClave == 1 &&
                       y.EncabezadoClavDocClave == "IN" ||
                       y.EncabezadoClavDocClave == "V1" 
                       ).Select(y => y.ValorComercialTotal).Sum(),
                    ExportacionValComercial = _context.Pedimentos.Where(y =>
                       y.EncabezadoOpClave == 2 &&
                       y.EncabezadoClavDocClave == "RT" ||
                       y.EncabezadoClavDocClave == "V1" 
                       ).Select(y => y.ValorComercialTotal).Sum(),
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

        public List<Pedimento> TraerPedimentos()
        {
            return _context.Pedimentos.OrderBy(x => x.FechaCreacion).ToList();
        }

    }
}
