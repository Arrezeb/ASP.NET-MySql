using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesafioPedro2.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Categorias")]

        public int CategoriaId { get; set; }

        public string? Nome { get; set; }

        public string? Url { get; set; }

        public int Quantidade { get; set; }

        public bool Ativo { get; set; }

        public bool Excluido { get; set; }


        public virtual Categoria Categorias { get; set; }
    }
}
