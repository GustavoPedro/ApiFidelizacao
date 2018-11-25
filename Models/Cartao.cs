using System;
using System.Collections.Generic;

namespace ApiFidelizacao1.Models
{
    public partial class Cartao
    {
        public int NumeroCartao { get; set; }
        public DateTime DataVencimento { get; set; }
        public int IdCliente { get; set; }
        public int IdFuncionario { get; set; }
        public int IdEmpresa { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public Empresa IdEmpresaNavigation { get; set; }
        public Funcionario IdFuncionarioNavigation { get; set; }
        public Historicopontos Historicopontos { get; set; }
        public Selo Selo { get; set; }
        public Valor Valor { get; set; }
    }
}
