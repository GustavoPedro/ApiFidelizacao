using System;
using System.Collections.Generic;

namespace ApiFidelizacao1.Models
{
    public  class Selo
    {
        public int NumeroCartao { get; set; }
        public int Frequencia { get; set; }

        public Cartao NumeroCartaoNavigation { get; set; }
    }
}
