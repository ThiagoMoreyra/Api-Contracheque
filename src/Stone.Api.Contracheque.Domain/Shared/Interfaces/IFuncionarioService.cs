using Stone.Api.Contracheque.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Stone.Api.Contracheque.Domain.Shared.Interfaces
{
    public interface IFuncionarioService
    {
        Task<Funcionario> ObtemFuncionarioPorId(Guid id);
        void SalvarFuncionario(Funcionario funcionario);
    }
}
