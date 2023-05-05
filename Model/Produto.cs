namespace JMF.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public int Quantidade { get; set; }

        public Categoria categoriaProduto { get; set; }

        public Produto(string nome, string descricao, decimal preco, int id)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        public void InfoProduto()
        {
            Console.WriteLine("Id do Produto: " + Id);
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Descrição: " + Descricao);
            Console.WriteLine("Preço: R$" + Preco);
            Console.WriteLine("Categoria: " + categoriaProduto.Nome);
            Console.WriteLine("");
        }

                public void InfoProdutoVenda()
        {
            Console.WriteLine("Id do Produto: " + Id);
            Console.WriteLine("Quantidade:" + Quantidade);
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Descrição: " + Descricao);
            Console.WriteLine("Preço: R$" + Preco);
            Console.WriteLine("Categoria: " + categoriaProduto.Nome);
            Console.WriteLine("");
        }

    }
}
