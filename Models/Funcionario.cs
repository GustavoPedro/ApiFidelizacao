using System;
using System.Collections.Generic;

namespace ApiFidelizacao1.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Cartao = new HashSet<Cartao>();
        }

        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public int EmpresaIdEmpresa { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Empresa EmpresaIdEmpresaNavigation { get; set; }
        public ICollection<Cartao> Cartao { get; set; }
    }
}
