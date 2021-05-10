using Microsoft.AspNetCore.Mvc;
using Stone.Api.Contracheque.Domain.Shared.Notify;
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
                    data = result
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
    }
}
