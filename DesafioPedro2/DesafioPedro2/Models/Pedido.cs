using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioPedro2.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Usuarios")]

        public int UsuarioId { get; set; }

        public DateTime DataPedido { get; set; }


        public virtual Usuario Usuarios { get; set; }
    }
}
