using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioPedro2.Models
{
    public class PedidoItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Pedidos")]

        public int PedidoId { get; set; }
        [ForeignKey("Produtos")]

        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }


        public virtual Pedido Pedidos { get; set; }
        public virtual Produto Produtos { get; set; }
    }
}
