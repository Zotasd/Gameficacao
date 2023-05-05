using JMF.Model;
using JMF.UI.categoria;
using JMF.UI.cliente;
using JMF.UI.produto;

namespace JMF.Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            List<Produto> listaProdutos = new List<Produto>();
            List<Cliente> listaClientes = new List<Cliente>();
            List<Venda> listaVendas = new List<Venda>();

            CategoriaUI categoriaUI = new CategoriaUI(listaCategorias, listaProdutos);
            ProdutoUI produtoUI = new ProdutoUI(listaProdutos, listaCategorias);
            VendaUI vendaUI = new VendaUI(listaVendas, listaClientes, listaProdutos);
            ClienteUI clienteUI = new ClienteUI(listaClientes);

            categoriaUI.AdicionarCategoriaPadrao();

            //menu
            int opcao = 0;
            while (opcao == 0)
            {
                Console.Clear();
                Console.WriteLine("1 - Opções de Clientes");
                Console.WriteLine("2 - Opções de Produtos");
                Console.WriteLine("3 - Opções de Categorias");
                Console.WriteLine("4 - Opções de Vendas	");
                Console.WriteLine("5 - Sair");

                if (int.TryParse(Console.ReadLine(), out opcao) == false)
                {
                    OpcaoInvalida();
                }
                else
                {
                    switch (opcao)
                    {
                        case 1:
                            clienteUI.MenuCliente();
                            opcao = 0;
                            break;
                        case 2:
                            produtoUI.MenuProduto();
                            opcao = 0;
                            break;
                        case 3:
                            categoriaUI.MenuCategoria();
                            opcao = 0;
                            break;
                        case 4:
                            vendaUI.MenuVenda();
                            opcao = 0;
                            break;
                        case 5:
                            opcao = 1;
                            break;
                        default:
                            OpcaoInvalida();
                            break;
                    }
                }


            }

            void OpcaoInvalida()
            {
                Console.WriteLine("Opção inválida");
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
                opcao = 0;
            }
        }
    }
}