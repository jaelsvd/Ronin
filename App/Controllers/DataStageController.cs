using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using App.BLL;
using Ionic.Zip;
using App.Entities;
namespace App.Controllers
{
    [Authorize]
    public class DataStageController : Controller
    {
        BaseBusiness _baseBll;
        private DataStageBusiness _dataStageBll;
        private DataStage _dataStageEntity;

        public DataStageController()
        {
            _dataStageBll = new DataStageBusiness();
            _dataStageEntity = new DataStage();
            _baseBll = new BaseBusiness();
        }
        // GET: DataStage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenerarDataStage()
        {
            _baseBll.obtenerEmpresa();
            var datastage= _dataStageBll.TraerTodo();
            return View(datastage);
        }

        public ActionResult CrearZip(string FechaInicial, string fechaFinal)
        {   
            int nombreArchivo = 1000;
            try
            {
                nombreArchivo = nombreArchivo + _dataStageEntity.Id;
            }
            catch (Exception)
            {

            }

            HttpContext.Server.ScriptTimeout = 10;

            _dataStageEntity.FechaInicial = Convert.ToDateTime(FechaInicial);
            _dataStageEntity.FechaFinal = Convert.ToDateTime(fechaFinal);
            _dataStageEntity.NombreCreador = User.Identity.Name;
            _dataStageEntity.NombreArchivo = nombreArchivo.ToString();


            var outputStream = new MemoryStream();

            using (var zip = new ZipFile())
            {
                zip.AddEntry(_dataStageEntity.NombreArchivo + "501.asc", _dataStageBll.Archivo_501(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "502.asc", _dataStageBll.Archivo_502(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "503.asc", _dataStageBll.Archivo_503(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "504.asc", _dataStageBll.Archivo_504(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "506.asc", _dataStageBll.Archivo_506(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "507.asc", _dataStageBll.Archivo_507(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "508.asc", _dataStageBll.Archivo_508(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "509.asc", _dataStageBll.Archivo_509(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "510.asc", _dataStageBll.Archivo_510(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "511.asc", _dataStageBll.Archivo_511(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "512.asc", _dataStageBll.Archivo_512(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "520.asc", _dataStageBll.Archivo_520(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "551.asc", _dataStageBll.Archivo_551(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "552.asc", _dataStageBll.Archivo_552(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "553.asc", _dataStageBll.Archivo_553(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "554.asc", _dataStageBll.Archivo_554(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "555.asc", _dataStageBll.Archivo_555(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "556.asc", _dataStageBll.Archivo_556(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "557.asc", _dataStageBll.Archivo_557(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "558.asc", _dataStageBll.Archivo_558(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "701.asc", _dataStageBll.Archivo_701(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "702.asc", _dataStageBll.Archivo_702(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "Inci.asc", _dataStageBll.Archivo_Inci(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "Resumen.asc", _dataStageBll.Archivo_Resumen(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.AddEntry(_dataStageEntity.NombreArchivo + "Sel.asc", _dataStageBll.Archivo_Sel(_dataStageEntity.FechaInicial, _dataStageEntity.FechaFinal));
                zip.Save(outputStream);
            }


            _dataStageBll.AgregarDataStage(_dataStageEntity);

            outputStream.Position = 0;
            return File(outputStream, "application/zip", _dataStageEntity.NombreArchivo + "_solicitudes.zip");

        }
    }
}