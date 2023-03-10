namespace DesafioPedro2.ModelDTO
{
    public class UsuarioDTO
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Login { get; set; }

        public string? Senha { get; set; }

        public string? ChaveVerificacao { get; set; }

        public string? LastToken { get; set; }

        public bool IsVerificado { get; set; }

        public bool Ativo { get; set; }

        public bool Excluido { get; set; }
    }
}
