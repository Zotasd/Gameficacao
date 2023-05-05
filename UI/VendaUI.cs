using JMF.Model;

namespace JMF.UI.cliente
{
    public class VendaUI
    {

        List<Venda> ListaDeVendas;
        List<Cliente> ListaDeClientes;
        List<Produto> ListaDeProdutos;
        public VendaUI(List<Venda> vendas, List<Cliente> clientes, List<Produto> produtos)
        {
            ListaDeClientes = clientes;
            ListaDeProdutos = produtos;
            ListaDeVendas = vendas;
        }

        public void MenuVenda()
        {
            int opcao = 0;

            while (opcao == 0)
            {
                Console.Clear();
                Console.WriteLine("1 - Realizar Venda");
                Console.WriteLine("2 - Listar Vendas");
                Console.WriteLine("3 - Voltar");
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
                            Vender();
                            opcao = 0;
                            break;
                        case 2:
                            ListarVendas();
                            opcao = 0;
                            break;
                        case 3:
                            ;
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

        public void Vender()
        {
            if (ListaDeProdutos.Count == 0)
            {
                Console.WriteLine("Não há produtos cadastrados");
                Continuar();
                return;
            }

            int _idCliente = 0;
            int _idProduto = 0;
            int _quantidade = 0;
            List<Produto> produtosVendidos = new List<Produto>();

            Console.Clear();

            // caso nao haja clientes cadastrados, cadastrar cliente
            if (ListaDeClientes.Count == 0)
            {
                Console.WriteLine("Não há clientes cadastrados, a seguir, cadastre um cliente para continuar");
                Continuar();
                ClienteUI clienteUI = new ClienteUI(ListaDeClientes);
                clienteUI.CadastrarCliente();
            }

            Console.Clear();
            Console.WriteLine("O cliente já está cadastrado? 1 - Sim   2 - Não");

            bool clienteCadastrado = false;
            while (!clienteCadastrado)
            {
                if (int.TryParse(Console.ReadLine(), out int opcao) == false)
                {
                    //opcao invalida
                    Console.WriteLine("Opção inválida");
                    Continuar();
                }
                else
                {
                    //opcao valida
                    switch (opcao)
                    {
                        case 1:
                            //cliente possui cadastro, selecionar cliente
                            clienteCadastrado = true;


                            bool clienteSelecionado = false;
                            while (!clienteSelecionado)
                            {
                                Console.Clear();
                                Console.WriteLine("A lista de clientes é:");

                                foreach (var cliente in ListaDeClientes)
                                {
                                    cliente.InfoCliente();
                                }
                                Console.WriteLine("Digite o ID do cliente:");
                                if (int.TryParse(Console.ReadLine(), out int idClienteSelec) == false)
                                {
                                    //id invalido
                                    Console.WriteLine("ID inválido");
                                    Continuar();
                                }
                                else
                                {
                                    if (idClienteSelec < 0 || idClienteSelec >= ListaDeClientes.Count)
                                    {
                                        Console.WriteLine("ID não existe, tente novamente");
                                        Continuar();
                                    }
                                    //id valido
                                    foreach (var cliente in ListaDeClientes)
                                    {
                                        if (cliente.Id == idClienteSelec)
                                        {
                                            //cliente selecionado
                                            clienteSelecionado = true;
                                            _idCliente = cliente.Id;
                                            Console.WriteLine("Cliente selecionado: " + cliente.Nome);
                                            Continuar();
                                        }
                                        break;
                                    }
                                }
                            }
                            break;

                        case 2:
                            //cliente nao possui cadastro, cadastrar cliente
                            ClienteUI clienteUI = new ClienteUI(ListaDeClientes);
                            clienteUI.CadastrarCliente();
                            clienteCadastrado = true;
                            break;

                        default:
                            //opcao invalida
                            Console.WriteLine("Opção inválida");
                            Continuar();
                            break;
                    }
                }
            }

            ///////////////////////////////////////////////////////
            //selecionar produtos
            bool compraConcluida = false;
            while (!compraConcluida)
            {
                Console.Clear();
                Console.WriteLine("A lista de produtos é:");

                //listar produtos
                foreach (var produto in ListaDeProdutos)
                {
                    produto.InfoProduto();
                }

                bool produtoSelecionado = false;
                while (!produtoSelecionado)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Digite o ID do produto que deseja comprar:");

                    if (int.TryParse(Console.ReadLine(), out int idProdutoSelec) == false)
                    {
                        //id produto invalido
                        Console.WriteLine("ID inválido, tente novamente");
                        Continuar();
                    }
                    else
                    {
                        //id produto é valido
                        if (idProdutoSelec >= ListaDeProdutos.Count || idProdutoSelec < 0)
                        {
                            //id produto nao existe
                            Console.WriteLine("ID não existe, tente novamente");
                            Continuar();
                        }
                        else
                        {
                            //id produto existe
                            foreach (var produto in ListaDeProdutos)
                            {
                                if (produto.Id == idProdutoSelec)
                                {
                                    //produto selecionado
                                    _idProduto = produto.Id;
                                    Console.WriteLine("Produto selecionado:" + produto.Nome);
                                    Continuar();
                                    produtoSelecionado = true;
                                    break;
                                }

                            }
                        }

                    }
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////
                //quantidade de produtos
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Digite a quantidade que deseja comprar:");
                bool quantidadeSelecionada = false;
                while (!quantidadeSelecionada)
                {
                    if (int.TryParse(Console.ReadLine(), out int quant) == false)
                    {
                        Console.WriteLine("ID inválido");
                        Continuar();
                    }
                    else if (quant > 0)
                    {
                        _quantidade = quant;
                        quantidadeSelecionada = true;
                    }
                    else
                    {
                        Console.WriteLine("Quantidade inválida, tente novamente");
                        Continuar();
                    }
                }

                ////////////////////////////////////////////
                //adicionar mais produtos
                Console.Clear();
                Console.WriteLine("Deseja adicionar mais produtos? 1 - Sim   2 - Não");
                bool adicionarMaisProdutos = false;
                while (!adicionarMaisProdutos)
                {
                    if (int.TryParse(Console.ReadLine(), out int opcao) == false)
                    {
                        //opcao invalida
                        Console.WriteLine("Opção inválida, tente novamente");
                        Continuar();
                    }
                    else
                    {
                        //opcao valida
                        switch (opcao)
                        {
                            case 1:
                                //adicionar mais produtos
                                foreach (var produto in ListaDeProdutos)
                                {
                                    if (produto.Id == _idProduto)
                                    {
                                        produto.Quantidade = _quantidade;
                                        produto.Id = _idProduto;
                                        produtosVendidos.Add(produto);
                                    }
                                }
                                adicionarMaisProdutos = true;
                                break;

                            case 2:
                                //finalizar compra
                                foreach (var produto in ListaDeProdutos)
                                {
                                    if (produto.Id == _idProduto)
                                    {
                                        produto.Quantidade = _quantidade;
                                        produto.Id = _idProduto;
                                        produtosVendidos.Add(produto);
                                    }
                                }
                                adicionarMaisProdutos = true;
                                compraConcluida = true;
                                break;

                            default:
                                //opcao invalida
                                Console.WriteLine("Opção inválida, tente novamente");
                                Continuar();
                                break;
                        }
                    }
                }
            }


            Console.WriteLine("Qual a data da venda?");
            Console.WriteLine("Utilize o formato dd/mm/aaaa");
            bool dataValida = false;
            while (!dataValida)
            {
                if (DateOnly.TryParse(Console.ReadLine(), out DateOnly dataVenda) == false)
                {
                    Console.WriteLine("Data inválida, tente novamente");
                    Continuar();
                }
                else
                {
                    Venda venda = new Venda(GetCliente(_idCliente), produtosVendidos, dataVenda);
                    dataValida = true;
                    ListaDeVendas.Add(venda);
                    Console.WriteLine("Venda realizada com sucesso");
                    Continuar();
                }
            }

        }

        Cliente GetCliente(int id)
        {
            foreach (var cliente in ListaDeClientes)
            {
                if (cliente.Id == id)
                {
                    return cliente;
                }
            }
            return null;
        }

        public void ListarVendas()
        {
            Console.Clear();

            if (ListaDeVendas.Count == 0)
            {
                Console.WriteLine("Nenhuma venda realizada");
                Continuar();
                return;
            }

            Console.Clear();
            Console.WriteLine("Lista de Vendas");
            foreach (var venda in ListaDeVendas)
            {
                venda.InfoVenda();
            }
            Continuar();
        }

        void Continuar()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }
    }
}