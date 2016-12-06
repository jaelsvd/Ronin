using App.Entities;
using System.Collections.Generic;

namespace App.ViewModels
{
    public class PartidaViewModel
    {
        public PartidaViewModel()
        {
            Partida = new Partida();
            PartidaLista = new List<int>();
            Pedimento = new Pedimento();
        }
        public Partida Partida { get; set; }
        public List<int> PartidaLista { get; set; }

        public Pedimento Pedimento { get; set; }
    }
}