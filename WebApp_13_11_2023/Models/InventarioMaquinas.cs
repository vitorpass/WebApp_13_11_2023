using System.ComponentModel.DataAnnotations;

namespace WebApp_13_11_2023.Models
{
    public class InventarioMaquinas
    {
        [Key]

        public int id_produto { get; set; }

        public int id_cliente { get; set; }

        public string nome_maquina { get; set; }

        public string tipo_maquina { get; set; }

        public string fabricante_maquina { get; set; }

        public string modelo_maquina { get; set; }

        public string data_aquisicao_maquina { get; set; }

        public string custo_aquisicao_maquina { get; set; }

        public string status_maquina { get; set; }

        public string descricao_maquina { get; set; }
    }
}
