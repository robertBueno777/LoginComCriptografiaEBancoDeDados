namespace LoginCriptografado.Models
{
    public class LoginUsuarioModel
    {
        public int Id { get; set; }
        public string SenhaUsuarioLogin { get; set; } = string.Empty;
        public string EmailUsuarioLogin { get; set; } = string.Empty;
    }
}
