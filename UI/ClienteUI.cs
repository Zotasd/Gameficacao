using JMF.Model;

namespace JMF.UI.cliente
{
    public class ClienteUI
    {

        List<Cliente> ListaDeClientes;
        public ClienteUI(List<Cliente> clientes)
        {
            ListaDeClientes = clientes;
        }

        public void MenuCliente()
        {
            int opcao = 0;

            while (opcao == 0)
            {
                Console.Clear();
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Listar Clientes");
                Console.WriteLine("3 - Excluir Cliente");
                Console.WriteLine("4 - Voltar");
                if (int.TryParse(Console.ReadLine(), out opcao) == false)
                {
                    Console.WriteLine("Opção inválida");
                    Continuar();
                    opcao = 0;
                }
                else
                {
                    switch (opcao)
                    {
                        case 1:
                            CadastrarCliente();
                            opcao = 0;
                            break;
                        case 2:
                            ListarClientes();
                            Continuar();
                            opcao = 0;
                            break;
                        case 3:
                            ExcluirCliente();
                            opcao = 0;
                            break;
                        case 4:
                            opcao = 1;
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            Continuar();
                            opcao = 0;
                            break;
                    }
                }

            }
        }

        public void CadastrarCliente()
        {
            Console.Clear();
            Console.WriteLine("Digite apenas o nome do cliente");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite apenas o sobrenome do cliente");
            string sobrenome = Console.ReadLine();
            Console.WriteLine("Digite o endereço do cliente");
            string endereco = Console.ReadLine();
            Console.WriteLine("Digite o telefone do cliente");
            string telefone = Console.ReadLine();

            Cliente cliente = new Cliente(nome, sobrenome, endereco, telefone);
            cliente.Id = ListaDeClientes.Count;// arrumei do set antigo
            ListaDeClientes.Add(cliente);

            Console.WriteLine("Cliente cadastrado com sucesso");
            Continuar();
        }

        public void ListarClientes()
        {
            Console.Clear();

            if (ListaDeClientes.Count == 0)
            {
                Console.WriteLine("Não há clientes cadastrados");
                return;
            }
            else
            {
                foreach (Cliente cliente in ListaDeClientes)
                {
                    cliente.InfoCliente();
                }
            }


        }

        public void ExcluirCliente()
        {
            Console.Clear();

            if (ListaDeClientes.Count == 0)
            {
                Console.WriteLine("Não há clientes cadastrados");
                Continuar();
                return;
            }

            Console.WriteLine("Os clientes cadastrados serão listados abaixo:");
            ListarClientes();
            Console.WriteLine("");
            Console.WriteLine("Digite o Id do cliente que deseja excluir");
            if (int.TryParse(Console.ReadLine(), out int id) == false)
            {
                Console.WriteLine("Id inválido");
                Continuar();
            }
            else
            {
                bool clienteExiste = false;

                foreach (Cliente cliente in ListaDeClientes)
                {
                    if (cliente.Id == id)
                    {
                        //Excluir o cliente
                        ListaDeClientes.Remove(cliente);
                        Console.WriteLine("Cliente excluído com sucesso");

                        //Atualizar os IDs dos clientes
                        int i = 0;
                        foreach (Cliente cliente2 in ListaDeClientes)
                        {
                            cliente2.Id = i;
                            i++;
                        }

                        clienteExiste = true;
                        Continuar();
                        return;
                    }
                }

                if (clienteExiste == false)
                {
                    //Cliente não encontrado
                    Console.WriteLine("Cliente não encontrado");
                    Continuar();
                }
            }

        }

        void Continuar()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }
    }
}