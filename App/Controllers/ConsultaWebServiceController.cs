using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.WebServiceVucem;
using App.BLL;

namespace App.Controllers
{
    [Authorize]
    public class ConsultaWebServiceController : Controller
    {
        BaseBusiness _baseBll;
        public ConsultaWebServiceController()
        {
            _baseBll = new BaseBusiness();
        }
        // GET: ConsultaWebService
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaPedimento()
        {
            _baseBll.obtenerEmpresa();
            ListaPedimentoWS _listaPedimentoWS = new ListaPedimentoWS();
            _listaPedimentoWS.ConsultaListaPedimento();
            return View();
        }
    }
}