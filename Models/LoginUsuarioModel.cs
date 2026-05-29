namespace LoginCriptografado.Models
{
    public class LoginUsuarioModel
    {
        public int Id { get; set; }
        public string? SenhaUsuarioLogin { get; set; }
        public string? EmailUsuarioLogin { get; set; }
        public UsuarioModel? Usuario { get; set; }
    }
}
