using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp_13_11_2023.Models;

namespace WebApp_13_11_2023.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<WebApp_13_11_2023.Models.InventarioMaquinas> InventarioMaquinas { get; set; } = default!;

        public DbSet<WebApp_13_11_2023.Models.CadProdutos> CadProdutos { get; set; } = default!;

        public DbSet<WebApp_13_11_2023.Models.CadClientes> CadClientes { get; set; } = default!;

        public DbSet<WebApp_13_11_2023.Models.InventarioSoftwares> InventarioSoftwares { get; set; } = default!;
    }
}
