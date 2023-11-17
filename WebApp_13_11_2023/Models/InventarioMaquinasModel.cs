using System.ComponentModel.DataAnnotations;

namespace WebApp_13_11_2023.Models
{
    public class InventarioMaquinasModel : CadProdutos
    {
        [Key]

        public List<CadProdutos> ListaProdutos { get; set; }

        public List<CadClientes> ListaClientes { get; set; }
    }
}
