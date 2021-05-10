using Microsoft.AspNetCore.Mvc;
using Stone.Api.Contracheque.App.Extensions;
using Stone.Api.Contracheque.App.Filter;
using Stone.Api.Contracheque.Domain.Shared.Interfaces;
using Stone.Api.Contracheque.Domain.Shared.Notify;
using System;

namespace Stone.Api.Contracheque.App.Controllers
{
    [Route("api/v1/extratos")]
    [ApiController]
    public class ExtratoController : MainController
    {
        private readonly IExtratoService _extratoService;
        private readonly INotificacao _notificacao;

        public ExtratoController(INotificacao notificacao, IExtratoService extratoService) : base(notificacao)
        {
            _extratoService = extratoService;
            _notificacao = notificacao;
        }

        [ValidateModel]
        [HttpGet]
        public IActionResult Get([FromQuery] Guid id)
        {
            var extrato = _extratoService.ObtemExtrato(id);
            if (extrato is null) return BadRequest();
            return CustomResponse(extrato.ConverteParaExtratoOutput());
        }
    }
}
