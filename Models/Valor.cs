using System;
using System.Collections.Generic;

namespace ApiFidelizacao1.Models
{
    public partial class Valor
    {
        public int NumeroCartao { get; set; }
        public decimal Valor1 { get; set; }

        public Cartao NumeroCartaoNavigation { get; set; }
    }
}
