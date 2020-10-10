using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaDeRegistro.Models
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
    }
}
