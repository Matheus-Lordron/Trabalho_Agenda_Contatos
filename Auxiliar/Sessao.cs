using Newtonsoft.Json;
using Trabalho_Agenda_Contatos.Models;

namespace Trabalho_Agenda_Contatos.Auxiliar
{
    public class Sessao : ISessao
    {
         private readonly IHttpContextAccessor _httpContext;
        public Sessao (IHttpContextAccessor httpContextAcessor)
        {
            _httpContext = httpContextAcessor; 
        }

        public UsuarioModel BuscarSessaoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

            //dps quando buscar ele irá transformar de string para object//
        }

        public void CriarSessaoUsuario(UsuarioModel usuario)
        {
            //metodo para transformar objeto em string no padrao Json//
          
            string valor = JsonConvert.SerializeObject(usuario);

            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado",valor);
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
