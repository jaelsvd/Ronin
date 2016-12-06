using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DAL;
using App.MarzMember;
using App.MarzMember.Repositorios;
using System.Security.Claims;
using App.Common;

namespace App.BLL
{
    public class BaseBusiness
    {
        private Conexion _conexion;
        private Account _cuenta;
        private AccountRepository _accountRepo;
        private Usuario _usuario;
        List<Empresa> empresasCuenta = new List<Empresa>();
        
        public BaseBusiness()
        {
            _conexion = new Conexion();
            _usuario = new Usuario();
        }
        public string obtenerEmpresa()
        {
            string userIdAd = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
            _accountRepo = new AccountRepository();
            _cuenta = new Account();
            _cuenta = _accountRepo.TraerPorIdAd(userIdAd);

            foreach (var empresa in _cuenta.AccountEmpresas)
            {
                empresasCuenta.Add(empresa.Empresa);
            }

            var e = empresasCuenta.FirstOrDefault();
            _usuario.darEmpresa(e);
            _usuario.darCuenta(_cuenta);    
            _conexion.darNombre(actualEmp(e.Connection.Database));
            return actualEmp((e.Connection.Database));

        }


        public string actualEmp(string dbName)
        {
            var cnString = (dbName != "") ? "data source=marz.database.windows.net;initial catalog=" + dbName + ";persist security info=True;user id=KGcHG5vbWJte;password=\"khRh7#7QZ=m7\";MultipleActiveResultSets=True;App=EntityFramework" : "data source=marz.database.windows.net;initial catalog=Demo;persist security info=True;user id=KGcHG5vbWJte;password=\"khRh7#7QZ=m7\";MultipleActiveResultSets=True;App=EntityFramework";
            return cnString;
        }

     

    }
}
