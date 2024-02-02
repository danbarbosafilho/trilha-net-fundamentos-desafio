namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        private Dictionary<string, Cliente> clientes = new Dictionary<string, Cliente>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite o nome do cliente:");
            string nomeCliente = Console.ReadLine().ToUpper();

            Console.WriteLine("Digite a placa do veículo:");
            string placaVeiculo = Console.ReadLine().ToUpper();

            Console.WriteLine("Digite o tipo de cliente (Simples, Gestante, PCD, Idoso):");
            string tipoClienteInput = Console.ReadLine();

            string tipoCliente = tipoClienteInput.ToUpper();

            Cliente cliente;

            switch (tipoCliente)
            {
                case "SIMPLES":
                    cliente = new ClienteSimples();
                    cliente.TipoCliente = "Simples";
                    break;
                case "GESTANTE":
                    cliente = new ClienteGestante();
                    cliente.TipoCliente = "Gestante";
                    break;
                case "PCD":
                    cliente = new ClientePCD();
                    cliente.TipoCliente = "PCD";
                    break;
                case "IDOSO":
                    cliente = new ClienteIdoso();
                    cliente.TipoCliente = "Idoso";
                    break;
                default:
                    Console.WriteLine("Tipo de cliente inválido. Utilizando cliente simples.");
                    cliente = new ClienteSimples(); // Se o tipo for inválido, atribui o cliente simples por padrão
                    cliente.TipoCliente = "Simples";
                    break;
            }
            
            cliente.Nome = nomeCliente;
            cliente.PlacaVeiculo = placaVeiculo;
            clientes.Add(placaVeiculo, cliente);
            veiculos.Add(placaVeiculo);

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine(
                    "Digite a quantidade de horas que o veículo permaneceu estacionado:"
                );
                int horas = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(
                    $"Além da hora informada ({horas}h), digite a quantidade de minutos restantes (canho haja):"
                );
                int minutos = Convert.ToInt32(Console.ReadLine());

                decimal precoBase =
                    precoInicial + (precoPorHora * horas) + (precoPorHora / 60 * minutos);

                Cliente cliente = clientes[placa];

                decimal precoComDesconto = cliente.CalcularPrecoComDesconto(precoBase);

                veiculos.Remove(placa);
                clientes.Remove(placa);

                Console.WriteLine(
                    $"O veículo {placa} foi removido e o preço total foi de: R$ {precoComDesconto:F2}. Tipo de cliente: {cliente.TipoCliente}. Desconto: {cliente.Desconto:P0}\n"
                );
            }
            else
            {
                Console.WriteLine(
                    "Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente"
                );
            }
        }

        public void ListarVeiculos()
        {
            if (clientes.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var cliente in clientes.Values)
                {
                    Console.WriteLine(
                        $"Cliente: {cliente.Nome}, Tipo: {cliente.TipoCliente}, Veículo: {cliente.PlacaVeiculo}"
                    );
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
