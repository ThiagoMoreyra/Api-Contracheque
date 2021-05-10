using Stone.Api.Contracheque.Domain.Entities;
using Stone.Api.Contracheque.Domain.Shared.Interfaces;
using Stone.Api.Contracheque.Domain.Shared.Notify;
using System;

namespace Stone.Api.Contracheque.Domain.Services
{
    public class ExtratoService : IExtratoService
    {
        public IFuncionarioRepositorio _funcionarioRepositorio { get; set; }
        public INotificacao _notificador { get; set; }

        public ExtratoService(IFuncionarioRepositorio funcionarioRepositorio, INotificacao notificador)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
            _notificador = notificador;
        }

        public Extrato ObtemExtrato(Guid idFuncionario)
        {
            var funcionario = _funcionarioRepositorio.ObtemPorId(idFuncionario).Result;

            if (funcionario is null) throw new ArgumentNullException(MensagensDeErro.FuncionarioNaoEncontrado);

            var lancamento = new Lancamento();

            return new Extrato(DateTime.Today.Month, funcionario, lancamento.ObtemLancamentos(funcionario));
        }
    }
}
