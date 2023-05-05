namespace JMF.Model
{
    public class Categoria
    {
        public int Id { get; set; } // tornei os bgl aq q tava privado publico; da nada com o encapsulamento pq isso é propriedade
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Categoria(string nome, string descricao, int id)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }



        public void InfoCategoria()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Id da Categoria: " + Id);
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Descrição: " + Descricao);
            Console.WriteLine("");
        }


        public int GetID()
        {//porque existes get id?
            return Id;
        }
        public string GetNome()
        {
            return Nome;
        }
    }
}