namespace LoginCriptografado.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; } = string.Empty;
        public string EmailUsuario { get; set; } = string.Empty;
        public string SenhaUsuario { get; set; } = string.Empty;
        public string NomeCompletoUsuario { get; set; } = string.Empty;
        public LoginUsuarioModel Login { get; set; } = new LoginUsuarioModel();


    }
}
