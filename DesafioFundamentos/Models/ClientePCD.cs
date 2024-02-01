using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class ClientePCD : Cliente
    {
        public override decimal CalcularPrecoComDesconto(decimal precoBase)
        {
            // PCD tem 20% de desconto
            // Gestantes têm 20% de desconto
            Desconto = 0.2m;
            decimal precoComDesconto = precoBase * (1 - Desconto);

            return precoComDesconto;
        }
    }
}
