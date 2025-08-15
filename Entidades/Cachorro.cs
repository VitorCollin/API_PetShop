using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Entidades
{
    public class Cachorro
    {
        public int CachorroId { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public EnumPorte Porte { get; set; }
        public decimal ValorBanho { get; set; }
        public DateTime DataDoBanho { get; set; }
        
    }
}