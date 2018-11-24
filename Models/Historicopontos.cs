using System;
using System.Collections.Generic;

namespace ApiFidelizacao1.Models
{
    public  class Historicopontos
    {
        public int CartaoNumeroCartao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string TipoCartao { get; set; }

        public Cartao CartaoNumeroCartaoNavigation { get; set; }
    }
}
