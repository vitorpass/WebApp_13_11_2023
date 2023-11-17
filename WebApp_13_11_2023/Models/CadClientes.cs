using System.ComponentModel.DataAnnotations;

namespace WebApp_13_11_2023.Models
{
    public class CadClientes
    {
        [Key]

        public int id_cliente { get; set; }

        public string nome_cliente { get; set; }

        public string email_cliente { get; set; }

        public string telefone_cliente { get; set; }

        public string endereco_cliente { get; set; }

        public string cidade_cliente { get; set; }

        public string estado_cliente { get; set; }

        public string cep_cliente { get; set; }

        public string data_cadastro { get; set; }
    }
}
