using Stone.Api.Contracheque.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Stone.Api.Contracheque.Domain.Shared.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        Task<Funcionario> ObtemPorId(Guid id);
        Task<bool> Salvar(Funcionario funcionario);
    }
}
