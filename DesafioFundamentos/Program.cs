using ESTACIONAMENTO.models;

// UTF8
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" + "Digite o preço de entrada do estacionamento");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o valor que é cobrado por hora: ");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

//Inicia a classe estacionamento
Estacionamento estaciona = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

while(exibirMenu) {
     Console.Clear();
     Console.WriteLine("Digite a sua opção");
     Console.WriteLine("1 - Cadastra veículo");
     Console.WriteLine("2 - Remover veículo");
     Console.WriteLine("3 - Listar veículos");
     Console.WriteLine("4 - Encerrar");

     switch (Console.ReadLine()) {
          case "1":
               estaciona.AdicionarVeiculo();
               break;
          case "2":
               estaciona.RemoverVeiculo();
               break;
          case "3":
               estaciona.ListarVeiculo();
               break;
          case "4":
               exibirMenu = false;
               break;
          default :
               Console.WriteLine("Opção inválida");
               break;
     }

     Console.WriteLine("Pressione uma tecla para continuar");
     Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
