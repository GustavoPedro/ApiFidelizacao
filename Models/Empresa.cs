using System;
using System.Collections.Generic;

namespace ApiFidelizacao1.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Cartao = new HashSet<Cartao>();
            Funcionario = new HashSet<Funcionario>();
        }

        public int IdEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string TipoCartao { get; set; }

        public ICollection<Cartao> Cartao { get; set; }
        public ICollection<Funcionario> Funcionario { get; set; }
    }
}
