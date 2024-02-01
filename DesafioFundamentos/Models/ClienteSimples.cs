using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class ClienteSimples : Cliente
    {
        public override decimal CalcularPrecoComDesconto(decimal precoBase)
        {
            // Cliente simples não possui desconto
            return precoBase;
        }
    }
}
