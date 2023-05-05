namespace JMF.Model
{
    public class Cliente
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        private int idNumber = 0;

        public Cliente(string nome, string sobrenome, string endereco, string telefone)//construtor
        {
            Id = idNumber;
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
            Telefone = telefone;
            idNumber++;
        }

        public void InfoCliente()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Id do Cliente: " + Id);
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Sobrenome: " + Sobrenome);
            Console.WriteLine("Endereço: " + Endereco);
            Console.WriteLine("Telefone: " + Telefone);
            Console.WriteLine("");
        }
    }
}