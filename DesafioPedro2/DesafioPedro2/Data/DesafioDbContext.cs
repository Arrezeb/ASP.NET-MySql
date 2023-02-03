using DesafioPedro2.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPedro2.Data
{
    public class DesafioDbContext : DbContext
    {
        public DesafioDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<PedidoItem> PedidoItens { get; set; }
    }
}
