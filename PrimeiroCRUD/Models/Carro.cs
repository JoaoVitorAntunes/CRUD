using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiroCRUD.Models
{
    public class Carro
    {
        public int CarroId { get; set; }

        public string Marca { get; set; }

        public string Nome { get; set; }

        public int Ano { get; set; }
    }
}
