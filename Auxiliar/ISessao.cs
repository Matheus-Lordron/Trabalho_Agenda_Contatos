using Trabalho_Agenda_Contatos.Models;

namespace Trabalho_Agenda_Contatos.Auxiliar
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuarioModel usuario);
        void RemoverSessaoUsuario();
        UsuarioModel BuscarSessaoUsuario();
    }
}
