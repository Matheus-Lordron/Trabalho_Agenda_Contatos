using System.ComponentModel.DataAnnotations;

namespace Trabalho_Agenda_Contatos.Models
{
    public class ContatoModel : PessoaModel
    {
        [Required(ErrorMessage = "Informe o celular do contato")]
        [Phone(ErrorMessage = "O celular informado não é válido!")]
        public string Celular { get; set; }

        public int? UsuarioId { get; set; }

        public UsuarioModel? Usuario { get; set; }
    }
}

