using System.ComponentModel.DataAnnotations;
using Trabalho_Agenda_Contatos.Auxiliar;
using Trabalho_Agenda_Contatos.Enums;

namespace Trabalho_Agenda_Contatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o login do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do usuario")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string Email { get; set;}

        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
    }
    
}
