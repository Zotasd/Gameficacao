using JMF.Model;
using JMF.UI.categoria;

namespace JMF.UI.produto
{
    public class ProdutoUI
    {

        private List<Produto> ListaDeProdutos;
        private List<Categoria> ListaDeCategorias;
        public ProdutoUI(List<Produto> produtos, List<Categoria> categorias)
        {
            ListaDeProdutos = produtos;
            ListaDeCategorias = categorias;
        }

        public void MenuProduto()
        {
            int opcao = 0;
            while (opcao == 0)
            {
                Console.Clear();
                Console.WriteLine("1 - Cadastrar Produto");
                Console.WriteLine("2 - Listar Produtos");
                Console.WriteLine("3 - Excluir Produto");
                Console.WriteLine("4 - Voltar");
                if (int.TryParse(Console.ReadLine(), out opcao) == false)
                {
                    Console.WriteLine("Opção inválida");
                    opcao = 0;
                }
                else
                {
                    switch (opcao)
                    {
                        case 1:
                            CadastrarProduto();
                            opcao = 0;
                            break;
                        case 2:
                            ListarProdutos();
                            opcao = 0;
                            break;
                        case 3:
                            ExcluirProduto();
                            opcao = 0;
                            break;
                        case 4:
                            opcao = 1;
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            break;
                    }
                }


            }
        }

        public void CadastrarProduto()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome do produto: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a descrição do produto: ");
            string descricao = Console.ReadLine();

            bool precoValido = false;
            decimal preco = 0;
            while (!precoValido)
            {
                Console.WriteLine("Digite o preço do produto, usar virgula se necessario: ");
                if (decimal.TryParse(Console.ReadLine(), out preco))
                {
                    precoValido = true;
                }
                else
                {
                    Console.WriteLine("Preço inválido");
                }
            }

            int i = 0;
            if (ListaDeProdutos.Count == 0)
            {
                i = 0;
            }
            else
            {
                i = ListaDeProdutos.Count;
            }

            Produto produto = new Produto(nome, descricao, preco, i);

            bool verificacao = false;
            while (verificacao == false)
            {
                Console.WriteLine("Gostaria de adicionar uma categoria ao produto? (Digite 1 para sim ou 2 para não)");
                if (int.TryParse(Console.ReadLine(), out int op) == false)
                {
                    Console.WriteLine("Opção inválida");
                    Continuar();
                    op = 0;
                }
                else
                {
                    switch (op)
                    {
                        case 1:
                            //adicionar categoria
                            Console.Clear();
                            Console.WriteLine("As categorias serão listadas abaixo:");
                            Console.WriteLine("");

                            foreach (Categoria categoria in ListaDeCategorias)
                            {
                                categoria.InfoCategoria();
                            }

                            CategoriaUI categoriaUI = new CategoriaUI(ListaDeCategorias, ListaDeProdutos);
                            bool verificacao2 = false;

                            while (verificacao2 == false)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Selecione:");
                                Console.WriteLine("1 - Adicionar uma nova categoria");
                                Console.WriteLine("2 - Adicionar ao produto uma categoria existente");

                                //verificar se o valor digitado é um inteiro
                                if (int.TryParse(Console.ReadLine(), out int op2) == false)
                                {
                                    //digitou um valor que não seja inteiro
                                    Console.WriteLine("Opção inválida");
                                    Continuar();
                                    op2 = 0;
                                }
                                else
                                {
                                    //digitou um valor que seja inteiro
                                    switch (op2)
                                    {
                                        case 1:
                                            //adicionar uma nova categoria e adiciona-la ao produto
                                            categoriaUI.CadastrarCategoria();

                                            int idCategoriaNova = ListaDeCategorias.Count - 1;

                                            foreach (Categoria categoria in ListaDeCategorias)
                                            {
                                                if (categoria.Id == idCategoriaNova)
                                                    produto.categoriaProduto = categoria;
                                            }

                                            Console.WriteLine("");
                                            Console.WriteLine("Categoria adicionada ao produto com sucesso!");

                                            verificacao2 = true;
                                            break;

                                        case 2:
                                            //adicionar uma categoria existente ao produto
                                            Console.WriteLine("");
                                            Console.WriteLine("Digite o ID da categoria que deseja adicionar ao produto: ");

                                            if (int.TryParse(Console.ReadLine(), out int idCategoria) == false)
                                            {
                                                //digitar um valor que não seja inteiro
                                                Console.WriteLine("Opção inválida");
                                                Continuar();
                                                idCategoria = 0;
                                            }
                                            else if (idCategoria > ListaDeCategorias.Count)
                                            {
                                                //digitar um valor que não esteja na lista
                                                Console.WriteLine("Categoria não encontrada");
                                                Console.WriteLine("A categoria padrão será adicionada ao produto");
                                                Continuar();
                                                idCategoria = 0;
                                            }
                                            else
                                            {
                                                //digitar um valor que esteja na lista
                                                foreach (Categoria categoria in ListaDeCategorias)
                                                {
                                                    if (categoria.Id == idCategoria)
                                                        produto.categoriaProduto = categoria;
                                                }
                                            }

                                            verificacao2 = true;
                                            break;

                                        default:
                                            Console.WriteLine("Opção inválida");
                                            Continuar();
                                            break;
                                    }
                                }
                            }

                            verificacao = true;
                            break;

                        case 2:
                            //não adicionar categoria
                            foreach (Categoria categoria in ListaDeCategorias)
                            {
                                if (categoria.Id == 0)
                                    produto.categoriaProduto = categoria;
                            }
                            verificacao = true;
                            break;

                        default:
                            Console.WriteLine("Opção inválida");
                            Continuar();
                            break;
                    }
                }

            }

            ListaDeProdutos.Add(produto);
        }

        public void ListarProdutos()
        {
            Console.Clear();
            if (ListaDeProdutos.Count == 0)
            {
                Console.WriteLine("Não há produtos cadastrados");
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Lista de Produtos");

            foreach (Produto produto in ListaDeProdutos)
            {
                produto.InfoProduto();
            }
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }

        public void ExcluirProduto()
        {
            Console.Clear();
            if (ListaDeProdutos.Count == 0)
            {
                Console.WriteLine("Não há produtos cadastrados");
                Continuar();
                return;
            }

            Console.WriteLine("Os produtos serão listados abaixo, digite o ID do produto que deseja excluir");
            Console.WriteLine("");
            ListarProdutos();

            Console.WriteLine("Digite o ID do produto que deseja excluir");
            if (int.TryParse(Console.ReadLine(), out int id) == false)
            {
                Console.WriteLine("ID inválido");
                Continuar();
                return;
            }
            else
            {
                foreach (Produto produto in ListaDeProdutos)
                {
                    if (produto.Id == id)
                    {
                        //excluir o produto
                        ListaDeProdutos.Remove(produto);
                        Console.WriteLine("Produto excluído com sucesso");

                        //atualizar os IDs dos produtos
                        int i = 0;
                        foreach (Produto produto2 in ListaDeProdutos)
                        {
                            produto2.Id = i;
                            i++;
                        }

                        Continuar();
                        return;
                    }
                    else if (id > ListaDeProdutos.Count)
                    {
                        Console.WriteLine("ID inválido");
                        Continuar();
                        return;
                    }
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