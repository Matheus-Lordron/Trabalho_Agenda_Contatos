using System.ComponentModel.DataAnnotations;
using Trabalho_Agenda_Contatos.Enums;

namespace Trabalho_Agenda_Contatos.Models
{
    public class UsuarioSemSenhaModel : PessoaModel
    {
        [Required(ErrorMessage = "Informe o login do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
    }
}
