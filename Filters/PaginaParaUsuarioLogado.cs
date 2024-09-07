using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Trabalho_Agenda_Contatos.Models;

namespace Trabalho_Agenda_Contatos.Filters
{
    public class PaginaParaUsuarioLogado : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

                if (usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuted(context);
        }
    }
}

// Classe PaginaParaUsuarioLogado que herda de ActionFilterAttribute para verificar se o usuário está logado antes de executar uma ação.
// O método OnActionExecuted é chamado após a execução da ação.
// Verifica se há uma sessão ativa para o usuário logado, usando a chave "sessaoUsuarioLogado".
// Se a sessão não existir ou estiver vazia, redireciona o usuário para a página de login.
// Caso exista, desserializa a sessão para um objeto UsuarioModel e, se o objeto for nulo, também redireciona para a página de login.
// Se tudo estiver correto, permite a execução normal da ação.

