using Microsoft.AspNetCore.Mvc;
using Stone.Api.Contracheque.App.Extensions;
using Stone.Api.Contracheque.App.Filter;
using Stone.Api.Contracheque.App.Inputs;
using Stone.Api.Contracheque.Domain.Shared.Interfaces;
using Stone.Api.Contracheque.Domain.Shared.Notify;
using System;
using System.Threading.Tasks;

namespace Stone.Api.Contracheque.App.Controllers
{
    [Route("api/v1/funcionarios")]
    [ApiController]
    public class FuncionarioController : MainController
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly INotificacao _notificacao;

        public FuncionarioController(INotificacao notificacao, IFuncionarioService funcionarioService) : base(notificacao)
        {
            _notificacao = notificacao;
            _funcionarioService = funcionarioService;
        }

        [ValidateModel]
        [HttpGet]
        public IActionResult Get([FromQuery] Guid id)
        {
            var funcionario = _funcionarioService.ObtemFuncionarioPorId(id).Result;
            if (funcionario is null) return NotFound();
            return CustomResponse(funcionario.ConverteParaFuncionarioOutput());
        }

        [ValidateModel]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FuncionarioInput input)
        {
            var funcionario = input.ConverteParaFuncionario();
            await _funcionarioService.SalvarFuncionario(funcionario);
            return CustomResponse(funcionario);
        }
    }
}
