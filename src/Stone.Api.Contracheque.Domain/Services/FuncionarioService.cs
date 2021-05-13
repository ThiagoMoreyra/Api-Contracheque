using Stone.Api.Contracheque.Domain.Entities;
using Stone.Api.Contracheque.Domain.Shared.Interfaces;
using Stone.Api.Contracheque.Domain.Shared.Notify;
using System;
using System.Threading.Tasks;

namespace Stone.Api.Contracheque.Domain.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        public IFuncionarioRepositorio _funcionarioRepositorio { get; set; }
        public INotificacao _notificador { get; set; }
        public FuncionarioService(IFuncionarioRepositorio funcionarioRepositorio, INotificacao notificador)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
            _notificador = notificador;
        }

        public async Task<Funcionario> ObtemFuncionarioPorId(Guid id) =>
             await _funcionarioRepositorio.ObtemPorId(id);

        public async Task SalvarFuncionario(Funcionario funcionario)
        {
            if (FuncionarioEhValido(funcionario) is false) return;

            if (FuncionarioJaExiste(funcionario).Result is true) return;          

            await _funcionarioRepositorio.Salvar(funcionario);
        }

        private bool FuncionarioEhValido(Funcionario funcionario)
        {
            if (funcionario.EhValido() is false)
            {
                _notificador.AdicionaNotificacao(MensagensDeErro.DadosInvalidos);
                return false;
            }

            return true;
        }

        private async Task<bool> FuncionarioJaExiste(Funcionario funcionario)
        {
            var funcionarioExistente = await _funcionarioRepositorio.ObtemPorCpf(funcionario.CPF.Documento);
            if (funcionarioExistente != null)
            {
                _notificador.AdicionaNotificacao(MensagensDeErro.FuncionarioJaExisteBaBase);
                return true;
            }

            return false;
        }
    }
}
