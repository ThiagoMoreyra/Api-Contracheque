using Microsoft.AspNetCore.Mvc;
using Stone.Api.Contracheque.App.Hypermedia;
using Stone.Api.Contracheque.Domain.Shared.Notify;
using System.Collections.Generic;
using System.Linq;

namespace Stone.Api.Contracheque.App.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificacao _notificacao;

        public MainController(INotificacao notificacao)
        {
            _notificacao = notificacao;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result,
                    links = GeraLinks(),
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificacao.Notificacoes.Select(n => n.Mensagem)
            });
        }

        protected bool ValidOperation() =>        
             _notificacao.Valido;        

        protected void NotificarErro(string mensagem) =>        
            _notificacao.AdicionaNotificacao(new Notificacao(mensagem));

        private List<MediaContent> GeraLinks()
        {
            return new List<MediaContent> {
                        new MediaContent
                        {
                            Link = FuncionarioLinks.POST, Metodo = "POST", Rel = "criar-funcionario",
                        },

                        new MediaContent
                        {
                            Link = FuncionarioLinks.GETBYID, Metodo = "GET", Rel = "obtem-funcionario",
                        },

                        new MediaContent
                        {
                            Link = ExtratoLinks.GETBYID, Metodo = "GET", Rel = "obtem-extrato",
                        },
                    };
        }
    }
}
