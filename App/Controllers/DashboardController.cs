using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.ViewModels;
using App.BLL;
using System.Security.Claims;
using App.Entities.Dashboard;



namespace App.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        #region Instancias
        PedimentoBusiness _pedimentoBll;
        DashboardViewModel dashboardViewModel;
        BaseBusiness _baseBll;
        DashboardBusiness _dashboardBll;
        Dashboard dashboard;
        #endregion

        #region Constructor
        public DashboardController()
        {
            _pedimentoBll = new PedimentoBusiness();
            dashboardViewModel = new DashboardViewModel();
            _baseBll = new BaseBusiness();
            _dashboardBll = new DashboardBusiness();
            dashboard = new Dashboard();
        }
        #endregion

        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListarPedimentos()
        {
            var pedimentos = _pedimentoBll.TraerTodo();
            return View(pedimentos);
        }
        public ActionResult Inicio()
        {   
            //Obtiene la conexion de la empresa
            _baseBll.obtenerEmpresa();
            dashboardViewModel.Importacion = _dashboardBll.TraerImportacion();
            dashboardViewModel.Exportacion = _dashboardBll.TraerExportacion();
            dashboardViewModel.Pedimento = _dashboardBll.TraerPerimentos();
            return View(dashboardViewModel);
        }
    }
}