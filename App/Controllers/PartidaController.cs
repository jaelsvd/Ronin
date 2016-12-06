using App.BLL;
using App.Entities;
using System.Web.Mvc;
using App.ViewModels;

namespace App.Controllers
{
    [Authorize]
    public class PartidaController : Controller
    {
        #region Instancias
        private PartidaBusiness _partidaBll;
        private PartidaViewModel _partidaViewModel;
        BaseBusiness _baseBll;
        #endregion

        #region Constructor
        public PartidaController()
        {
            _partidaBll = new PartidaBusiness();
            _partidaViewModel = new PartidaViewModel();
             _baseBll = new BaseBusiness();
        }
        #endregion

        #region Metodos Publicos
        // GET: Partida
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrearPartida()
        {
            return View();
        }

        public ActionResult BorrarPartida(int id)
        {
            if(id !=0)
            {
                var identificador = _partidaBll.TraerPorId(id);
                _partidaBll.BorrarPartida(id);
            }
            return RedirectToAction("ListarPartidas");
        }

        public ActionResult ListarPartidas(int id)
        {
            _baseBll.obtenerEmpresa();
            var partidas = _partidaBll.TraerPorPedimentoId(id);
            return View(partidas);
        }
        public ActionResult DetallePartida(int pedimentoId , int numeroPartida)
        {
            _baseBll.obtenerEmpresa();
            var detallePartida = _partidaBll.TraerPorPedimentoIdNumeroPartida(pedimentoId, numeroPartida);
            return View(detallePartida);
        }
        public ActionResult AgregarPartidas(Partida partida)
        {
            partida = new Partida();

            try
            {
                _partidaBll.AgregarPartida(partida);

                return RedirectToAction("ListaPartidas");
            }
            catch(PartidaAlreadyExistException)
            {
                ModelState.AddModelError("NumPartida", "Ya existe");
            }
            return View();
        }

        #endregion

    }
}