using App.WebServiceVucem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class ConsultarWebServiceController : Controller
    {
        // GET: ConsultarWebService
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaPedimento()
        {

            ListaPedimentoWS _listaPedimentoWS = new ListaPedimentoWS();
            _listaPedimentoWS.ConsultaListaPedimento();
            return View();
        }
    }
}