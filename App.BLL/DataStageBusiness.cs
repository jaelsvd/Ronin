using App.DAL;
using App.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL
{
    public class DataStageBusiness
    {
        #region Instancias
        DataStageRepository _dataStageRepo;
        private int totalFracciones;
        private int totalContribuciones;
        private Archivo _archivo;
        private List<Archivo> _listaArchivo;
        MemoryStream stream;
        #endregion

        #region Constructor
        public DataStageBusiness()
        {
            _dataStageRepo = new DataStageRepository();
             totalFracciones  = 0;
             totalContribuciones = 0;
            _archivo = new Archivo();
            _listaArchivo = new List<Archivo>();
             stream = new MemoryStream();
        }
        #endregion

        #region Métodos Públicos
        public void AgregarDataStage(DataStage dataStage)
        {
            dataStage.FechaCreacion = DateTime.Now;
            dataStage.URLZip = "";
            _dataStageRepo.AgregarDataStage(dataStage);
        }
        public void BorrarDataStage(DataStage dataStage)
        {
            _dataStageRepo.BorrarDataStage(dataStage);
        }
        public List<DataStage> TraerTodo()
        {
           return _dataStageRepo.TraerTodo();
        }
        public DataStage TraerPorId(int id)
        {
            return _dataStageRepo.TraerPorId(id);
        }
        private bool DataStageExistentePorId(DataStage dataStage)
        {
            var dataStageLA = _dataStageRepo.TraerPorId(dataStage.Id);
            return dataStageLA != null;
        }

        public Task<Archivo> Asc(byte[] arreglo)
        {
            return new Task<Archivo>(() =>
            {
                return new Archivo(arreglo);
            }
            );
        }


        public  byte[] Archivo_501(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|TipoOperacion|ClaveDocumento|SeccionAduaneraEntrada|CurpContribuyente|Rfc|CurpAgenteA|TipoCambio|TotalFletes|TotalSeguros|TotalEmbalajes|TotalIncrementables|TotalDeducibles|PesoBrutoMercancia|MedioTransporteSalida|MedioTransporteArribo|MedioTransporteEntrada_Salida|DestinoMercancia|NombreContribuyente|CalleContribuyente|NumInteriorContribuyente|NumExteriorContribuyente|CPContribuyente|MunicipioContribuyente|EntidadFedContribuyente|PaisContribuyente|TipoPedimento|FechaRecepcionPedimento|FechaPagoReal");

           

            foreach (var pedimento in pedimentos)
            {
                int tipoPedimento = 1;
                if (pedimento.Pedimento.PedimentoOriginalRectificacion != 0)
                { tipoPedimento = 2; }

                sb.AppendLine();
                sb.Append(pedimento.Pedimento.Patente);
                sb.Append('|');
                sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                sb.Append('|');
                sb.Append(pedimento.Pedimento.Aduana.Trim());
                sb.Append('|');
                sb.Append(pedimento.Pedimento.EncabezadoOpClave);
                sb.Append('|');
                sb.Append(pedimento.Pedimento.EncabezadoClavDocClave.Trim());
                sb.Append('|');
                sb.Append(pedimento.Pedimento.EncabezadoAduEntSalidaClave);
                sb.Append('|');
                //Curp 
                sb.Append('|');
                //sb.Append(pedimento.Pedimento.RFC);
                sb.Append('|');
                sb.Append(pedimento.Pedimento.CurpApoderadoMandatario.Trim());
                sb.Append('|');
                sb.Append(pedimento.Pedimento.EncabezadoTipoCambio.ToString("00.0000"));
                sb.Append('|');
                sb.Append(pedimento.Pedimento.ImpExpFletes);
                sb.Append('|');
                sb.Append(pedimento.Pedimento.ImpExpSeguros);
                sb.Append('|');
                sb.Append(pedimento.Pedimento.ImpExpEmbalajes);
                sb.Append('|');
                sb.Append(pedimento.Pedimento.ImpExpIncrementables);
                sb.Append('|');
                sb.Append('0');//Deducible es en 0
                sb.Append('|');
                sb.Append(pedimento.Pedimento.EncabezadoPesoBruto);
                sb.Append('|');
                sb.Append(pedimento.Pedimento.EncabezadoMedTranspSalClave);
                sb.Append('|');
                sb.Append(pedimento.Pedimento.EncabezadoMedTranspArriboClave);
                sb.Append('|');
                sb.Append(pedimento.Pedimento.EncabezadoMedTranspEntradaClave);
                sb.Append('|');
                sb.Append(pedimento.Pedimento.EncabezadoDestinoClave);
                sb.Append('|');
                sb.Append(pedimento.Pedimento.ImpExpRazSocImpExp.Trim());
                sb.Append('|');
                sb.Append(pedimento.Pedimento.ImpExpDomCalle.Trim());
                sb.Append('|');
                sb.Append(pedimento.Pedimento.ImpExpNumDomInterior.Trim());
                sb.Append('|');
                sb.Append(pedimento.Pedimento.ImpExpNumDomExterior.Trim());
                sb.Append('|');
                sb.Append(pedimento.Pedimento.ImpExpDomCP.Trim());
                sb.Append('|');
                sb.Append(pedimento.Pedimento.ImpExpDomCdMunicipio.Trim());
                sb.Append('|');
                //Entidad Federativa
                sb.Append('|');
                sb.Append(pedimento.Pedimento.ImpExpPaisClave.Trim());
                sb.Append('|');
                sb.Append(tipoPedimento);
                sb.Append('|');
                foreach (var fechas in pedimento.Pedimento.PedimentoImpExpFechas)
                {
                    if (fechas.ImpExpFechasFechaEntradaTipoClave == 1)
                    {
                        sb.Append(fechas.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                        sb.Append('|');
                    }else
                    {
                        sb.Append('|');
                    }
                    
                }
                foreach (var fechas in pedimento.Pedimento.PedimentoImpExpFechas)
                {
                    if (fechas.ImpExpFechasFechaEntradaTipoClave == 2)
                    {
                        sb.Append(fechas.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                        sb.Append('|');
                    }
                    else
                    { sb.Append('|'); }

                }
                    
                
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_502(DateTime fechaInicio , DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos =_dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|RfcTransportista|CurpTransportista|NombreTransportista|PaisTransporte|IdentificadorTransporte|FechaPagoReal");


            foreach (var pedimento in pedimentos)
            {
                var transportes = pedimento.Pedimento.PedimentoTransporte;
                if (transportes.Count != 0)
                {
                    foreach (var transporte in transportes)
                    {
                        foreach (var fechas in pedimento.Pedimento.PedimentoImpExpFechas)
                        {
                        sb.AppendLine();
                        sb.Append(pedimento.Pedimento.Patente);
                        sb.Append('|');
                        sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                        sb.Append('|');
                        sb.Append(pedimento.Pedimento.Aduana.Trim());
                        sb.Append('|');
                        sb.Append(transporte.RFCTransporte.Trim());
                        sb.Append('|');
                        sb.Append(transporte.CURPTransportista.Trim());
                        sb.Append('|');
                        sb.Append(transporte.NombreTransporte.Trim());
                        sb.Append('|');
                        sb.Append(transporte.PaisTransporteClave.Trim());
                        sb.Append('|');
                        sb.Append(transporte.IdentificadorTransporte.Trim());
                        sb.Append('|');
                        
                            if (fechas.ImpExpFechasFechaEntradaTipoClave == 2)
                            {
                                sb.Append(fechas.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                sb.Append('|');
                            }
                            else
                            {
                                sb.Append('|');
                            }
                        }
                    }
                }
            }


            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_503(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|NumeroGuia|TipoGuia|FechaPagoReal");

            foreach (var pedimento in pedimentos)
            {
                var guias = pedimento.Pedimento.PedimentoGuia;

                if (guias.Count != 0)
                {
                    foreach (var guia in guias)
                    {
                        sb.AppendLine();
                        sb.Append(pedimento.Pedimento.Patente);
                        sb.Append('|');
                        sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                        sb.Append('|');
                        sb.Append(pedimento.Pedimento.Aduana.Trim());
                        sb.Append('|');
                        sb.Append(guia.GuiaManifesto.Trim());
                        sb.Append('|');
                        sb.Append(guia.TipoGuia.Trim());
                        sb.Append('|');
                        foreach (var fechas in pedimento.Pedimento.PedimentoImpExpFechas)
                        {
                            if (fechas.ImpExpFechasFechaEntradaTipoClave == 2)
                            {
                                sb.Append(fechas.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                sb.Append('|');
                            }
                            else
                            {
                                sb.Append('|');
                            }
                        }
                    }
                }
            }


            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_504(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|NumContenedor|TipoContenedor|FechaPagoReal");

            foreach (var pedimento in pedimentos)
            {
                var contenedores = pedimento.Pedimento.PedimentoContenedor;

                if (contenedores.Count != 0)
                {
                    foreach (var contenedor in contenedores)
                    {
                        sb.AppendLine();
                        sb.Append(pedimento.Pedimento.Patente);
                        sb.Append('|');
                        sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                        sb.Append('|');
                        sb.Append(pedimento.Pedimento.Aduana.Trim());
                        sb.Append('|');
                        sb.Append(contenedor.IdContenedor.Trim());
                        sb.Append('|');
                        sb.Append(contenedor.TipoContenedorDesc.Trim());
                        sb.Append('|');
                        foreach (var fechas in pedimento.Pedimento.PedimentoImpExpFechas)
                        {
                            if (fechas.ImpExpFechasFechaEntradaTipoClave == 2)
                            {
                                sb.Append(fechas.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                sb.Append('|');
                            }
                            else
                            {
                                sb.Append('|');
                            }
                        }
                    }
                }
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_505(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|FechaFacturacion|NumeroFactura|TerminoFacturacion|MonedaFacturacion|ValorDolares|ValorMonedaExtranjera|PaisFacturacion|EntidadFedFacturacion|IndentFiscalProveedor|ProveedorMercancia|CalleProveedor|NumInteriorProveedor|NumExteriorProveedor|CpProveedor|MunicipioProveedor|FechaPagoReal");

            foreach (var pedimento in pedimentos)
            {
                var facturas = pedimento.Pedimento.PedimentoFactura;

                if (facturas.Count != 0)
                {               
                    foreach (var factura in facturas)
                    {
                        var provCompradores = pedimento.Pedimento.PedimentoProveedorComprador;

                        foreach(var provComprador in provCompradores)
                        {
                            sb.AppendLine();
                            sb.Append(pedimento.Pedimento.Patente);
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.Aduana.Trim());
                            sb.Append('|');
                            sb.Append(factura.FechaFacturacion);
                            sb.Append('|');
                            sb.Append(factura.NumeroFactura.Trim());
                            sb.Append('|');
                            sb.Append(factura.TerminoFacturacionClave.Trim());
                            sb.Append('|');
                            if(factura.MonedaClave != null)
                            {
                                sb.Append(factura.MonedaClave.Trim());
                                sb.Append('|');
                            }
                            else
                            {
                                sb.Append('|');
                            }
                            sb.Append(factura.ValDolares);
                            sb.Append('|');
                            sb.Append(factura.ValMonedaExt);
                            sb.Append('|');
                            sb.Append('|');// PaisFacturacion
                            sb.Append('|');// EntidadFedFacturacion
                            sb.Append(factura.IdFiscalProvComp.Trim());
                            sb.Append('|');
                            sb.Append(factura.ProveedorComp.Trim());
                            sb.Append('|');
                            if(provComprador.ProvCompDomCalle != null)
                            {
                                sb.Append(provComprador.ProvCompDomCalle.Trim());
                                sb.Append('|');
                            }
                            else
                            {
                                sb.Append('|');
                            }
                            if (provComprador.ProvCompDomNumInterior != null)
                            {
                                sb.Append(provComprador.ProvCompDomCalle.Trim());
                                sb.Append('|');
                            }
                            else
                            {
                                sb.Append('|');
                            }
                            if (provComprador.ProvCompDomNumExterior != null)
                            {
                                sb.Append(provComprador.ProvCompDomNumExterior.Trim());
                                sb.Append('|');
                            }
                            else
                            {
                                sb.Append('|');
                            }
                            if (provComprador.ProvCompDomCP != null)
                            {
                                sb.Append(provComprador.ProvCompDomCP.Trim());
                                sb.Append('|');
                            }
                            else
                            {
                                sb.Append('|');
                            }
                            if (provComprador.ProvCompDomCdMunicipio != null)
                            {
                                sb.Append(provComprador.ProvCompDomCdMunicipio.Trim());
                                sb.Append('|');
                            }
                            else
                            {
                                sb.Append('|');
                            }
                           
                            foreach (var fechas in pedimento.Pedimento.PedimentoImpExpFechas)
                            {
                                if (fechas.ImpExpFechasFechaEntradaTipoClave == 2)
                                {
                                    sb.Append(fechas.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                    sb.Append('|');
                                }
                                else
                                {
                                    sb.Append('|');
                                }
                            }
                        }                       
                    }
                }
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_506(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|TipoFecha|FechaOperacion|FechaValidacionPagoR");

            foreach (var pedimento in pedimentos)
            {
                var fechas = pedimento.Pedimento.PedimentoImpExpFechas;

                if (fechas.Count != 0)
                {
                    foreach (var fecha in fechas)
                    {
                        sb.AppendLine();
                        sb.Append(pedimento.Pedimento.Patente);
                        sb.Append('|');
                        sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                        sb.Append('|');
                        sb.Append(pedimento.Pedimento.Aduana.Trim());
                        sb.Append('|');
                        sb.Append(fecha.ImpExpFechasFechaEntradaTipoClave);
                        sb.Append('|');
                        sb.Append(fecha.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                        sb.Append('|');
                        if (fecha.ImpExpFechasFechaEntradaTipoClave == 2)
                        {
                            sb.Append(fecha.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                            sb.Append('|');
                        }else
                        {
                            sb.Append('|');
                        }

                    }
                }
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_507(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|ClaveCaso|IndentificadorCaso|TipoPedimento|ComplementoCaso|FechaValidacionPagoR");

            foreach (var pedimento in pedimentos)
            {
                var identificadores = pedimento.Pedimento.IdentificadoresPedimento;

                if (identificadores.Count != 0)
                {
                    int tipoPedimento = 1;

                        if (pedimento.Pedimento.PedimentoOriginalRectificacion != 0)
                        {
                            tipoPedimento = 2;
                        }

                    foreach (var identificador in identificadores)
                    {
                   
                                sb.AppendLine();
                                sb.Append(pedimento.Pedimento.Patente);
                                sb.Append('|');
                                sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                                sb.Append('|');
                                sb.Append(pedimento.Pedimento.Aduana.Trim());
                                sb.Append('|');
                                sb.Append(identificador.ClaveIdentificadorClave.Trim());
                                sb.Append('|');
                            if(identificador.IdentificadorComplemento1 != null)
                                {
                                    sb.Append(identificador.IdentificadorComplemento1.Trim());
                                    sb.Append('|');
                                }  
                                else
                                { sb.Append('|'); }
                                sb.Append(tipoPedimento);
                                sb.Append('|');
                            if(identificador.IdentificadorComplemento2 != null)
                                {
                                    sb.Append(identificador.IdentificadorComplemento2.Trim());
                                    sb.Append('|');
                                }
                                    else
                                { sb.Append('|'); }
                                
                                sb.Append(pedimento.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                sb.Append('|');
                    }
                 }
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }
        public byte[] Archivo_508(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|InstitucionEmisora|NumeroCuenta|FolioConstancia|FechaConstancia|TipoCuenta|ClaveGarantia|ValorUnitarioTitulo|TotalGarantia|CantidadUnidades|TitulosAsignados|FechaPagoReal");

            foreach (var pedimento in pedimentos)
            {
                var cuentasAduaneras = pedimento.Pedimento.PedimentoCuentaAduanera;

                if (cuentasAduaneras.Count != 0)
                {
                    foreach (var cuentaA in cuentasAduaneras)
                    {
                        sb.AppendLine();
                        sb.Append(pedimento.Pedimento.Patente);
                        sb.Append('|');
                        sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                        sb.Append('|');
                        sb.Append(pedimento.Pedimento.Aduana.Trim());
                        sb.Append('|');
                        sb.Append(cuentaA.InstEmisoraDesc.Trim());
                        sb.Append('|');
                        sb.Append(cuentaA.InstEmisoraNumCuenta.Trim());
                        sb.Append('|');
                        sb.Append(cuentaA.InstEmisoraFolioConstancia.Trim());
                        sb.Append('|');
                        sb.Append(cuentaA.FechaConstancia);
                        sb.Append('|');
                        sb.Append(cuentaA.TipoCuentaDesc.Trim());
                        sb.Append('|');
                        sb.Append(cuentaA.InstEmisoraClave);
                        sb.Append('|');//Valor Unitario Titulo
                        sb.Append('|');
                        sb.Append(cuentaA.CuentaTotalGarantia);
                        sb.Append('|');
                        sb.Append(cuentaA.CuentaCantidadUMC);
                        sb.Append('|');
                        sb.Append('|');
                        foreach (var fechas in pedimento.Pedimento.PedimentoImpExpFechas)
                        {
                            if (fechas.ImpExpFechasFechaEntradaTipoClave == 2)
                            {
                                sb.Append(fechas.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                sb.Append('|');
                            }
                            else
                            {
                                sb.Append('|');
                            }
                        }
                        
                    }
                }
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_509(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|ClaveContribucion|TasaContribucion|TipoTasa|TipoPedimento|FechaPagoReal");

            foreach (var pedimento in pedimentos)
            {
                var tasas = pedimento.Pedimento.TasasPedimento;

                if (tasas.Count != 0)
                {
                    int tipoPedimento = 1;

                    if (pedimento.Pedimento.PedimentoOriginalRectificacion != 0)
                    {
                        tipoPedimento = 2;
                    }

                    foreach (var tasa in tasas)
                    {
                        sb.AppendLine();
                        sb.Append(pedimento.Pedimento.Patente);
                        sb.Append('|');
                        sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                        sb.Append('|');
                        sb.Append(pedimento.Pedimento.Aduana.Trim());
                        sb.Append('|');
                        sb.Append(tasa.TasasClaveContribucionClave);
                        sb.Append('|');
                        sb.Append(tasa.TasasTasaAplicable);
                        sb.Append('|');
                        sb.Append(tasa.TasasTipoTasaClave);
                        sb.Append('|');
                        sb.Append(tipoPedimento); //Tipo Pedimento
                        sb.Append('|');
                        foreach (var fechas in pedimento.Pedimento.PedimentoImpExpFechas)
                        {
                            if (fechas.ImpExpFechasFechaEntradaTipoClave == 2)
                            {
                                sb.Append(fechas.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                sb.Append('|');
                            }
                            else
                            {
                                sb.Append('|');
                            }
                        }
                        
                    }
                }

                //else
                //{
                //    sb.AppendLine();
                //    sb.Append(pedimento.Pedimento.Patente);
                //    sb.Append('|');
                //    sb.Append(pedimento.Pedimento.NumPedimento);
                //    sb.Append('|');
                //    sb.Append(pedimento.Pedimento.Aduana);
                //    sb.Append('|');
                //    sb.Append('|');
                //    sb.Append('|');
                //    sb.Append(pedimento.ImpExpFechasFecha);
                //    sb.Append('|');
                //}
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_510(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|ClaveContribucion|FormaPago|ImportePago|TipoPedimento|FechaPagoReal");

            foreach (var pedimento in pedimentos)
            {
                var tasas = pedimento.Pedimento.TasasPedimento;

                if (tasas.Count != 0)
                {
                    int tipoPedimento = 1;

                    if (pedimento.Pedimento.PedimentoOriginalRectificacion != 0)
                    { tipoPedimento = 2; }

                    foreach (var tasa in tasas)
                    {
                        sb.AppendLine();
                        sb.Append(pedimento.Pedimento.Patente);
                        sb.Append('|');
                        sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                        sb.Append('|');
                        sb.Append(pedimento.Pedimento.Aduana.Trim());
                        sb.Append('|');
                        sb.Append(tasa.TasasClaveContribucionClave);
                        sb.Append('|');
                        sb.Append(tasa.TasasFormaPagoClave);
                        sb.Append('|');
                        sb.Append(tasa.TasasImporte);
                        sb.Append('|');
                        sb.Append(tipoPedimento); //Tipo Pedimento
                        sb.Append('|');
                        foreach (var fechas in pedimento.Pedimento.PedimentoImpExpFechas)
                        {
                            if (fechas.ImpExpFechasFechaEntradaTipoClave == 2)
                            {
                                sb.Append(fechas.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                sb.Append('|');
                            }
                            else
                            {
                                sb.Append('|');
                            }
                        }
                        
                    }
                }
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }


        public byte[] Archivo_511(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|SecuenciaObservacion|Observaciones|TipoPedimento|FechaValidacionPagoR");

            if (pedimentos.Count != 0)
            {
                foreach (var pedimento in pedimentos)
                 {
                    if (pedimento.Pedimento.ObservacionesPedimento != null)
                        {
                            int tipoPedimento = 1;

                            if (pedimento.Pedimento.PedimentoOriginalRectificacion != 0)
                            { tipoPedimento = 2; }

                            sb.AppendLine();
                            sb.Append(pedimento.Pedimento.Patente);
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.Aduana.Trim());
                            sb.Append('|');
                            sb.Append('1');//Secuencia
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.ObservacionesPedimento.Trim());
                            sb.Append('|');
                            sb.Append(tipoPedimento); //Tipo Pedimento
                            sb.Append('|');
                            sb.Append(pedimento.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                            sb.Append('|');
                    }
                }
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_512(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|PatenteAduanalOrig|PedimentoOriginal|SeccionAduaneraDespOrig|DocumentoOriginal|FechaOperacionOrig|FraccionOriginal|UnidadMedida|MercanciaDescargada|TipoPedimento|FechaPagoReal");

            if(pedimentos.Count != 0)
            {
                foreach (var pedimento in pedimentos)
                {
                    var descargos = pedimento.Pedimento.PedimentoDescargo;

                    if (descargos.Count != 0)
                    {
                        int tipoPedimento = 1;

                        if (pedimento.Pedimento.PedimentoOriginalRectificacion != 0)
                            { tipoPedimento = 2; }

                        foreach (var descargo in descargos)
                        {
                            sb.AppendLine();
                            sb.Append(pedimento.Pedimento.Patente);
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.Aduana.Trim());
                            sb.Append('|');
                            sb.Append(descargo.PatenteOriginal);
                            sb.Append('|');
                            sb.Append(descargo.PedimentoOriginal);
                            sb.Append('|');
                            sb.Append(descargo.AduanaOrigDesc.Trim());
                            sb.Append('|');
                            sb.Append(descargo.ClaveDocOrigClave.Trim());
                            sb.Append('|');
                            sb.Append(descargo.FechaPagoOriginal);
                            sb.Append('|');
                            sb.Append(descargo.FraccionOriginal.Trim());
                            sb.Append('|');
                            if(descargo.UnidadMedOrigClave != null)
                            {
                                sb.Append(descargo.UnidadMedOrigClave.Trim());
                                sb.Append('|');
                            }
                            else
                            {
                                sb.Append('|');
                            }
                            //mercancia descargada
                            sb.Append('|');
                            sb.Append(tipoPedimento);
                            sb.Append('|');
                            foreach (var fechas in pedimento.Pedimento.PedimentoImpExpFechas)
                            {
                                if (fechas.ImpExpFechasFechaEntradaTipoClave == 2)
                                {
                                    sb.Append(fechas.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                    sb.Append('|');
                                }
                                else
                                {
                                    sb.Append('|');
                                }
                            }
                            
                        }
                    }
                }
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;

        }


        public byte[] Archivo_520(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|IndentFiscalDestinatario|NombreDestinatarioMercancia|CalleDestinatario|NumInteriorDestinatario|NumExteriorDestinatario|CpDestinatario|MunicpioDestinatario|PaisDestinatario|FechaPagoReal");

            if (pedimentos.Count != 0)
            {
                foreach (var pedimento in pedimentos)
                {
                    var descargos = pedimento.Pedimento.PedimentoDestinatario;

                    if (descargos.Count != 0)
                    {
                        foreach (var descargo in descargos)
                        {
                            sb.AppendLine();
                            sb.Append(pedimento.Pedimento.Patente);
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.Aduana.Trim());
                            sb.Append('|');
                            sb.Append(descargo.IdFiscal.Trim());
                            sb.Append('|');
                            sb.Append(descargo.NombreDestinatario.Trim());
                            sb.Append('|');
                            sb.Append(descargo.Calle.Trim());
                            sb.Append('|');
                            sb.Append(descargo.NumInt.Trim());
                            sb.Append('|');
                            sb.Append(descargo.NumExt.Trim());
                            sb.Append('|');
                            sb.Append(descargo.CP.Trim());
                            sb.Append('|');
                            sb.Append(descargo.CdMunicipio.Trim());
                            sb.Append('|');
                            sb.Append(descargo.PaisClave.Trim());
                            sb.Append('|');
                            foreach (var fechas in pedimento.Pedimento.PedimentoImpExpFechas)
                            {
                                if (fechas.ImpExpFechasFechaEntradaTipoClave == 2)
                                {
                                    sb.Append(fechas.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                    sb.Append('|');
                                }
                                else
                                {
                                    sb.Append('|');
                                }
                            }
                            
                        }
                    }
                }
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_551(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|Fraccion|SecuenciaFraccion|SubdivisionFraccion|DescripcionMercancia|PrecioUnitario|ValorAduana|ValorComercial|ValorDolares|CantidadUMComercial|UnidadMedidaComercial|CantidadUMTarifa|UnidadMedidaTarifa|ValorAgregado|ClaveVinculacion|MetodoValorizacion|CodigoMercanciaProducto|MarcaMercanciaProducto|ModeloMercanciaProducto|PaisOrigenDestino|PaisCompradorVendedor|EntidadFedOrigen|EntidadFedDestino|EntidadFedComprador|EntidadFedVendedor|TipoOperacion|ClaveDocumento|FechaPagoReal");

            foreach (var pedimento in pedimentos)
            {
                var partidas = pedimento.Pedimento.Partida;

                if (partidas.Count != 0)
                {
                    var destinatarios = pedimento.Pedimento.PedimentoDestinatario;

                    if (destinatarios.Count != 0)
                    {
                        foreach (var destinatario in destinatarios)
                        {
                            foreach (var partida in partidas)
                            {
                                var metodosVal = partida.PartidaMetodoValoracion;

                                var vinculaciones = partida.PartidaVinculacion;
                                
                                sb.AppendLine();
                                sb.Append(pedimento.Pedimento.Patente);
                                sb.Append('|');
                                sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                                sb.Append('|');
                                sb.Append(pedimento.Pedimento.Aduana.Trim());
                                sb.Append('|');
                                sb.Append(partida.FraccionArancelaria.Trim());
                                sb.Append('|');
                                sb.Append(partida.NumeroPartida);
                                sb.Append('|');
                                sb.Append(partida.SubDivisionFraccion.Trim());
                                sb.Append('|');
                                sb.Append(partida.DescMercancia.Trim());
                                sb.Append('|');
                                sb.Append(partida.PrecioUnitaro);
                                sb.Append('|');
                                sb.Append(partida.ValorAduana);
                                sb.Append('|');
                                sb.Append(partida.ValorComercial);
                                sb.Append('|');
                                sb.Append(partida.ValorDolares);
                                sb.Append('|');
                                sb.Append(partida.CantidadUnidadMedidaComercial);
                                sb.Append('|');
                                sb.Append(partida.UnidadMedComerClave.Trim());
                                sb.Append('|');
                                sb.Append(partida.CantidadUnidadMedidaTarifa);
                                sb.Append('|');
                                sb.Append(partida.UnidadMedTarifaClave.Trim());
                                sb.Append('|');
                                sb.Append(partida.ValorAgregado);
                                sb.Append('|');

                                foreach(var vinculacion in vinculaciones)
                                {
                                    sb.Append(vinculacion.VinculacionClave);
                                    sb.Append('|');
                                }
                                
                                foreach (var metodoVal in metodosVal)
                                {
                                    sb.Append(metodoVal.MetodoValorClave);
                                    sb.Append('|');
                                }                              
                                sb.Append(partida.CodigoMercancia.Trim());
                                sb.Append('|');
                                sb.Append(partida.MarcaMercancia.Trim());
                                sb.Append('|');
                                sb.Append(partida.ModeloMercancia.Trim());
                                sb.Append('|');
                                sb.Append(partida.PaisOrigDestClave.Trim());
                                sb.Append('|');
                                sb.Append(partida.PaisVendCompClave.Trim());
                                sb.Append('|');
                                sb.Append(destinatario.EntidadFederativa.Trim());
                                sb.Append('|');
                                //EntidadFedDestino
                                sb.Append('|');
                                //EntidadFedComprador
                                sb.Append('|');
                                //EntidadFedVendedor
                                sb.Append('|');
                                sb.Append(pedimento.Pedimento.EncabezadoOpClave);
                                sb.Append('|');
                                sb.Append(pedimento.Pedimento.EncabezadoClavDocClave.Trim());
                                sb.Append('|');
                                foreach (var fechas in pedimento.Pedimento.PedimentoImpExpFechas)
                                {
                                    if (fechas.ImpExpFechasFechaEntradaTipoClave == 2)
                                    {
                                        sb.Append(fechas.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                        sb.Append('|');
                                    }
                                    else
                                    {
                                        sb.Append('|');
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                            foreach (var partida in partidas)
                            {
                                var metodosVal = partida.PartidaMetodoValoracion;

                                var vinculaciones = partida.PartidaVinculacion;
                                sb.AppendLine();
                                sb.Append(pedimento.Pedimento.Patente);
                                sb.Append('|');
                                sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                                sb.Append('|');
                                sb.Append(pedimento.Pedimento.Aduana.Trim());
                                sb.Append('|');
                                sb.Append(partida.FraccionArancelaria.Trim());
                                sb.Append('|');
                                sb.Append(partida.NumeroPartida);
                                sb.Append('|');
                                sb.Append(partida.SubDivisionFraccion.Trim());
                                sb.Append('|');
                                sb.Append(partida.DescMercancia.Trim());
                                sb.Append('|');
                                sb.Append(partida.PrecioUnitaro);
                                sb.Append('|');
                                sb.Append(partida.ValorAduana);
                                sb.Append('|');
                                sb.Append(partida.ValorComercial);
                                sb.Append('|');
                                sb.Append(partida.ValorDolares);
                                sb.Append('|');
                                sb.Append(partida.CantidadUnidadMedidaComercial);
                                sb.Append('|');
                                sb.Append(partida.UnidadMedComerClave.Trim());
                                sb.Append('|');
                                sb.Append(partida.CantidadUnidadMedidaTarifa);
                                sb.Append('|');
                                sb.Append(partida.UnidadMedTarifaClave.Trim());
                                sb.Append('|');
                                sb.Append(partida.ValorAgregado);
                                sb.Append('|');
                                foreach (var vinculacion in vinculaciones)
                                {
                                    sb.Append(vinculacion.VinculacionClave);
                                    sb.Append('|');
                                }

                                foreach (var metodoVal in metodosVal)
                                {
                                    sb.Append(metodoVal.MetodoValorClave);
                                    sb.Append('|');
                                }
                                sb.Append(partida.CodigoMercancia.Trim());
                                sb.Append('|');
                                sb.Append(partida.MarcaMercancia.Trim());
                                sb.Append('|');
                                sb.Append(partida.ModeloMercancia.Trim());
                                sb.Append('|');
                                sb.Append(partida.PaisOrigDestClave.Trim());
                                sb.Append('|');
                                sb.Append(partida.PaisVendCompClave.Trim());
                                sb.Append('|');
                                //sb.Append(destinatario.EntidadFederativa.Trim());
                                sb.Append('|');
                                //EntidadFedDestino
                                sb.Append('|');
                                //EntidadFedComprador
                                sb.Append('|');
                                //EntidadFedVendedor
                                sb.Append('|');
                                sb.Append(pedimento.Pedimento.EncabezadoOpClave);
                                sb.Append('|');
                                sb.Append(pedimento.Pedimento.EncabezadoClavDocClave.Trim());
                                sb.Append('|');
                                foreach (var fechas in pedimento.Pedimento.PedimentoImpExpFechas)
                                {
                                    if (fechas.ImpExpFechasFechaEntradaTipoClave == 2)
                                    {
                                        sb.Append(fechas.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                        sb.Append('|');
                                    }
                                    else
                                    {
                                        sb.Append('|');
                                    }
                                }
                        }                                   
                    }
                }
             }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_552(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|Fraccion|SecuenciaFraccion|VinNumeroSerie|KilometrajeVehiculo|FechaPagoReal");
            if(pedimentos.Count != 0)
            {
                foreach (var pedimento in pedimentos)
                {
                    var partidas = pedimento.Pedimento.Partida;

                    if (partidas.Count != 0)
                    {
                        foreach (var partida in partidas)
                        {
                            var datosVechiculos = partida.PartidaDatosVehiculo;

                            if (datosVechiculos.Count != 0)
                            {
                                foreach (var datosVehiculo in datosVechiculos)
                                {
                                    sb.AppendLine();
                                    sb.Append(pedimento.Pedimento.Patente);
                                    sb.Append('|');
                                    sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                                    sb.Append('|');
                                    sb.Append(pedimento.Pedimento.Aduana.Trim());
                                    sb.Append('|');
                                    sb.Append(partida.FraccionArancelaria.Trim());
                                    sb.Append('|');
                                    sb.Append(partida.NumeroPartida);
                                    sb.Append('|');
                                    sb.Append(datosVehiculo.VinNumeroSerie.Trim());
                                    sb.Append('|');
                                    sb.Append(datosVehiculo.Kilometraje);
                                    sb.Append('|');
                                    foreach (var fecha in pedimento.Pedimento.PedimentoImpExpFechas)
                                    {
                                        if (fecha.ImpExpFechasFechaEntradaTipoClave == 2)
                                        {
                                            sb.Append(pedimento.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                            sb.Append('|');
                                        }
                                        else
                                        {
                                            sb.Append('|');
                                        }
                                    }
                                }
                            }
                        }
                    }
                }        
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_553(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|Fraccion|SecuenciaFraccion|ClavePermiso|FirmaDescargo|NumeroPermiso|ValorComercialDolares|CantidadMUMTarifa|FechaPagoReal");

            if (pedimentos.Count != 0)
            {
                foreach (var pedimento in pedimentos)
                {
                    var partidas = pedimento.Pedimento.Partida;

                    if (partidas.Count != 0)
                    {
                        foreach (var partida in partidas)
                        {
                            var permisos = partida.PartidaPermiso;

                            if (permisos.Count != 0)
                            {
                                foreach (var permiso in permisos)
                                {
                                    sb.AppendLine();
                                    sb.Append(pedimento.Pedimento.Patente);
                                    sb.Append('|');
                                    sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                                    sb.Append('|');
                                    sb.Append(pedimento.Pedimento.Aduana.Trim());
                                    sb.Append('|');
                                    sb.Append(partida.FraccionArancelaria.Trim());
                                    sb.Append('|');
                                    sb.Append(partida.NumeroPartida);
                                    sb.Append('|');
                                    sb.Append(permiso.PermisoClave.Trim());
                                    sb.Append('|');
                                    sb.Append(permiso.FirmaDescargo.Trim());
                                    sb.Append('|');
                                    sb.Append(permiso.NumeroPermiso.Trim());
                                    sb.Append('|');
                                    sb.Append(permiso.ValorComercialEnDolar);
                                    sb.Append('|');
                                    sb.Append(permiso.CantidadUMTUMC);
                                    sb.Append('|');
                                    foreach (var fecha in pedimento.Pedimento.PedimentoImpExpFechas)
                                    {
                                        if (fecha.ImpExpFechasFechaEntradaTipoClave == 2)
                                        {
                                            sb.Append(pedimento.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                            sb.Append('|');
                                        }
                                        else
                                        {
                                            sb.Append('|');
                                        }
                                    }
                                }
                            }
                        }
                    }
                }            
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }


        public byte[] Archivo_554(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|Fraccion|SecuenciaFraccion|ClaveCaso|IdentificadorCaso|ComplementoCaso|FechaPagoReal");

            foreach (var pedimento in pedimentos)
            {
                var partidas = pedimento.Pedimento.Partida;

                if (partidas.Count != 0)
                {
                    foreach (var partida in partidas)
                    {
                        var identificadores = partida.PartidaIdentificador;

                        if (identificadores.Count != 0)
                        {  
                            foreach (var identificador in identificadores)
                            {
                                
                                sb.AppendLine();
                                sb.Append(pedimento.Pedimento.Patente);
                                sb.Append('|');
                                sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                                sb.Append('|');
                                sb.Append(pedimento.Pedimento.Aduana.Trim());
                                sb.Append('|');
                                sb.Append(partida.FraccionArancelaria.Trim());
                                sb.Append('|');
                                sb.Append(partida.NumeroPartida);
                                sb.Append('|');
                                sb.Append(identificador.IdentificadorClaveIdentificadorClave.Trim());
                                sb.Append('|');
                                if(identificador.IdentificadorComplemento1 != null)
                                {
                                    sb.Append(identificador.IdentificadorComplemento1.Trim());
                                    sb.Append('|');
                                }
                                else
                                {
                                    sb.Append('|');
                                }
                                
                                if(identificador.IdentificadorComplemento2 != null)
                                {
                                    sb.Append(identificador.IdentificadorComplemento2.Trim());
                                    sb.Append('|');
                                }
                                else
                                {
                                    sb.Append('|');
                                }
                                foreach (var fecha in pedimento.Pedimento.PedimentoImpExpFechas)
                                {
                                    if(fecha.ImpExpFechasFechaEntradaTipoClave == 2 )
                                    {
                                        sb.Append(pedimento.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                        sb.Append('|');
                                    }
                                    else
                                    {
                                        sb.Append('|');
                                    }
                                }
                            }
                        }
                    }
                }

            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }
        public byte[] Archivo_555(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|Fraccion|SecuenciaFraccion|InstitucionEmisora|NumeroCuenta|FolioConstancia|FechaConstancia|ClaveGarantia|ValorUnitarioTitulo|TotalGarantia|CantidadUnidadesMedida|TitulosAsignados|FechaPagoReal");

            if(pedimentos.Count != 0)
            {
                foreach (var pedimento in pedimentos)
                {
                    var partidas = pedimento.Pedimento.Partida;

                    if (partidas.Count != 0)
                    {
                        foreach (var partida in partidas)
                        {
                            var cuentasAduaneras = partida.PartidaCuentaAduanera;

                            if (cuentasAduaneras.Count != 0)
                            {
                                foreach (var cuentaA in cuentasAduaneras)
                                {
                                    sb.Append(pedimento.Pedimento.Patente);
                                    sb.Append('|');
                                    sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                                    sb.Append('|');
                                    sb.Append(pedimento.Pedimento.Aduana.Trim());
                                    sb.Append('|');
                                    sb.Append(partida.FraccionArancelaria.Trim());
                                    sb.Append('|');
                                    sb.Append(partida.NumeroPartida);
                                    sb.Append('|');
                                    sb.Append(cuentaA.InsEmClave);
                                    sb.Append('|');
                                    sb.Append(cuentaA.NumCuenta);
                                    sb.Append('|');
                                    sb.Append(cuentaA.FolioConstancia.Trim());
                                    sb.Append('|');
                                    sb.Append(cuentaA.FechaConstancia);
                                    sb.Append('|');
                                    sb.Append(cuentaA.TipoGarantia.Trim());
                                    sb.Append('|');
                                    sb.Append('|');//ValorUnitarioTitulo                               
                                    sb.Append(cuentaA.GarantiaTotalGarantia);
                                    sb.Append('|');
                                    sb.Append('|');//CantidadUnidadesMedida
                                    sb.Append('|');//TitulosAsignados
                                    foreach (var fecha in pedimento.Pedimento.PedimentoImpExpFechas)
                                    {
                                        if (fecha.ImpExpFechasFechaEntradaTipoClave == 2)
                                        {
                                            sb.Append(pedimento.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                            sb.Append('|');
                                        }
                                        else
                                        {
                                            sb.Append('|');
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_556(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|Fraccion|SecuenciaFraccion|ClaveContribucion|TasaContribucion|TipoTasa|FechaPagoReal");

            foreach (var pedimento in pedimentos)
            {
                var partidas = pedimento.Pedimento.Partida;

                if (partidas.Count != 0)
                {
                    foreach (var partida in partidas)
                    {
                        var gravamenes = partida.PartidaGravamen;

                        if (gravamenes.Count != 0)
                        {
                            foreach (var gravamen in gravamenes)
                            {
                                var tasas = gravamen.PartidaTasa;
                                if(tasas.Count != 0)
                                {
                                    foreach(var tasa in tasas)
                                    {
                                        sb.AppendLine();
                                        sb.Append(pedimento.Pedimento.Patente);
                                        sb.Append('|');
                                        sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                                        sb.Append('|');
                                        sb.Append(pedimento.Pedimento.Aduana.Trim());
                                        sb.Append('|');
                                        sb.Append(partida.FraccionArancelaria.Trim());
                                        sb.Append('|');
                                        sb.Append(partida.NumeroPartida);
                                        sb.Append('|');
                                        sb.Append(gravamen.ClaveGravamenClave);
                                        sb.Append('|');
                                        sb.Append(tasa.TasaClave);
                                        sb.Append('|');
                                        sb.Append(tasa.TasaAplicable);
                                        sb.Append('|');
                                        foreach (var fecha in pedimento.Pedimento.PedimentoImpExpFechas)
                                        {
                                            if (fecha.ImpExpFechasFechaEntradaTipoClave == 2)
                                            {
                                                sb.Append(pedimento.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                                sb.Append('|');
                                            }
                                            else
                                            {
                                                sb.Append('|');
                                            }
                                        }
                                    }
                                }
                                
                            }
                        }
                    }
                }

            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }
        public byte[] Archivo_557(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|Fraccion|SecuenciaFraccion|ClaveContribucion|FormaPago|ImportePago|FechaPagoReal");

            foreach (var pedimento in pedimentos)
            {
                var partidas = pedimento.Pedimento.Partida;

                if (partidas.Count != 0)
                {
                    foreach (var partida in partidas)
                    {
                        var gravamenes = partida.PartidaGravamen;

                        if (gravamenes.Count != 0)
                        {
                            foreach (var gravamen in gravamenes)
                            {
                                var importes = gravamen.PartidaImporte;

                                foreach (var importe in importes)
                                {
                                    sb.AppendLine();
                                    sb.Append(pedimento.Pedimento.Patente);
                                    sb.Append('|');
                                    sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                                    sb.Append('|');
                                    sb.Append(pedimento.Pedimento.Aduana.Trim());
                                    sb.Append('|');
                                    sb.Append(partida.FraccionArancelaria.Trim());
                                    sb.Append('|');
                                    sb.Append(partida.NumeroPartida);
                                    sb.Append('|');
                                    sb.Append(gravamen.ClaveGravamenClave);
                                    sb.Append('|');
                                    sb.Append(importe.FormaPagoClave);
                                    sb.Append('|');
                                    sb.Append(importe.Importe);
                                    sb.Append('|');
                                    foreach (var fecha in pedimento.Pedimento.PedimentoImpExpFechas)
                                    {
                                        if (fecha.ImpExpFechasFechaEntradaTipoClave == 2)
                                        {
                                            sb.Append(pedimento.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                            sb.Append('|');
                                        }
                                        else
                                        {
                                            sb.Append('|');
                                        }
                                    }
                                }                              
                            }
                        }
                    }
                }

            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_558(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|Fraccion|SecuenciaFraccion|SecuenciaObservacion|Observaciones|FechaPagoReal");

            foreach (var pedimento in pedimentos)
            {
                var partidas = pedimento.Pedimento.Partida;

                if (partidas.Count != 0)
                {
                    foreach (var partida in partidas)
                    {
                        if (partida.ObservacionesDesc != "")
                        {
                            sb.AppendLine();
                            sb.Append(pedimento.Pedimento.Patente);
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.Aduana.Trim());
                            sb.Append('|');
                            sb.Append(partida.FraccionArancelaria.Trim());
                            sb.Append('|');
                            sb.Append(partida.NumeroPartida);
                            sb.Append('|');
                            sb.Append('1');
                            sb.Append('|');
                            sb.Append(partida.ObservacionesDesc.Trim());
                            sb.Append('|');
                            foreach (var fechas in pedimento.Pedimento.PedimentoImpExpFechas)
                            {
                                if (fechas.ImpExpFechasFechaEntradaTipoClave == 2)
                                {
                                    sb.Append(fechas.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                    sb.Append('|');
                                }
                            }                              
                                
                        }                      
                    }
                }

            }


            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_701(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|ClaveDocumento|FechaPago|PedimentoAnterior|PatenteAnterior|SeccionAduaneraAnterior|DocumentoAnterior|FechaOperacionAnterior|PedimentoOriginal|PatenteAduanalOrig|SeccionAduaneraDespOrig|FechaPagoReal");

            foreach (var pedimento in pedimentos)
            {
                if (pedimento.Pedimento.PedimentoOriginalRectificacion != 0)
                {
                    var partidas = pedimento.Pedimento.Partida;

                    if (partidas.Count != 0)
                    {
                        foreach (var partida in partidas)
                        {
                            sb.AppendLine();
                            sb.Append(pedimento.Pedimento.Patente);
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.Aduana.Trim());
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.EncabezadoClavDocClave.Trim());
                            sb.Append('|');
                            sb.Append(pedimento.ImpExpFechasFecha.ToString("yyyy/MM/dd"));
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.PedimentoOriginalRectificacion);
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.PatenteOriginalRectificacion);
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.aduDespRectificacionClav);
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.ClavDocRectificacionClave.Trim());
                            sb.Append('|');
                            sb.Append(pedimento.Pedimento.FechaOriginalRectificacion.Value.Date);
                            sb.Append('|');
                            sb.Append('|');//Pedimento Original
                            sb.Append('|');//Patente Original
                            sb.Append('|');//SeccionAduanera Original
                            foreach (var fecha in pedimento.Pedimento.PedimentoImpExpFechas)
                            {
                                if (fecha.ImpExpFechasFechaEntradaTipoClave == 2)
                                {
                                    sb.Append(pedimento.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                    sb.Append('|');
                                }
                                else
                                {
                                    sb.Append('|');
                                }
                            };
                        }
                    }
                }
            }


            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_702(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|ClaveContribucion|FormaPago|ImportePago|TipoPedimento|FechaPagoReal");

            foreach (var pedimento in pedimentos)
            {
                if (pedimento.Pedimento.PedimentoOriginalRectificacion != 0)
                {
                    var diferencias = pedimento.Pedimento.PedimentoDiferenciaContribucion;

                    if (diferencias.Count != 0)
                    {
                        int tipoPedimento = 1;

                        if (pedimento.Pedimento.PedimentoOriginalRectificacion != 0)
                        {
                            tipoPedimento = 2;
                        }
                        foreach (var diferencia in diferencias)
                        {
                            var partidas = pedimento.Pedimento.Partida;

                            if (partidas.Count != 0)
                            {
                                foreach (var partida in partidas)
                                {
                                    var gravamenes = partida.PartidaGravamen;

                                    foreach (var gravamen in gravamenes)
                                    {
                                        sb.AppendLine();
                                        sb.Append(pedimento.Pedimento.Patente);
                                        sb.Append('|');
                                        sb.Append(pedimento.Pedimento.NumPedimento.Trim());
                                        sb.Append('|');
                                        sb.Append(pedimento.Pedimento.Aduana.Trim());
                                        sb.Append('|');
                                        sb.Append(gravamen.ClaveGravamenClave);
                                        sb.Append('|');
                                        sb.Append(diferencia.ImportePago);
                                        sb.Append('|');
                                        sb.Append(tipoPedimento);
                                        sb.Append('|');
                                        foreach (var fecha in pedimento.Pedimento.PedimentoImpExpFechas)
                                        {
                                            if (fecha.ImpExpFechasFechaEntradaTipoClave == 2)
                                            {
                                                sb.Append(pedimento.ImpExpFechasFecha.ToString("yyyy/MM/dd HH:mm:ss"));
                                                sb.Append('|');
                                            }
                                            else
                                            {
                                                sb.Append('|');
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_Inci(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|ConsecutivoRemesa|NumeroSeleccion|FechaInicioReconocimiento|HoraInicioReconocimiento|FechaFinReconocimiento|HoraFinReconocimiento|Fraccion|SecuenciaFraccion|ClaveDocumento|TipoOperacion|GradoIncidencia|FechaSeleccion");

            //Registro Vacio, se necesita otro webservice
            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_Resumen(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Folio|RFCoPatenteAduanal|Fecha_Inicial|Fecha_Final|Fecha_Ejecucion|Total_Fracciones|Total_Contribuciones");
       
            sb.AppendLine();
            sb.Append("1000");//Incrementable
            sb.Append('|');
            sb.Append("patente");
            sb.Append('|');
            sb.Append(fechaInicio.ToString("yyyy/MM/dd"));
            sb.Append('|');
            sb.Append(fechaFin.ToString("yyyy/MM/dd"));
            sb.Append('|');
            sb.Append(DateTime.Now);
            sb.Append('|');
            sb.Append(totalFracciones);
            sb.Append('|');
            sb.Append(totalContribuciones);
            sb.Append('|');

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }

        public byte[] Archivo_Sel(DateTime fechaInicio, DateTime fechaFin)
        {
            stream.Dispose();

            var pedimentos = _dataStageRepo.TraerPedimentosPorFecha(fechaInicio, fechaFin);
            StringBuilder sb = new StringBuilder();
            sb.Append("Patente|Pedimento|SeccionAduanera|ConsecutivoRemesa|NumeroSeleccion|FechaSeleccion|HoraSeleccion|SemaforoFiscal|ClaveDocumento|TipoOperacion");

            //Registro Vacio, se necesita otro webservice

            var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
            stream = new MemoryStream(byteArray);
            return byteArray;
        }



        #endregion
    }
}
