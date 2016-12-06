using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.BLL;
using App.ViewModels;

namespace App.Controllers
{
    [Authorize]
    public class ReportesController : Controller
    {
        PedimentoBusiness _pedimentoBll;
        PartidaBusiness _partidaBll;
        ReportesBusiness _reporteBll;
        ReporteImpExpViewModel _reporteImpExPmodel;
        BaseBusiness _baseBll;
        public ReportesController()
        {
            _pedimentoBll = new PedimentoBusiness();
            _partidaBll = new PartidaBusiness();
            _reporteBll = new ReportesBusiness();
            _reporteImpExPmodel = new ReporteImpExpViewModel();
            _baseBll = new BaseBusiness();

        }
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ResumenPedimento()
        {
            _baseBll.obtenerEmpresa();
            //ReportePedViewModel pedimentoModel = new ReportePedViewModel();
            //pedimentoModel.Pedimento = _pedimentoBll.TraerTodo();
            //pedimentoModel.Iva = _reporteBll.TraerIvaPedimento();
            var resumenPedimento = _reporteBll.ResumenPedimento();
            return View(resumenPedimento);
        }

        public ActionResult ResumenPartida()
        {
            _baseBll.obtenerEmpresa();
            var partidas = _partidaBll.TraerTodo();
            return View(partidas);
        }
        public ActionResult Certificacion()
        {
            _baseBll.obtenerEmpresa();
            var reporte = _reporteBll.TraerReporteCertificacion();
            return View(reporte);
        }
        public ActionResult Iva()
        {
            _baseBll.obtenerEmpresa();
            var repoteIva = _reporteBll.ReporteIva();
            return View(repoteIva);
        }
        public ActionResult ImpVSExp()
        {
            _baseBll.obtenerEmpresa();
            _reporteImpExPmodel.ImpVSExp = _reporteBll.TraerReporteImpVsExp();
            _reporteImpExPmodel.ImpVSExpAnual = _reporteBll.TraerReporteImpVsExpAnual();
            return View(_reporteImpExPmodel);
        }

        public ActionResult ReporteFactura()
        {
            _baseBll.obtenerEmpresa();
            var facturas = _reporteBll.ReporteFacturas();
            return View(facturas);
        }
    }
}