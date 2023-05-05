using JMF.Model;

namespace JMF.UI.categoria
{
    public class CategoriaUI
    {
        private List<Categoria> listaDeCategorias;
        private List<Produto> listaDeProdutos;

        public CategoriaUI(List<Categoria> listaCategorias, List<Produto> listaProdutos)
        {
            listaDeCategorias = listaCategorias;
            listaDeProdutos = listaProdutos;
        }


        public void MenuCategoria()
        {

            int opcao = 0;

            while (opcao == 0)
            {
                Console.Clear();
                Console.WriteLine("1 - Cadastrar Categoria");
                Console.WriteLine("2 - Listar Categorias");
                Console.WriteLine("3 - Excluir Categoria");
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
                            CadastrarCategoria();
                            opcao = 0;
                            break;
                        case 2:
                            ListarCategorias();
                            opcao = 0;
                            break;
                        case 3:
                            ExcluirCategoria();
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

        public void CadastrarCategoria()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome da categoria: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a descrição da categoria: ");
            string descricao = Console.ReadLine();
            int i = 0;

            if (listaDeCategorias.Count == 0)
            {
                i = 0;   // loop aparentemente desnecessário já que a lista de categorias tendo o valor de i vai deixar i = 0
            }
            else
            {
                i = listaDeCategorias.Count;
            }

            Categoria categoria = new Categoria(nome, descricao, i);

            listaDeCategorias.Add(categoria);
            Console.WriteLine("Categoria cadastrada com sucesso");
            Continuar();
        }

        public void ListarCategorias()
        {
            if (listaDeCategorias.Count == 0)
            {
                Console.WriteLine("Não há categorias cadastradas");
                Continuar();
                return;
            }

            Console.Clear();
            Console.WriteLine("Lista de Categorias");
            foreach (var categoria in listaDeCategorias)
            {
                categoria.InfoCategoria();
            }
            Continuar();
        }

        public void AdicionarCategoriaPadrao()
        {
            //Adicionar a categoria padrao "Sem Categoria"
            string nome = "Sem Categoria Definida";
            string descricao = "Não há uma categoria específica ou o usuário não informou a categoria";
            int id = 0;
            Categoria semCategoria = new Categoria(nome, descricao, id);
            listaDeCategorias.Add(semCategoria);
        }

        public void ExcluirCategoria()
        {
            Console.Clear();
            Console.WriteLine("As categorias serão listadas abaixo: ");
            Console.WriteLine("Lista de Categorias");
            ListarCategorias();
            Console.WriteLine("Digite o ID da categoria que deseja excluir EXCETO a categoria 0: ");
            if (int.TryParse(Console.ReadLine(), out int id) == false)
            {
                Console.WriteLine("ID inválido");
                Continuar();
                return;
            }
            else
            {
                foreach (var categoria in listaDeCategorias)
                {
                    if (id == 0)
                    {
                        Console.WriteLine("Não é possível excluir a categoria 0");
                        Continuar();
                        return;
                    }

                    if (categoria.Id == id)
                    {
                        foreach (Produto produto in listaDeProdutos)
                        {
                            if (produto.CategoriaId == id)
                            {
                                Console.WriteLine("Não é possível excluir uma categoria que possui produtos");
                                Continuar();
                                return;
                            }
                        }

                        listaDeCategorias.Remove(categoria);
                        Console.WriteLine("Categoria excluída com sucesso");
                        Continuar();
                        break;
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