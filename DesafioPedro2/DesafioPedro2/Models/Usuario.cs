using System.ComponentModel.DataAnnotations;

namespace DesafioPedro2.Models
{
    public class Usuario
    {  
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]

        public string? Nome { get; set; }
        [Required]
        [StringLength(256)]

        public string? Login { get; set; }
        [Required]
        [StringLength(256)]

        public string? Email { get; set; }
        [Required]
        [StringLength(256)]

        public string? Senha { get; set; }

        public Guid ChaveVerificacao { get; set; }

        public string? LastToken { get; set; }

        public bool IsVerificado { get; set; }

        public bool Ativo { get; set; }

        public bool Excluido { get; set; }
    }
}

