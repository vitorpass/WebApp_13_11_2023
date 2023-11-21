using System.ComponentModel.DataAnnotations;

namespace WebApp_13_11_2023.Models
{
    public class InventarioSoftwares
    {
        [Key]

        public int id_software { get; set; }

        public int id_cliente { get; set; }

        public int id_produto { get; set; }

        public string nome_software { get; set; }

        public string versao_software { get; set; }

        public string fabricante_software { get; set; }

        public string licenca_software { get; set; }

        public DateTime data_aquisicao_software { get; set; }

        public decimal custo_aquisicao_software { get; set; }

        public string status_software { get; set; }

        public string descricao_software { get; set; }
    }
}
