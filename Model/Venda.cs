namespace JMF.Model
{
    public class Venda
    {
        public int Id { get; set; }
        public Cliente clienteVenda { get; set; }
        public DateOnly data { get; set; }
        public List<Produto> produtoVenda { get; set; }


        public Venda(Cliente cliente, List<Produto> produtosVendidos, DateOnly dataVenda)
        {
            clienteVenda = cliente;
            produtoVenda = produtosVendidos;
            data = dataVenda;
        }

        public void InfoVenda()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Id da Venda: " + Id);
            Console.WriteLine("Cliente: " + clienteVenda.Nome);
            Console.WriteLine("Data: " + data);
            Console.WriteLine("Valor Total: R$" + ValorTotal());
            Console.WriteLine("Produtos: ");
            Console.WriteLine("");
            foreach (var produto in produtoVenda)
            {
                produto.InfoProdutoVenda();
            }
            Console.WriteLine("");
        }

        public decimal ValorTotal()
        {
            decimal valorTotal = 0;
            foreach (var produto in produtoVenda)
            {
                valorTotal += produto.Preco * produto.Quantidade;
            }
            return valorTotal;
        }

    }
}