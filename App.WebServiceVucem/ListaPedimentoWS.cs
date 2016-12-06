using App.DAL;
using App.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common;

namespace App.WebServiceVucem 
{
    public class ListaPedimentoWS : Usuario
    {
        #region Instancias
        private PedimentoCompletoWS _pedimentoCompleto;
        private ListaPedimentoRepository _listaRepo;
        private PedimentosListaRepository _pedimentoListaRepo;
        private ListaPedimento _listaPedimento;
        private PedimentosLista _pedimentoLista;
        private AgenteAduanalRepository _agenteRepo;
        DateTime fechaInicio;
        DateTime fechaFinal;
        private int intentos;
        TimeSpan timeSpan;
        Stopwatch _stopWatch;
        #endregion

        #region Constructor
        public ListaPedimentoWS()
        {
            _listaRepo = new ListaPedimentoRepository();
            _pedimentoListaRepo = new PedimentosListaRepository();
            _listaPedimento = new ListaPedimento();
            _pedimentoCompleto = new PedimentoCompletoWS();
            _pedimentoLista = new PedimentosLista();
            _agenteRepo = new AgenteAduanalRepository();

        }
        #endregion

        public void ConsultaListaPedimento()
        {
            //3575
            //3986
            //3259
            
            var patentes = _agenteRepo.TraerPatentes();

            
            
            for (DateTime date = new DateTime(2016, 09, 01); date < new DateTime(2016, 10, 31); date = date.AddDays(1.0))
            {
                foreach (var patente in patentes)
                {
                    foreach ( var a in Empresa.EmpresaAduanas)
                    {
                        int aduana = Convert.ToInt32(a.Clave);
                        intentos = 0;
                        do
                        {
                            intentos++;

                            try
                            {
                                _stopWatch = new Stopwatch();

                                fechaInicio = date;
                                fechaFinal = date;
                                _listaPedimento = new ListaPedimento();
                        
                        
                                ListarPedimentoService.ConsultarPedimentosRespuesta respuesta;

                                ListarPedimentoService.ListarPedimentosServicePortTypeClient client = new ListarPedimentoService.ListarPedimentosServicePortTypeClient();

                                var conpeti = new ListarPedimentoService.ConsultarPedimentosPeticion();
                                client.ClientCredentials.UserName.UserName = Empresa.RFC;
                                client.ClientCredentials.UserName.Password = Empresa.ContrasenaSAT;
                        
                                ListarPedimentoService.Peticion peticion = new ListarPedimentoService.Peticion();
                        
                                peticion.aduana = aduana;
                                peticion.fechaInicio = fechaInicio;
                                peticion.fechaFin = fechaFinal;
                                peticion.patente = patente;

                                conpeti.peticion = peticion;
                                Console.WriteLine("\n\nFecha del Listado: {0}", date);
                                Console.WriteLine("cargando...");
                                _stopWatch.Start();
                                respuesta = client.consultarPedimentos(conpeti);
                                _stopWatch.Stop();
                                TimeSpan timeSpan = _stopWatch.Elapsed;
                                Console.WriteLine("Tiempo: {0}", timeSpan);

                                _listaPedimento.ErrorPeticion = false;
                                _listaPedimento.Tiempo = timeSpan.ToString();
                                _listaPedimento.FechaInicio = fechaInicio;
                                _listaPedimento.FechaFinal = fechaFinal;
                                _listaPedimento.FechaCreacion = DateTime.Now;
                                _listaPedimento.Intentos = intentos;
                       
                                _listaPedimento.TieneError = respuesta.tieneError;
                                _listaPedimento.Patente = patente;
                                _listaPedimento.Aduana = aduana.ToString();

                                if (respuesta.tieneError == true)
                                {
                                    _listaPedimento.ErrorDesc = respuesta.error[0];
                                    Console.WriteLine(respuesta.error[0]);
                                    _listaRepo.AgregarListaPedimento(_listaPedimento);
                                    intentos = 6;
                                }
                                else
                                {
                                    _listaPedimento.ErrorDesc = "No hay error";
                                }

                                 //_listaRepo.AgregarListaPedimento(_listaPedimento);


                                if (respuesta.tieneError == false)
                                {

                                    ListarPedimentoService.Pedimento[] pedimento = new ListarPedimentoService.Pedimento[respuesta.pedimento.Length];
                                    pedimento = respuesta.pedimento;
                                    Console.WriteLine("\n\nCantidad de Pedimentos: {0}", pedimento.Length);

                                    _listaRepo.AgregarListaPedimento(_listaPedimento);

                                    for (int i = 0; i < respuesta.pedimento.Length; i++)
                                    {
                                        _pedimentoCompleto = new PedimentoCompletoWS();
                                        _pedimentoLista = new PedimentosLista();
                                

                                        _pedimentoLista.AduanaClave = pedimento[i].aduana.clave;
                                        _pedimentoLista.AduanaDesc = pedimento[i].aduana.descripcion;
                                        _pedimentoLista.FolioPedimento = pedimento[i].numeroDocumentoAgente.ToString();
                                        _pedimentoLista.Patente = pedimento[i].petente;
                                        _pedimentoLista.ListaPedimentoId = _listaPedimento.Id;
                                        _pedimentoLista.FechaCreacion = DateTime.Now;
                                        _pedimentoLista.TieneError = false;

                                        _pedimentoListaRepo.AgregarPedimentoLista(_pedimentoLista);

                                        //_listaPedimento.PedimentosLista.Add(_pedimentoLista);

                                        _pedimentoCompleto.ConsultaPedimento(pedimento[i].numeroDocumentoAgente, pedimento[i].petente, peticion.aduana.ToString(), _listaPedimento.Id);
                            

                                    }

                                    intentos = 6;

                                }



                                //_listaRepo.AgregarListaPedimento(_listaPedimento);



                            }
                            catch (Exception e)
                            {

                                _stopWatch.Stop();
                                timeSpan = _stopWatch.Elapsed;

                                _listaPedimento.ErrorPeticion = true;
                                _listaPedimento.TieneError = true;
                                _listaPedimento.Tiempo = timeSpan.ToString();
                                _listaPedimento.ErrorDesc = e.Message;
                                _listaPedimento.FechaInicio = fechaInicio;
                                _listaPedimento.FechaFinal = fechaFinal;
                                _listaPedimento.FechaCreacion = DateTime.Now;
                                _listaPedimento.Patente = patente;
                                _listaPedimento.Aduana = aduana.ToString();
                                _listaPedimento.Intentos = intentos;
                                Console.WriteLine("Tiempo Listado pedimento: {0}", timeSpan);
                                Console.WriteLine(e.Message);
                        
                                if (intentos >= 5)
                                {
                                    _listaRepo.AgregarListaPedimento(_listaPedimento);

                                }

                            }

                        } while (intentos < 5);
                    }
                }
            }
        }
    }
}
