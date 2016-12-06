using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL
{
    public class Archivo
    {
        public Archivo(byte[] array)
        {
            this.Valor = array;
        }

        public Archivo()
        { }

        public byte[] Valor { get; set; }

        public string Nombre { get; set; }

    }
}
