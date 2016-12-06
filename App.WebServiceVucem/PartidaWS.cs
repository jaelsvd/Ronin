using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities;
using App.DAL;
using System.Diagnostics;
using App.Common;

namespace App.WebServiceVucem
{
    public class PartidaWS : Usuario
    {
        private Partida _partidaEntity;
        private PartidaRepository _partidaRepo;
        private PartidaGravamen _partidaGravamenEntity;
        private PartidaTasa _partidaTasaEntity;
        private PartidaImporte _partidaImporteEntity;
        private PartidaPermiso _partidaPermiso;
        private PartidaCuentaAduanera _partCuentaAduanera;
        private PedimentoRepository _pedimentoRepo;
        private PartidaDatosVehiculo _partidaDatosVehiculo;
        private PartidaMetodoValoracion _partidaMetodoVal;
        private PartidaVinculacion _partidaVinculacion;
        private int intentos;
        private TimeSpan tiempo;
        
        public PartidaWS()
        {
            _partidaEntity = new Partida();
            _partidaRepo = new PartidaRepository();
            _pedimentoRepo = new PedimentoRepository();
            _partidaPermiso = new PartidaPermiso();
            _partCuentaAduanera = new PartidaCuentaAduanera();
            _partidaDatosVehiculo = new PartidaDatosVehiculo();
            _partidaMetodoVal = new PartidaMetodoValoracion();
            _partidaVinculacion = new PartidaVinculacion();
        }


        public void ConsultaPartida(long numeroOperacion, string aduana, int patente, long pedimento, int numeroPartida, int Id)
        {
            intentos = 0;
            Stopwatch _stopWatch = new Stopwatch();

            do
            {


                

                _partidaEntity = new App.Entities.Partida();
                PartidaService.ConsultarPartidaRespuesta respuesta = null;
                PartidaService.ConsultarPartidaServicePortTypeClient client = new PartidaService.ConsultarPartidaServicePortTypeClient();
                var conpeti = new PartidaService.ConsultarPartidaPeticion();
                client.ClientCredentials.UserName.UserName = Empresa.RFC;
                client.ClientCredentials.UserName.Password = Empresa.ContrasenaSAT;
                PartidaService.PeticionPartida peticion = new PartidaService.PeticionPartida();

                peticion.numeroOperacion = numeroOperacion;
                peticion.aduana = aduana;
                peticion.patente = patente;
                peticion.pedimento = pedimento;
                peticion.numeroPartida = numeroPartida;

                conpeti.peticion = peticion;
                try
                {
                    intentos++;
                    _stopWatch.Start();
                    respuesta = client.consultarPartida(conpeti);
                    _stopWatch.Stop();
                     tiempo = _stopWatch.Elapsed;

                    var partida = respuesta.partida;


                    if (respuesta.tieneError == false)
                    {
                        //Almacenar datos del web service a la bd. 
                        _partidaEntity.NumeroPartida = partida.numeroPartida;
                        if(partida.fraccionArancelaria != null) { _partidaEntity.FraccionArancelaria = partida.fraccionArancelaria; }
                        else { _partidaEntity.FraccionArancelaria = ""; }
                        if (partida.descripcionMercancia != null) { _partidaEntity.DescMercancia = partida.descripcionMercancia; }
                        else { _partidaEntity.DescMercancia = ""; }

                        if(partida.unidadMedidaTarifa != null)
                        {
                            if (partida.unidadMedidaTarifa.clave != null) { _partidaEntity.UnidadMedTarifaClave = partida.unidadMedidaTarifa.clave; }
                            else { _partidaEntity.UnidadMedTarifaClave = ""; }
                            if (partida.unidadMedidaTarifa.descripcion != null) { _partidaEntity.UnidadMedTarifaDesc = partida.unidadMedidaTarifa.descripcion; }
                            else { _partidaEntity.UnidadMedTarifaDesc = ""; }
                            _partidaEntity.CantidadUnidadMedidaTarifa = partida.cantidadUnidadMedidaTarifa;
                        }
                        
                        if(partida.unidadMedidaComercial != null)
                        {
                            if (partida.unidadMedidaComercial.clave != null) { _partidaEntity.UnidadMedComerClave = partida.unidadMedidaComercial.clave; }
                            else { _partidaEntity.UnidadMedComerClave = ""; }
                            if (partida.unidadMedidaComercial.descripcion != null) { _partidaEntity.UnidadMedComerDesc = partida.unidadMedidaComercial.descripcion; }
                            else { _partidaEntity.UnidadMedComerDesc = ""; }
                        }
                        

                        _partidaEntity.CantidadUnidadMedidaComercial = partida.cantidadUnidadMedidaComercial;
                        _partidaEntity.PrecioUnitaro = partida.precioUnitario;
                        _partidaEntity.ValorComercial = partida.valorComercial;
                        _partidaEntity.ValorAduana = partida.valorAduana;
                        _partidaEntity.ValorDolares = partida.valorDolares;
                        _partidaEntity.ValorAgregado = partida.valorAgregado;

                        if( partida.metodoValoracion != null)
                        {
                            _partidaMetodoVal = new PartidaMetodoValoracion();

                            _partidaMetodoVal.MetodoValorDesc = partida.metodoValoracion;

                            switch (_partidaMetodoVal.MetodoValorDesc)
                            {
                                case "CLAVE USADA SOLO A LA EXPORTACION":
                                    _partidaMetodoVal.MetodoValorClave = 0;
                                    break;
                                case "VALOR DE TRANSACCION DE LAS MERCANCIAS":
                                    _partidaMetodoVal.MetodoValorClave = 1;
                                    break;
                                case "VALOR DE TRANSACCION DE MERCANCIAS IDENTICAS":
                                    _partidaMetodoVal.MetodoValorClave = 2;
                                    break;
                                case "VALOR DE TRANSACCION DE MERCANCIAS SIMILARES":
                                    _partidaMetodoVal.MetodoValorClave = 3;
                                    break;
                                case "VALOR DE PRECIO UNITARIO DE VENTA":
                                    _partidaMetodoVal.MetodoValorClave = 4;
                                    break;
                                case "VALOR RECONSTRUIDO":
                                    _partidaMetodoVal.MetodoValorClave = 5;
                                    break;
                                case "ULTIMO RECURSO":
                                    _partidaMetodoVal.MetodoValorClave = 6;
                                    break;
                                case "ULTIMO RECURSO VALOR DE TRANSACCION DE MERCANCIAS IDENTICAS":
                                    _partidaMetodoVal.MetodoValorClave = 7;
                                    break;
                                case "ULTIMO RECURSO VALOR DE TRANSACCION DE MERCANCIAS SIMILARES":
                                    _partidaMetodoVal.MetodoValorClave = 8;
                                    break;
                                case "ULTIMO RECURSO VALOR DE PRECIO UNITARIO DE VENTA":
                                    _partidaMetodoVal.MetodoValorClave = 9;
                                    break;
                                case "ULTIMO RECURSO VALOR RECONSTRUIDO":
                                    _partidaMetodoVal.MetodoValorClave = 10;
                                    break;
                            }

                        }
                        else { _partidaMetodoVal.MetodoValorDesc = ""; }

                        if (partida.vinculacion != null)
                        {
                            _partidaVinculacion = new PartidaVinculacion();

                            _partidaVinculacion.VinculacionDesc = partida.vinculacion;

                            switch(_partidaVinculacion.VinculacionDesc)
                            {
                                case "NO EXISTE VINCULACION":
                                    _partidaVinculacion.VinculacionClave = 0;
                                    break;
                                case "SI EXISTE VINCULACION Y NO AFECTA EL VALOR ADUANA":
                                    _partidaVinculacion.VinculacionClave = 1;
                                    break;
                                case "SI EXISTE VINCULACION Y AFECTA EL VALOR ADUANA":
                                    _partidaVinculacion.VinculacionClave = 2;
                                    break;
                            }
                        }
                        else { _partidaVinculacion.VinculacionDesc = ""; }

                        if(partida.paisOrigenDestino != null)
                        {
                            if (partida.paisOrigenDestino.clave != null) { _partidaEntity.PaisOrigDestClave = partida.paisOrigenDestino.clave; }
                            else { _partidaEntity.PaisOrigDestClave = ""; }

                            if (partida.paisOrigenDestino.descripcion != null) { _partidaEntity.PaisOrigDestDesc = partida.paisOrigenDestino.descripcion; }
                            else { _partidaEntity.PaisOrigDestDesc = ""; }
                        }
                        
                        if(partida.paisVendedorComprador != null)
                        {
                            if (partida.paisVendedorComprador.clave != null) { _partidaEntity.PaisVendCompClave = partida.paisVendedorComprador.clave; }
                            else { _partidaEntity.PaisVendCompClave = ""; }

                            if (partida.paisVendedorComprador.descripcion != null) { _partidaEntity.PaisVendCompDesc = partida.paisVendedorComprador.descripcion; }
                            else { _partidaEntity.PaisVendCompDesc = ""; }
                        }
                        

                        //Campos adicionales
                        if(partida.subdivisionFraccion != null) { _partidaEntity.SubDivisionFraccion = partida.subdivisionFraccion; }
                        else { _partidaEntity.SubDivisionFraccion = ""; }

                        if (partida.codigoProducto != null) { _partidaEntity.CodigoMercancia = partida.codigoProducto; }
                        else { _partidaEntity.CodigoMercancia = ""; }

                        if (partida.marca != null) { _partidaEntity.MarcaMercancia = partida.marca; }
                        else { _partidaEntity.MarcaMercancia = ""; }

                        if(partida.modelo != null) { _partidaEntity.ModeloMercancia = partida.modelo; }
                        else { _partidaEntity.ModeloMercancia = ""; }

                        _partidaEntity.FechaCreacion = DateTime.Now;
                        if(partida.observaciones != null) { _partidaEntity.ObservacionesDesc = partida.observaciones; }
                        else { _partidaEntity.ObservacionesDesc = ""; }

                        _partidaEntity.PedimentoId = Id;

                        //Gravamenes
                        if(partida.gravamenes != null)
                        {
                            for (int i = 0; i < partida.gravamenes.Length; i++)
                            {
                                _partidaGravamenEntity = new PartidaGravamen();
                                _partidaGravamenEntity.FechaCreacion = DateTime.Now;
                                _partidaGravamenEntity.PartidaId = _partidaEntity.Id;
                                _partidaGravamenEntity.ClaveGravamenClave = partida.gravamenes[i].claveGravamen.clave;
                                if(partida.gravamenes[i].claveGravamen.descripcion != null) { _partidaGravamenEntity.ClaveGravamenDesc = partida.gravamenes[i].claveGravamen.descripcion; }
                                else { _partidaGravamenEntity.ClaveGravamenDesc = ""; }

                                for (int j = 0; j < partida.gravamenes[i].tasas.Length; j++)
                                {
                                    _partidaTasaEntity = new PartidaTasa();
                                    _partidaTasaEntity.TasaClave = partida.gravamenes[i].tasas[j].clave.clave;
                                    if(partida.gravamenes[i].tasas[j].clave.descripcion != null) { _partidaTasaEntity.TasaDesc = partida.gravamenes[i].tasas[j].clave.descripcion; }
                                    else { _partidaTasaEntity.TasaDesc = ""; }

                                    _partidaTasaEntity.TasaAplicable = partida.gravamenes[i].tasas[j].tasaAplicable;
                                    _partidaTasaEntity.Id = _partidaGravamenEntity.Id;

                                    _partidaGravamenEntity.PartidaTasa.Add(_partidaTasaEntity);
                                }

                                for (int k = 0; k < partida.gravamenes[i].importes.Length; k++)
                                {
                                    _partidaImporteEntity = new PartidaImporte();
                                    _partidaImporteEntity.FormaPagoClave = partida.gravamenes[i].importes[k].formaPago.clave;
                                    if(partida.gravamenes[i].importes[k].formaPago.descripcion != null) { _partidaImporteEntity.FormaPagoDesc = partida.gravamenes[i].importes[k].formaPago.descripcion; }
                                    else { _partidaImporteEntity.FormaPagoDesc = ""; }

                                    _partidaImporteEntity.Importe = partida.gravamenes[i].importes[k].importe;
                                    _partidaImporteEntity.Id = _partidaGravamenEntity.Id;

                                    _partidaGravamenEntity.PartidaImporte.Add(_partidaImporteEntity);
                                }

                                _partidaEntity.PartidaGravamen.Add(_partidaGravamenEntity);
                            }

                            //Permisos
                            if(partida.permisos != null)
                            {
                                for(int i =0; i<partida.permisos.Length; i++)
                                {
                                    _partidaPermiso = new PartidaPermiso();
                                    if(partida.permisos[i] != null)
                                    {

                                    }
                                    if (partida.permisos[i].clavePermiso != null)
                                    { 
                                        if (partida.permisos[i].clavePermiso.clave != null) { _partidaPermiso.PermisoClave = partida.permisos[i].clavePermiso.clave; }
                                        else { _partidaPermiso.PermisoClave = ""; }
                                        if (partida.permisos[i].clavePermiso.descripcion != null) { _partidaPermiso.PermisoDesc = partida.permisos[i].clavePermiso.descripcion; }
                                        else { _partidaPermiso.PermisoDesc = ""; }
                                    }
                                    if (partida.permisos[i].numeroPermiso != null) { _partidaPermiso.NumeroPermiso = partida.permisos[i].numeroPermiso; }
                                    else { _partidaPermiso.NumeroPermiso = ""; }
                                    if (partida.permisos[i].firmaDescargo != null) { _partidaPermiso.FirmaDescargo = partida.permisos[i].firmaDescargo; }
                                    else { _partidaPermiso.FirmaDescargo = ""; }

                                    _partidaPermiso.ValorComercialEnDolar = partida.permisos[i].valorComercialDolares;
                                    _partidaPermiso.CantidadUMTUMC = partida.permisos[i].cantidadUMTUMC;
                                    _partidaEntity.PartidaPermiso.Add(_partidaPermiso);
                                }
                            }

                            //Cuentas Aduaneras

                            if(partida.cuentasAduaneras != null)
                            {
                                for(int i = 0; i<partida.cuentasAduaneras.Length; i++)
                                {
                                    _partCuentaAduanera = new PartidaCuentaAduanera();
                                    if (partida.cuentasAduaneras[i].institucionEmisora != null)
                                    { 
                                    _partCuentaAduanera.InsEmClave = partida.cuentasAduaneras[i].institucionEmisora.clave;
                                    if (partida.cuentasAduaneras[i].institucionEmisora.descripcion != null) { _partCuentaAduanera.InsEmDescripcion = partida.cuentasAduaneras[i].institucionEmisora.descripcion; }
                                    else { _partCuentaAduanera.InsEmDescripcion = ""; }
                                    }
                                    if (partida.cuentasAduaneras[i].folioConstancia != null) { _partCuentaAduanera.FolioConstancia = partida.cuentasAduaneras[i].folioConstancia; }
                                    else { _partCuentaAduanera.FolioConstancia = ""; }
                                    if (partida.cuentasAduaneras[i].fechaConstancia != null) { _partCuentaAduanera.FechaConstancia = partida.cuentasAduaneras[i].fechaConstancia; }
                                    if (partida.cuentasAduaneras[i].tipoCuenta != null) { _partCuentaAduanera.TipoCuentaDesc = partida.cuentasAduaneras[i].tipoCuenta; }
                                    else { _partCuentaAduanera.TipoCuentaDesc = ""; }
                                    if (partida.cuentasAduaneras[i].tipoGarantia != null) { _partCuentaAduanera.TipoGarantia = partida.cuentasAduaneras[i].tipoGarantia; }
                                    else { _partCuentaAduanera.TipoGarantia = ""; }

                                    _partCuentaAduanera.GarantiaTotalGarantia = partida.cuentasAduaneras[i].totalGarantia;
                                    _partCuentaAduanera.GarantiaCantidadUMC = partida.cuentasAduaneras[i].cantidadUMC;
                                    _partidaEntity.PartidaCuentaAduanera.Add(_partCuentaAduanera);
                                }
                            }
                            //Datos Vehiculo

                        if(partida.datosVeiculos != null)
                            {
                                for(int i=0; i < partida.datosVeiculos.Length; i++)
                                {
                                    _partidaDatosVehiculo = new PartidaDatosVehiculo();
                                    if(partida.datosVeiculos[i].vin != null) { _partidaDatosVehiculo.VinNumeroSerie = partida.datosVeiculos[i].vin; }
                                    else { _partidaDatosVehiculo.VinNumeroSerie = ""; }
                                    _partidaDatosVehiculo.Kilometraje = partida.datosVeiculos[i].kilometraje;

                                    _partidaEntity.PartidaDatosVehiculo.Add(_partidaDatosVehiculo);
                                }
                            }

                        }
                        
                        _partidaEntity.Intentos = intentos;
                        intentos = 5;
                        
                        _partidaEntity.Tiempo = tiempo.ToString();
                        //Agregar al a BD
                        _partidaRepo.AgregarPartida(_partidaEntity);
                        Console.WriteLine("\n ------------------");
                        Console.WriteLine("Partida: {0}", numeroPartida);
                        Console.WriteLine("Descripcion Mercancia: {0}", partida.descripcionMercancia);
                        Console.WriteLine("Tiempo: {0}", tiempo);
                        Console.WriteLine("Exitoso");

                      
                    }



                }
                catch (Exception e)
                {
                    _stopWatch.Stop();
                    _partidaEntity.Intentos = intentos;
                    TimeSpan tiempo = _stopWatch.Elapsed;
                    Console.WriteLine("Tiempo: {0}", tiempo);
                    Console.WriteLine(e.Message);
                    Console.WriteLine("No funciono Partida");
                    Console.WriteLine("Intentos: {0} ", intentos.ToString());


                    if (intentos >= 5)
                    {
                        Console.WriteLine("Insertando Error Partida");

                        Console.WriteLine("Tiempo: {0}", tiempo);
                        Console.WriteLine(e.Message);
                        _partidaEntity.ErrorDesc = e.Message;
                        _partidaEntity.TieneError = true;
                        _partidaEntity.Tiempo = tiempo.ToString();
                        _partidaEntity.FechaCreacion = DateTime.Now;
                        _partidaEntity.PedimentoId = Id;
                        _partidaRepo.AgregarPartida(_partidaEntity);

                        
                        _pedimentoRepo.ActualizarError(_partidaEntity.PedimentoId, true, e.Message);
                    }

                }

            } while (intentos < 5);

        }

    }
}
