using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.MarzMember;
using App.MarzMember.Repositorios;

namespace App.MarzMember.Logica
{
    public class EmpresaBll
    {
       
        private Account _cuenta;
        private AccountRepository _accountRepo;
        List<Empresa> empresasCuenta = new List<Empresa>();


        public EmpresaBll()
        {

        }
        public string obtenerConecctionString(string userIdAd)
        {
            _accountRepo = new AccountRepository();
            _cuenta = new Account();
            _cuenta = _accountRepo.TraerPorIdAd(userIdAd);

       

            foreach (var empresa in _cuenta.AccountEmpresas)
            {
                empresasCuenta.Add(empresa.Empresa);

            }


            var e = empresasCuenta.FirstOrDefault();

            return actualEmp(e.Connection.Database);

        }


        public string actualEmp(string dbName)
        {

            var cnString = (dbName != "") ? "data source=marz.database.windows.net;initial catalog=" + dbName + ";persist security info=True;user id=KGcHG5vbWJte;password=\"khRh7#7QZ=m7\";MultipleActiveResultSets=True;App=EntityFramework" : "data source=marz.database.windows.net;initial catalog=Demo;persist security info=True;user id=KGcHG5vbWJte;password=\"khRh7#7QZ=m7\";MultipleActiveResultSets=True;App=EntityFramework";
            return cnString;
        }


    }
}
