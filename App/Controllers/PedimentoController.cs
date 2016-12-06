using App.BLL;
using App.Entities;
using System.Web.Mvc;

namespace App.Controllers
{
    /// <summary>
    /// Esta clase interactua con la capa de negocios y las vistas
    /// </summary>
    [Authorize]
    /// <summary>
    /// Esta clase interactua con la capa de negocios y las vistas
    /// </summary>
    public class PedimentoController : Controller
    {
        #region Instancias
        private PedimentoBusiness _pedimentoBll;
        private BaseBusiness _baseBll;
        #endregion

        #region Constructor
        public PedimentoController()
        {
            _pedimentoBll = new PedimentoBusiness();
            _baseBll = new BaseBusiness();
        }
        #endregion

        #region Metodos
        // GET: Pedimento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrearPedimento()
        {
            return View();
        }

        public ActionResult BorrarPedimento(int id)
        {
            if(id !=0)
            {
                var identificador = _pedimentoBll.TraerPorId(id);

                _pedimentoBll.BorrarPedimento(id);
            }
            return RedirectToAction("ListaPedimentos");
        }
        public ActionResult ListarPedimentos()
        {
            _baseBll.obtenerEmpresa();
            var pedimentos = _pedimentoBll.TraerTodo();
            return View(pedimentos);
        }
        public ActionResult DetallePedimento(int id)
        {
            _baseBll.obtenerEmpresa();
            var detallePedimento = _pedimentoBll.TraerPorId(id);
            return View(detallePedimento);
        }     
        #endregion
    }
}