using System;
using System.Collections.Generic;

namespace ApiFidelizacao1.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cartao = new HashSet<Cartao>();
        }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }

        public ICollection<Cartao> Cartao { get; set; }
    }
}
