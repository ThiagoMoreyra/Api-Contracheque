using Stone.Api.Contracheque.Domain.Entities;
using Stone.Api.Contracheque.Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Stone.Api.Contracheque.Domain.Shared.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        Task<Funcionario> ObtemPorId(Guid id);
        Task<bool> Salvar(Funcionario funcionario);
        Task<Funcionario> ObtemPorCpf(string cpf);
    }
}
