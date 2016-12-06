using App.DAL;
using App.Entities;
using System;
using System.Diagnostics;
using App.Common;
namespace App.WebServiceVucem
{
    public class PedimentoCompletoWS : Usuario
    {

        #region Instancias
        Pedimento _pedimentoEntity;
        PedimentoImpExpFechas _pedimentoImpExpFechas;
        PedimentoTasa _pedimentoTasa;
        PedimentoTransporte _pedimentoTransporte;
        PedimentoGuia _pedimentoGuia;
        PedimentoContenedor _pedimentoContenedor;
        PedimentoFactura _pedimentoFactura;
        PedimentoCuentaAduanera _pedCuentaAduanera;
        PedimentoDescargo _pedDescargo;
        PedimentoDestinatario _pedDestinatario;
        PedimentoProveedorComprador _pedProveedorComprador;
        PedimentoIdentificador _pedIdentificador;
        PedimentoDiferenciaContribucion _pedDifContribucion;
        PedimentoRepository _pedRepo;
        ListaPedimentoRepository _listaRepo;
        PartidaWS _partida;
        private int intentos;
        private TimeSpan tiempo;

        #endregion

        #region Constructor
        public PedimentoCompletoWS()
        {
            _pedimentoEntity = new Pedimento();
            _pedimentoImpExpFechas = new PedimentoImpExpFechas();
            _pedimentoTasa = new PedimentoTasa();
            _pedProveedorComprador = new PedimentoProveedorComprador();
            _pedIdentificador = new PedimentoIdentificador();
            _pedRepo = new PedimentoRepository();
            _partida = new PartidaWS();
            _listaRepo = new ListaPedimentoRepository();
            _pedimentoTransporte = new PedimentoTransporte();
            _pedimentoGuia = new PedimentoGuia();
            _pedimentoContenedor = new PedimentoContenedor();
            _pedimentoFactura = new PedimentoFactura();
            _pedCuentaAduanera = new PedimentoCuentaAduanera();
            _pedDescargo = new PedimentoDescargo();
            _pedDestinatario = new PedimentoDestinatario();
            _pedDifContribucion = new PedimentoDiferenciaContribucion();
        }
        #endregion

        #region Metodos publicos
       
        public void ConsultaPedimento(long noPedimento, int patente, string aduana, int listaPedimentoId)
        {
            intentos = 0;
           
            do
            {               
                Stopwatch _stopWatch = new Stopwatch();
                PedimentoService.ConsultarPedimentoCompletoRespuesta respuesta = null;
                PedimentoService.ConsultarPedimentoCompletoServicePortTypeClient client = new PedimentoService.ConsultarPedimentoCompletoServicePortTypeClient();
                var conpeti = new PedimentoService.ConsultarPedimentoCompletoPeticion();
                client.ClientCredentials.UserName.UserName = Empresa.RFC;
                client.ClientCredentials.UserName.Password = Empresa.ContrasenaSAT;
                PedimentoService.PeticionPedimento peticion = new PedimentoService.PeticionPedimento();

                peticion.pedimento = noPedimento;
                peticion.patente = patente;
                peticion.aduana = aduana;
                conpeti.peticion = peticion;

                try
                {
                    intentos++;
                   
                    Console.WriteLine("Wait..");
                    _stopWatch.Start();
                    respuesta = client.consultarPedimentoCompleto(conpeti);
                    _stopWatch.Stop();
                    tiempo = _stopWatch.Elapsed;
                    Console.WriteLine("Tiempo: {0}", tiempo);
                    var pedimentoCompleto = respuesta.pedimento;
                    _pedimentoEntity.Tiempo = tiempo.ToString();
                    _pedimentoEntity.TieneError = respuesta.tieneError;
                    _pedimentoEntity.ListaPedimentoId = listaPedimentoId;
                    _pedimentoEntity.Aduana = aduana;
                    _pedimentoEntity.Patente = patente;

                    if (respuesta.tieneError == false)
                    {
                        if(pedimentoCompleto.observaciones != null) { _pedimentoEntity.ObservacionesPedimento = pedimentoCompleto.observaciones; }                        
                        else { _pedimentoEntity.ObservacionesPedimento = ""; }

                        if (pedimentoCompleto.pedimento.ToString() != "") { _pedimentoEntity.NumPedimento = pedimentoCompleto.pedimento.ToString(); }

                        _pedimentoEntity.TieneError = respuesta.tieneError;

                        if (pedimentoCompleto.partidas == null)
                        { _pedimentoEntity.CantidadPartidas = 0; }
                        else
                        { _pedimentoEntity.CantidadPartidas = pedimentoCompleto.partidas.Length; }
                        
                        if ( pedimentoCompleto.encabezado != null)
                        { 
                        _pedimentoEntity.EncabezadoOpClave = pedimentoCompleto.encabezado.tipoOperacion.clave;
                            if (pedimentoCompleto.encabezado.tipoOperacion.descripcion != null) { _pedimentoEntity.EncabezadoOpDesc = pedimentoCompleto.encabezado.tipoOperacion.descripcion; }
                            else { _pedimentoEntity.EncabezadoOpDesc = ""; }
                            
                        
                            if(pedimentoCompleto.encabezado.claveDocumento.clave != null) { _pedimentoEntity.EncabezadoClavDocClave = pedimentoCompleto.encabezado.claveDocumento.clave; }
                            else { _pedimentoEntity.EncabezadoClavDocClave = ""; }
                             
                        
                        if(pedimentoCompleto.encabezado.claveDocumento != null) { _pedimentoEntity.EncabezadoClavDocDescripcion = pedimentoCompleto.encabezado.claveDocumento.descripcion; }
                            else { _pedimentoEntity.EncabezadoClavDocDescripcion = ""; }

                        _pedimentoEntity.EncabezadoDestinoClave = pedimentoCompleto.encabezado.destino.clave;
                        if(pedimentoCompleto.encabezado.destino.descripcion != null) { _pedimentoEntity.EncabezadoDestionDesc = pedimentoCompleto.encabezado.destino.descripcion; }
                            else{ _pedimentoEntity.EncabezadoDestionDesc = ""; }
                        
                        _pedimentoEntity.EncabezadoAduEntSalidaClave = pedimentoCompleto.encabezado.aduanaEntradaSalida.clave;
                        if(pedimentoCompleto.encabezado.aduanaEntradaSalida.descripcion != null) { _pedimentoEntity.EncabezadoAduEntSalidaDesc = pedimentoCompleto.encabezado.aduanaEntradaSalida.descripcion ; }
                        else { _pedimentoEntity.EncabezadoAduEntSalidaDesc = ""; }

                        _pedimentoEntity.EncabezadoMedTranspSalClave = pedimentoCompleto.encabezado.medioTrasnporteSalida.clave;
                        if(pedimentoCompleto.encabezado.medioTrasnporteSalida.descripcion != null) { _pedimentoEntity.EncabezadoMedTranspSalDesc = pedimentoCompleto.encabezado.medioTrasnporteSalida.descripcion; }
                        else { _pedimentoEntity.EncabezadoMedTranspSalDesc = ""; }

                        _pedimentoEntity.EncabezadoTipoCambio = pedimentoCompleto.encabezado.tipoCambio;
                        _pedimentoEntity.EncabezadoPesoBruto = pedimentoCompleto.encabezado.pesoBruto;
                       

                         
                        _pedimentoEntity.EncabezadoMedTranspArriboClave = pedimentoCompleto.encabezado.medioTrasnporteArribo.clave;
                            if(pedimentoCompleto.encabezado.medioTrasnporteArribo.descripcion != null) { _pedimentoEntity.EncabezadoMedTranspArriboDesc = pedimentoCompleto.encabezado.medioTrasnporteArribo.descripcion; }
                            else { _pedimentoEntity.EncabezadoMedTranspArriboDesc = ""; }

                            _pedimentoEntity.EncabezadoMedTranspEntradaClave = pedimentoCompleto.encabezado.medioTrasnporteEntrada.clave;

                            if (pedimentoCompleto.encabezado.medioTrasnporteEntrada.descripcion != null) { _pedimentoEntity.EncabezadoMedTranspEntradaDesc = pedimentoCompleto.encabezado.medioTrasnporteEntrada.descripcion; }
                            else { _pedimentoEntity.EncabezadoMedTranspEntradaDesc = ""; }

                            if (pedimentoCompleto.encabezado.curpApoderadomandatario != null) { _pedimentoEntity.CurpApoderadoMandatario = pedimentoCompleto.encabezado.curpApoderadomandatario; }
                            else { _pedimentoEntity.CurpApoderadoMandatario = ""; }

                            if (pedimentoCompleto.encabezado.rfcAgenteAduanalSocFactura != null) { _pedimentoEntity.RFCAduanalSocFactura = pedimentoCompleto.encabezado.rfcAgenteAduanalSocFactura; }
                            else { _pedimentoEntity.RFCAduanalSocFactura = ""; }

                            _pedimentoEntity.ValorAduanaTotal = pedimentoCompleto.encabezado.valorAduanalTotal;
                        _pedimentoEntity.ValorComercialTotal = pedimentoCompleto.encabezado.valorComercialTotal;
                        }
                        if ( pedimentoCompleto.rectificacion != null )
                        { 
                        //Rectificacion
                        _pedimentoEntity.aduOrigRectificacionClav = pedimentoCompleto.rectificacion.aduanaOriginal.clave;
                        if(pedimentoCompleto.rectificacion.aduanaOriginal.descripcion != null) { _pedimentoEntity.aduOrigRectificacionDesc = pedimentoCompleto.rectificacion.aduanaOriginal.descripcion; }
                            else { _pedimentoEntity.aduOrigRectificacionDesc = ""; }

                            _pedimentoEntity.aduDespRectificacionClav = pedimentoCompleto.rectificacion.aduanaDespacho.clave;

                            if (pedimentoCompleto.rectificacion.aduanaDespacho != null) { _pedimentoEntity.aduDespRectificacionDesc = pedimentoCompleto.rectificacion.aduanaDespacho.descripcion; }
                            else { _pedimentoEntity.aduDespRectificacionDesc = ""; }

                            _pedimentoEntity.ClavDocRectificacionClave = pedimentoCompleto.rectificacion.claveDocumento.clave;
                            if(pedimentoCompleto.rectificacion.claveDocumento.descripcion != null) { _pedimentoEntity.ClavDocRectificacionDesc = pedimentoCompleto.rectificacion.claveDocumento.descripcion; }
                            else { _pedimentoEntity.ClavDocRectificacionDesc = ""; }

                            if (pedimentoCompleto.rectificacion.fechaPago != DateTime.MinValue) { _pedimentoEntity.FechaPagoRectificacion = pedimentoCompleto.rectificacion.fechaPago; }
                        _pedimentoEntity.PedimentoOriginalRectificacion = pedimentoCompleto.rectificacion.pedimentoOriginal;
                        _pedimentoEntity.PatenteOriginalRectificacion = pedimentoCompleto.rectificacion.patenteOriginal;
                        if(pedimentoCompleto.rectificacion.fechaOriginal != DateTime.MinValue) { _pedimentoEntity.FechaOriginalRectificacion = pedimentoCompleto.rectificacion.fechaOriginal; }
                        }
                        if (pedimentoCompleto.importadorExportador != null)
                        { 
                        //Importador Exportador
                        if (pedimentoCompleto.importadorExportador.rfc != null) { _pedimentoEntity.ImpExpCurpImpExp = pedimentoCompleto.importadorExportador.rfc; }
                            else { _pedimentoEntity.ImpExpCurpImpExp = ""; }

                            if (pedimentoCompleto.importadorExportador.razonSocial != null) { _pedimentoEntity.ImpExpRazSocImpExp = pedimentoCompleto.importadorExportador.razonSocial; }
                            else { _pedimentoEntity.ImpExpRazSocImpExp = ""; }

                            if (pedimentoCompleto.importadorExportador.domicilio != null)
                            {
                                if (pedimentoCompleto.importadorExportador.domicilio.calle != null) { _pedimentoEntity.ImpExpDomCalle = pedimentoCompleto.importadorExportador.domicilio.calle; }
                                else { _pedimentoEntity.ImpExpDomCalle = ""; }
                                if (pedimentoCompleto.importadorExportador.domicilio.numeroExterior != null) { _pedimentoEntity.ImpExpNumDomExterior = pedimentoCompleto.importadorExportador.domicilio.numeroExterior; }
                                else { _pedimentoEntity.ImpExpNumDomExterior = ""; }
                                if (pedimentoCompleto.importadorExportador.domicilio.numeroInterior != null) { _pedimentoEntity.ImpExpNumDomInterior = pedimentoCompleto.importadorExportador.domicilio.numeroInterior; }
                                else { _pedimentoEntity.ImpExpNumDomInterior = ""; }
                                if (pedimentoCompleto.importadorExportador.domicilio.ciudadMunicipio != null) { _pedimentoEntity.ImpExpDomCdMunicipio = pedimentoCompleto.importadorExportador.domicilio.ciudadMunicipio; }
                                else { _pedimentoEntity.ImpExpDomCdMunicipio = ""; }
                                if (pedimentoCompleto.importadorExportador.domicilio.codigoPostal != null) { _pedimentoEntity.ImpExpDomCP = pedimentoCompleto.importadorExportador.domicilio.codigoPostal; }
                                else { _pedimentoEntity.ImpExpDomCP = ""; }
                            }
                        
                        _pedimentoEntity.ImpExpSeguros = pedimentoCompleto.importadorExportador.seguros;
                        _pedimentoEntity.ImpExpFletes = pedimentoCompleto.importadorExportador.fletes;
                        _pedimentoEntity.ImpExpEmbalajes = pedimentoCompleto.importadorExportador.embalajes;
                        _pedimentoEntity.ImpExpIncrementables = pedimentoCompleto.importadorExportador.incrementables;

                        _pedimentoEntity.ImpExpAudoDespachoClave = pedimentoCompleto.importadorExportador.aaduanaDespacho.clave;
                        if(pedimentoCompleto.importadorExportador.aaduanaDespacho.descripcion != null) { _pedimentoEntity.ImpExpAudoDespachoDesc = pedimentoCompleto.importadorExportador.aaduanaDespacho.descripcion; }
                            else { _pedimentoEntity.ImpExpAudoDespachoDesc = ""; }
                        
                        //Fechas                        
                        if(pedimentoCompleto.importadorExportador.fechas != null)
                        {
                            for (int i = 0; i < pedimentoCompleto.importadorExportador.fechas.Length; i++)
                            {
                                _pedimentoImpExpFechas = new PedimentoImpExpFechas();
                                _pedimentoImpExpFechas.ImpExpFechasFecha = pedimentoCompleto.importadorExportador.fechas[i].fecha;
                                _pedimentoImpExpFechas.ImpExpFechasFechaEntradaTipoClave = pedimentoCompleto.importadorExportador.fechas[i].tipo.clave;
                                if(pedimentoCompleto.importadorExportador.fechas[i].tipo.descripcion != null) { _pedimentoImpExpFechas.ImpExpFechasFechaTipoDesc = pedimentoCompleto.importadorExportador.fechas[i].tipo.descripcion; }
                                    else { _pedimentoImpExpFechas.ImpExpFechasFechaTipoDesc = ""; }
                                _pedimentoEntity.PedimentoImpExpFechas.Add(_pedimentoImpExpFechas);
                            }
                        }
                        
                        _pedimentoEntity.ImpExpEfectivo = pedimentoCompleto.importadorExportador.efectivo;
                        _pedimentoEntity.ImpExpOtros = pedimentoCompleto.importadorExportador.otros;
                        _pedimentoEntity.ImpExpTotal = pedimentoCompleto.importadorExportador.total;
                            if(pedimentoCompleto.importadorExportador.pais.clave != null) { _pedimentoEntity.ImpExpPaisClave = pedimentoCompleto.importadorExportador.pais.clave; }
                            else { _pedimentoEntity.ImpExpPaisClave = ""; }
                            if (pedimentoCompleto.importadorExportador.pais.descripcion != null) { _pedimentoEntity.ImpExpPaisDesc = pedimentoCompleto.importadorExportador.pais.descripcion; }
                            else { _pedimentoEntity.ImpExpPaisDesc = ""; }
                        }

                        // Proveedor Comprador
                        if (pedimentoCompleto.proveedoresCompradores != null)
                        {
                            for (int i = 0; i < pedimentoCompleto.proveedoresCompradores.Length; i++)
                            {
                                _pedProveedorComprador = new PedimentoProveedorComprador();
                                if(pedimentoCompleto.proveedoresCompradores[i].identificadorFiscal != null) { _pedProveedorComprador.ProvCompIdFiscalProvComprador = pedimentoCompleto.proveedoresCompradores[i].identificadorFiscal; }
                                else { _pedProveedorComprador.ProvCompIdFiscalProvComprador = ""; }
                                if (pedimentoCompleto.proveedoresCompradores[i].proveedorComprador != null) { _pedProveedorComprador.ProvCompProveedorComprador = pedimentoCompleto.proveedoresCompradores[i].proveedorComprador; }
                                else { _pedProveedorComprador.ProvCompProveedorComprador = ""; }

                                _pedProveedorComprador.ProvCompValorDolares = pedimentoCompleto.proveedoresCompradores[i].valorDolares;
                                _pedProveedorComprador.ProvCompValorMonedaExt = pedimentoCompleto.proveedoresCompradores[i].valorMonedaExtranjera;

                                if( pedimentoCompleto.proveedoresCompradores[i].pais != null)
                                {
                                    if (_pedProveedorComprador.ProvCompPaisClave != null) { _pedProveedorComprador.ProvCompPaisClave = pedimentoCompleto.proveedoresCompradores[i].pais.clave; }
                                    else { _pedProveedorComprador.ProvCompPaisClave = ""; }
                                    if (pedimentoCompleto.proveedoresCompradores[i].pais.descripcion != null) { _pedProveedorComprador.ProvCompPaisDesc = pedimentoCompleto.proveedoresCompradores[i].pais.descripcion; }
                                    else { _pedProveedorComprador.ProvCompPaisDesc = ""; }
                                }
                                if (pedimentoCompleto.proveedoresCompradores[i].domicilio != null)
                                {
                                    if (pedimentoCompleto.proveedoresCompradores[i].domicilio.calle != null) { _pedProveedorComprador.ProvCompDomCalle = pedimentoCompleto.proveedoresCompradores[i].domicilio.calle; }
                                    else { _pedProveedorComprador.ProvCompDomCalle = ""; }
                                    if (pedimentoCompleto.proveedoresCompradores[i].domicilio.ciudadMunicipio != null) { _pedProveedorComprador.ProvCompDomCdMunicipio = pedimentoCompleto.proveedoresCompradores[i].domicilio.ciudadMunicipio; }
                                    else { _pedProveedorComprador.ProvCompDomCdMunicipio = ""; }
                                    if (pedimentoCompleto.proveedoresCompradores[i].domicilio.codigoPostal != null) { _pedProveedorComprador.ProvCompDomCP = pedimentoCompleto.proveedoresCompradores[i].domicilio.codigoPostal; }
                                    else { _pedProveedorComprador.ProvCompDomCP = ""; }
                                    if (pedimentoCompleto.proveedoresCompradores[i].domicilio.numeroExterior != null) { _pedProveedorComprador.ProvCompDomNumExterior = pedimentoCompleto.proveedoresCompradores[i].domicilio.numeroExterior; }
                                    else { _pedProveedorComprador.ProvCompDomNumExterior = ""; }
                                    if (pedimentoCompleto.proveedoresCompradores[i].domicilio.numeroInterior != null) { _pedProveedorComprador.ProvCompDomNumInterior = pedimentoCompleto.proveedoresCompradores[i].domicilio.numeroInterior; }
                                    else { _pedProveedorComprador.ProvCompDomNumInterior = "";  }
                                    if (pedimentoCompleto.proveedoresCompradores[i].domicilio.pais != null) { _pedProveedorComprador.ProvCompDomPais = pedimentoCompleto.proveedoresCompradores[i].domicilio.pais; }
                                    else { _pedProveedorComprador.ProvCompDomPais = ""; }
                                }

                                _pedimentoEntity.PedimentoProveedorComprador.Add(_pedProveedorComprador);

                            }
                        }
                        //Transportes
                        if(pedimentoCompleto.transportes != null)
                        {
                            for (int i = 0; i < pedimentoCompleto.transportes.Length; i++)
                            {
                                _pedimentoTransporte = new PedimentoTransporte();
                                if (pedimentoCompleto.transportes[i].identificador != null) { _pedimentoTransporte.IdentificadorTransporte = pedimentoCompleto.transportes[i].identificador; }
                                else { _pedimentoTransporte.IdentificadorTransporte = ""; }
                                if (pedimentoCompleto.transportes[i].paisTransporte.clave != null) { _pedimentoTransporte.PaisTransporteClave = pedimentoCompleto.transportes[i].paisTransporte.clave; }
                                else { _pedimentoTransporte.PaisTransporteClave = ""; }
                                if (pedimentoCompleto.transportes[i].paisTransporte.descripcion != null) { _pedimentoTransporte.PaisTransporteDesc = pedimentoCompleto.transportes[i].paisTransporte.descripcion; }
                                else { _pedimentoTransporte.PaisTransporteDesc = ""; }
                                if (pedimentoCompleto.transportes[i].nombre !=null) { _pedimentoTransporte.NombreTransporte = pedimentoCompleto.transportes[i].nombre; }
                                else { _pedimentoTransporte.NombreTransporte = ""; }
                                if (pedimentoCompleto.transportes[i].rfcTransportista != null) { _pedimentoTransporte.RFCTransporte = pedimentoCompleto.transportes[i].rfcTransportista; }
                                else { _pedimentoTransporte.RFCTransporte = ""; }
                                if (pedimentoCompleto.transportes[i].curpTransportista != null) { _pedimentoTransporte.CURPTransportista = pedimentoCompleto.transportes[i].curpTransportista; }
                                else { _pedimentoTransporte.CURPTransportista = ""; }
                                if (pedimentoCompleto.transportes[i].domicilioTransportista != null) { _pedimentoTransporte.DomFiscalTransportista = pedimentoCompleto.transportes[i].domicilioTransportista; }
                                else { _pedimentoTransporte.DomFiscalTransportista = ""; }
                                if (pedimentoCompleto.transportes[i].candados != null) { _pedimentoTransporte.CandadosTransporte = pedimentoCompleto.transportes[i].candados; }
                                else { _pedimentoTransporte.CandadosTransporte = ""; }

                                _pedimentoEntity.PedimentoTransporte.Add(_pedimentoTransporte);
                            }
                        }
                        //Guias
                        if(pedimentoCompleto.guias != null)
                        {
                            for(int i=0; i<pedimentoCompleto.guias.Length; i++)
                            {
                                if(pedimentoCompleto.guias[i].guiaManifiesto != null) { _pedimentoGuia.GuiaManifesto = pedimentoCompleto.guias[i].guiaManifiesto; }
                                else { _pedimentoGuia.GuiaManifesto = ""; }
                                if (pedimentoCompleto.guias[i].tipoGuia != null) { _pedimentoGuia.TipoGuia = pedimentoCompleto.guias[i].tipoGuia; }
                                else { _pedimentoGuia.TipoGuia = ""; }

                                _pedimentoEntity.PedimentoGuia.Add(_pedimentoGuia);
                            }
                        }

                        //Contenedor
                        if(pedimentoCompleto.contenedores != null)
                        {
                            for(int i=0; i<pedimentoCompleto.contenedores.Length; i++)
                            {
                                if(pedimentoCompleto.contenedores[i].identificador != null) { _pedimentoContenedor.IdContenedor = pedimentoCompleto.contenedores[i].identificador; }
                                else { _pedimentoContenedor.IdContenedor = ""; }
                                _pedimentoContenedor.TipoContenerdorClave = pedimentoCompleto.contenedores[i].tipoContenedor.clave; 
                                if(pedimentoCompleto.contenedores[i].tipoContenedor.descripcion != null) { _pedimentoContenedor.TipoContenedorDesc = pedimentoCompleto.contenedores[i].tipoContenedor.descripcion; }
                                else { _pedimentoContenedor.TipoContenedorDesc = ""; }

                                _pedimentoEntity.PedimentoContenedor.Add(_pedimentoContenedor);
                            }
                        }

                        // Facturas
                        if(pedimentoCompleto.facturas != null)
                        {
                            for(int i=0; i < pedimentoCompleto.facturas.Length; i++)
                            {
                                _pedimentoFactura = new PedimentoFactura();

                                if(pedimentoCompleto.facturas[i].fecha != DateTime.MinValue) { _pedimentoFactura.FechaFacturacion = pedimentoCompleto.facturas[i].fecha; }
                                if(pedimentoCompleto.facturas[i].numero != null) { _pedimentoFactura.NumeroFactura = pedimentoCompleto.facturas[i].numero; }
                                else { _pedimentoFactura.NumeroFactura = ""; }
                                if (pedimentoCompleto.facturas[i].terminoFacturacion.clave != null) { _pedimentoFactura.TerminoFacturacionClave = pedimentoCompleto.facturas[i].terminoFacturacion.clave; }
                                else { _pedimentoFactura.TerminoFacturacionClave = ""; }
                                if (pedimentoCompleto.facturas[i].terminoFacturacion.descripcion != null) { _pedimentoFactura.TerminoFacturacionDesc = pedimentoCompleto.facturas[i].terminoFacturacion.descripcion; }
                                else { _pedimentoFactura.TerminoFacturacionDesc = ""; }

                                if (pedimentoCompleto.facturas[i].moneda != null)
                                {
                                    if (pedimentoCompleto.facturas[i].moneda.clave != null) { _pedimentoFactura.MonedaClave = pedimentoCompleto.facturas[i].moneda.clave; }
                                else { _pedimentoFactura.MonedaClave = ""; }

                                if (pedimentoCompleto.facturas[i].moneda.descripcion != null) { _pedimentoFactura.MonedaDesc = pedimentoCompleto.facturas[i].moneda.descripcion; }
                                else { _pedimentoFactura.MonedaDesc = ""; }
                            }
                                _pedimentoFactura.ValDolares = pedimentoCompleto.facturas[i].valorDolares;
                                _pedimentoFactura.ValMonedaExt = pedimentoCompleto.facturas[i].valorMonedaExtranjera;
                                if(pedimentoCompleto.facturas[i].identificadorFiscalProveedorComprador != null) { _pedimentoFactura.IdFiscalProvComp = pedimentoCompleto.facturas[i].identificadorFiscalProveedorComprador; }
                                else { _pedimentoFactura.IdFiscalProvComp = ""; }
                                if (pedimentoCompleto.facturas[i].proveedorComprador != null) { _pedimentoFactura.ProveedorComp = pedimentoCompleto.facturas[i].proveedorComprador; }
                                else { _pedimentoFactura.ProveedorComp = ""; }

                                _pedimentoEntity.PedimentoFactura.Add(_pedimentoFactura);
                            }
                        }
                        //Cuentas Aduaneras

                        if(pedimentoCompleto.cuentasAduaneras !=null)
                        {
                            for(int i=0; i<pedimentoCompleto.cuentasAduaneras.Length; i++)
                            {
                                _pedCuentaAduanera = new PedimentoCuentaAduanera();
                                _pedCuentaAduanera.InstEmisoraClave = pedimentoCompleto.cuentasAduaneras[i].institucionEmisora.clave;
                                if (pedimentoCompleto.cuentasAduaneras[i].institucionEmisora.descripcion != null) { _pedCuentaAduanera.InstEmisoraDesc = pedimentoCompleto.cuentasAduaneras[i].institucionEmisora.descripcion; }
                                else { _pedCuentaAduanera.InstEmisoraDesc = ""; }
                                if (pedimentoCompleto.cuentasAduaneras[i].numeroCuenta != null) { _pedCuentaAduanera.InstEmisoraNumCuenta = pedimentoCompleto.cuentasAduaneras[i].numeroCuenta; }
                                else { _pedCuentaAduanera.InstEmisoraNumCuenta = ""; }
                                if (pedimentoCompleto.cuentasAduaneras[i].folioConstancia != null) { _pedCuentaAduanera.InstEmisoraFolioConstancia = pedimentoCompleto.cuentasAduaneras[i].folioConstancia; }
                                else { _pedCuentaAduanera.InstEmisoraFolioConstancia = ""; }
                                if (pedimentoCompleto.cuentasAduaneras[i].fechaConstancia != DateTime.MinValue) { _pedCuentaAduanera.FechaConstancia = pedimentoCompleto.cuentasAduaneras[i].fechaConstancia; }
                                if(pedimentoCompleto.cuentasAduaneras[i].tipoCuenta != null) { _pedCuentaAduanera.TipoCuentaDesc = pedimentoCompleto.cuentasAduaneras[i].tipoCuenta; }
                                else { _pedCuentaAduanera.TipoCuentaDesc = ""; }
                                if (pedimentoCompleto.cuentasAduaneras[i].tipoGarantia != null) { _pedCuentaAduanera.TipoGarantiaDesc = pedimentoCompleto.cuentasAduaneras[i].tipoGarantia; }
                                else { _pedCuentaAduanera.TipoGarantiaDesc = ""; }

                                _pedCuentaAduanera.CuentaTotalGarantia = pedimentoCompleto.cuentasAduaneras[i].totalGarantia;
                                _pedCuentaAduanera.CuentaCantidadUMC = pedimentoCompleto.cuentasAduaneras[i].cantidadUMC;
                                _pedimentoEntity.PedimentoCuentaAduanera.Add(_pedCuentaAduanera);
                            }
                        }


                        //Descargos
                        if(pedimentoCompleto.descargos != null)
                        {
                            for(int i=0; i<pedimentoCompleto.descargos.Length; i++)
                            {
                               _pedDescargo = new PedimentoDescargo();
                               _pedDescargo.PatenteOriginal = pedimentoCompleto.descargos[i].patenteOriginal;
                               _pedDescargo.PedimentoOriginal =  pedimentoCompleto.descargos[i].pedimentoOriginal;
                                _pedDescargo.AduanaOrigClave = pedimentoCompleto.descargos[i].aduanaOriginal.clave;
                                if(pedimentoCompleto.descargos[i].aduanaOriginal.descripcion != null) { _pedDescargo.AduanaOrigDesc = pedimentoCompleto.descargos[i].aduanaOriginal.descripcion; }
                                else { _pedDescargo.AduanaOrigDesc = ""; }
                                if (pedimentoCompleto.descargos[i].claveDocumentoOriginal.clave != null ) { _pedDescargo.ClaveDocOrigClave = pedimentoCompleto.descargos[i].claveDocumentoOriginal.clave; }
                                else { _pedDescargo.ClaveDocOrigClave = ""; }
                                if (pedimentoCompleto.descargos[i].claveDocumentoOriginal.descripcion != null) { _pedDescargo.ClaveDocOrigDesc = pedimentoCompleto.descargos[i].claveDocumentoOriginal.descripcion; }
                                else { _pedDescargo.ClaveDocOrigDesc = ""; }
                                if (pedimentoCompleto.descargos[i].fechaPagoOriginal != DateTime.MinValue) { _pedDescargo.FechaPagoOriginal = pedimentoCompleto.descargos[i].fechaPagoOriginal; }
                                if (pedimentoCompleto.descargos[i].fraccionOriginal != null) { _pedDescargo.FraccionOriginal = pedimentoCompleto.descargos[i].fraccionOriginal; }
                                else { _pedDescargo.FraccionOriginal = ""; }

                                if (pedimentoCompleto.descargos[i].UnidadMedida != null)
                                { 
                                    if (pedimentoCompleto.descargos[i].UnidadMedida.clave != null) { _pedDescargo.UnidadMedOrigClave = pedimentoCompleto.descargos[i].UnidadMedida.clave; }
                                    else { _pedDescargo.UnidadMedOrigClave = ""; }
                                    if (pedimentoCompleto.descargos[i].UnidadMedida.descripcion != null) { _pedDescargo.UnidadMedOrigDesc = pedimentoCompleto.descargos[i].UnidadMedida.descripcion; }
                                    else { _pedDescargo.UnidadMedOrigDesc = ""; }
                                }
                                _pedDescargo.Cantidad = pedimentoCompleto.descargos[i].cantidad;
                                _pedimentoEntity.PedimentoDescargo.Add(_pedDescargo);
                            }

                        }

                        //Destinatario

                        if(pedimentoCompleto.destinatarios != null)
                        {
                            for(int i=0; i<pedimentoCompleto.destinatarios.Length; i++)
                            {
                                if(pedimentoCompleto.destinatarios[i].identificadorFiscal != null) { _pedDestinatario.IdFiscal = pedimentoCompleto.destinatarios[i].identificadorFiscal; }
                                else { _pedDestinatario.IdFiscal = ""; }
                                if (pedimentoCompleto.destinatarios[i].nombre != null) { _pedDestinatario.NombreDestinatario = pedimentoCompleto.destinatarios[i].nombre; }
                                else { _pedDestinatario.NombreDestinatario = ""; }

                                if (pedimentoCompleto.destinatarios[i].domicilio != null)
                                {
                                    if (pedimentoCompleto.destinatarios[i].domicilio.calle != null) { _pedDestinatario.Calle = pedimentoCompleto.destinatarios[i].domicilio.calle; }
                                    else { _pedDestinatario.Calle = ""; }
                                    if (pedimentoCompleto.destinatarios[i].domicilio.numeroExterior != null) { _pedDestinatario.NumExt = pedimentoCompleto.destinatarios[i].domicilio.numeroExterior; }
                                    else { _pedDestinatario.NumExt = ""; }
                                    if (pedimentoCompleto.destinatarios[i].domicilio.numeroInterior != null) { _pedDestinatario.NumInt = pedimentoCompleto.destinatarios[i].domicilio.numeroInterior; }
                                    else { _pedDestinatario.NumInt = ""; }
                                    if (pedimentoCompleto.destinatarios[i].domicilio.ciudadMunicipio != null) { _pedDestinatario.CdMunicipio = pedimentoCompleto.destinatarios[i].domicilio.ciudadMunicipio; }
                                    else { _pedDestinatario.CdMunicipio = ""; }
                                    if (pedimentoCompleto.destinatarios[i].domicilio.codigoPostal != null) { _pedDestinatario.CP = pedimentoCompleto.destinatarios[i].domicilio.codigoPostal; }
                                    else { _pedDestinatario.CP = ""; }
                                }
                                if (pedimentoCompleto.destinatarios[i].entidadFederativa != null) { _pedDestinatario.EntidadFederativa = pedimentoCompleto.destinatarios[i].entidadFederativa; }
                                else { _pedDestinatario.EntidadFederativa = ""; }

                                if (pedimentoCompleto.destinatarios[i].pais != null)
                                { 
                                    if (pedimentoCompleto.destinatarios[i].pais.clave != null) { _pedDestinatario.PaisClave = pedimentoCompleto.destinatarios[i].pais.clave; }
                                    else { _pedDestinatario.PaisClave = ""; }
                                    if (pedimentoCompleto.destinatarios[i].pais.descripcion != null) { _pedDestinatario.PaisDesc = pedimentoCompleto.destinatarios[i].pais.descripcion; }
                                    else { _pedDestinatario.PaisDesc = ""; }
                                }
                                _pedimentoEntity.PedimentoDestinatario.Add(_pedDestinatario);
                            }
                        }


                        //Tasas
                        if(pedimentoCompleto.tasas != null)
                        {
                            for (int i = 0; i < pedimentoCompleto.tasas.Length; i++)
                            {
                                _pedimentoTasa = new PedimentoTasa();
                                _pedimentoTasa.TasasClaveContribucionClave = pedimentoCompleto.tasas[i].contribucion.clave;
                                if(pedimentoCompleto.tasas[i].contribucion.descripcion != null) { _pedimentoTasa.TasasClaveContribucionDesc = pedimentoCompleto.tasas[i].contribucion.descripcion; }
                                else { _pedimentoTasa.TasasClaveContribucionDesc = ""; }

                                _pedimentoTasa.TasasTipoTasaClave = pedimentoCompleto.tasas[i].tipoTasa.clave;
                                if(pedimentoCompleto.tasas[i].tipoTasa.descripcion != null) { _pedimentoTasa.TasasTipoTasaDesc = pedimentoCompleto.tasas[i].tipoTasa.descripcion; }
                                else { _pedimentoTasa.TasasTipoTasaDesc = ""; }

                                _pedimentoTasa.TasasTasaAplicable = pedimentoCompleto.tasas[i].tasaAplicable;
                                _pedimentoTasa.TasasFormaPagoClave = pedimentoCompleto.tasas[i].formaPago.clave;
                                if(pedimentoCompleto.tasas[i].formaPago.descripcion != null) { _pedimentoTasa.TasasFormaPagoDesc = pedimentoCompleto.tasas[i].formaPago.descripcion; }
                                else { _pedimentoTasa.TasasFormaPagoDesc = ""; }

                                _pedimentoTasa.TasasImporte = pedimentoCompleto.tasas[i].importe;
                                _pedimentoEntity.TasasPedimento.Add(_pedimentoTasa);
                            }
                        }
                        
                        //Identificadores
                        if(pedimentoCompleto.identificadores != null)
                        {
                            for (int i = 0; i < pedimentoCompleto.identificadores.Length; i++)
                            {
                                _pedIdentificador = new PedimentoIdentificador();
                                if(pedimentoCompleto.identificadores[i].claveIdentificador.clave != null) { _pedIdentificador.ClaveIdentificadorClave = pedimentoCompleto.identificadores[i].claveIdentificador.clave; }
                                else { _pedIdentificador.ClaveIdentificadorClave = ""; }
                                if (pedimentoCompleto.identificadores[i].claveIdentificador.descripcion != null) { _pedIdentificador.ClaveIdentificadorDesc = pedimentoCompleto.identificadores[i].claveIdentificador.descripcion; }
                                else { _pedIdentificador.ClaveIdentificadorDesc = ""; }
                                if (pedimentoCompleto.identificadores[i].complemento1 != null) { _pedIdentificador.IdentificadorComplemento1 = pedimentoCompleto.identificadores[i].complemento1; }
                                else { _pedIdentificador.IdentificadorComplemento1 = ""; }
                                if (pedimentoCompleto.identificadores[i].complemento2 != null) { _pedIdentificador.IdentificadorComplemento2 = pedimentoCompleto.identificadores[i].complemento2; }
                                else { _pedIdentificador.IdentificadorComplemento2 = ""; }
                                if (pedimentoCompleto.identificadores[i].complemento3 != null) { _pedIdentificador.IdentificadorComplemento3 = pedimentoCompleto.identificadores[i].complemento3; }
                                else { _pedIdentificador.IdentificadorComplemento3 = ""; }

                                _pedimentoEntity.IdentificadoresPedimento.Add(_pedIdentificador);
                            }
                        }
                       //Diferencia Contribucion
                       if(pedimentoCompleto.diferenciasContribuciones != null)
                        {
                            for(int i=0; i<pedimentoCompleto.diferenciasContribuciones.Length; i++)
                            {
                                _pedDifContribucion = new PedimentoDiferenciaContribucion();

                               _pedDifContribucion.ImportePago = pedimentoCompleto.diferenciasContribuciones[i].importePago;

                              _pedDifContribucion.ClaveGravamen1Clave = pedimentoCompleto.diferenciasContribuciones[i].claveGravamen.clave;
                              if(pedimentoCompleto.diferenciasContribuciones[i].claveGravamen.descripcion != null) { _pedDifContribucion.ClaveGravamen1Desc = pedimentoCompleto.diferenciasContribuciones[i].claveGravamen.descripcion; }
                              else { _pedDifContribucion.ClaveGravamen1Desc = ""; }
                                _pedDifContribucion.FormaPagoClave = pedimentoCompleto.diferenciasContribuciones[i].formaPago.clave;
                                if (pedimentoCompleto.diferenciasContribuciones[i].formaPago.descripcion != null) { _pedDifContribucion.FormaPagoDesc = pedimentoCompleto.diferenciasContribuciones[i].formaPago.descripcion; }
                                else { _pedDifContribucion.FormaPagoDesc = ""; }
                                _pedimentoEntity.PedimentoDiferenciaContribucion.Add(_pedDifContribucion);
                            }
                        }
                        _pedimentoEntity.FechaCreacion = DateTime.Now;
                        _pedimentoEntity.Intentos = intentos;
                        _pedRepo.AgregarPedimento(_pedimentoEntity);
                        intentos = 5;
                       // Console.WriteLine("Pedimento: {0}", pedimentoCompleto.pedimento);
                       //// Console.WriteLine("Aduana Entrada Salida: {0}", pedimentoCompleto.encabezado.aduanaEntradaSalida.descripcion);
                       // Console.WriteLine("Cantidad de Partidas: {0}: ", pedimentoCompleto.partidas.Length);
                       // Console.WriteLine("\n\nPartidas-------------------------------------------------");
                        

                        if ( pedimentoCompleto.partidas != null)
                        { 
                        for (int i = 1; i < pedimentoCompleto.partidas.Length + 1; i++)
                        {
                            _partida = new PartidaWS();
                            _partida.ConsultaPartida(respuesta.numeroOperacion, peticion.aduana, peticion.patente, pedimentoCompleto.pedimento, i, _pedimentoEntity.Id);
                        }
                        }
                        //Console.WriteLine("\n -------------------------------------------------------");


                    }

                }

                catch (Exception e)
                {
                    _stopWatch.Stop();
                    _pedimentoEntity.Intentos = intentos;
                    TimeSpan tiempo = _stopWatch.Elapsed;
                    Console.WriteLine(e.Message);
                    Console.WriteLine("No funciono Pedimento Completo");
                    Console.WriteLine("Intentos: {0}", intentos);
                    
                    if ( intentos >= 5)
                    {
                        Console.WriteLine("Insertando Error Pedimento");
                        Console.WriteLine("Tiempo: {0}", tiempo);
                        Console.WriteLine(respuesta.error[0]);
                        _pedimentoEntity.ErrorDesc = respuesta.error[0];
                        _pedimentoEntity.TieneError = true;
                        _pedimentoEntity.Tiempo = tiempo.ToString();
                        _pedimentoEntity.FechaCreacion = DateTime.Now;
                        _pedRepo.AgregarPedimento(_pedimentoEntity);
                        _listaRepo.ActualizarError(_pedimentoEntity.ListaPedimentoId, true, e.Message);

                     }

                }

               

            } while (intentos < 5);




        }
    }
    #endregion
}
