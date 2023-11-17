using System.ComponentModel.DataAnnotations;

namespace WebApp_13_11_2023.Models
{
    public class CadProdutos
    {
        [Key]

        public int id_produto { get; set; }

        public string nome_produto { get; set; }

        public string descricao_produto { get; set; }

        public string preco_produto { get; set; }
    }
}
