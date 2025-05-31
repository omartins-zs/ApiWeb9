namespace ApiWeb9.Models
{
    public class ProdutoModel
    {
        public int Id { get; set;  }
        public string Nome { get; set; } = string.Empty;

        public int Preco { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public int QuantidadeEstoque { get; set; }

        public string CodigoDeBarras { get; set; } = string.Empty;

        public string Marca { get; set; } = string.Empty;
    }
}
