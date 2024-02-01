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
            return precoBase;
        }
    }
}
