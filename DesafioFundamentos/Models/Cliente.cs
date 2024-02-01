using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public abstract class Cliente
    {
        public string Nome { get; set; }
        public string PlacaVeiculo { get; set; }
        public string TipoCliente { get; set; }
        public decimal Desconto { get; set; }

        // Método abstrato para calcular o preço com desconto
        public abstract decimal CalcularPrecoComDesconto(decimal precoBase);
    }
}
