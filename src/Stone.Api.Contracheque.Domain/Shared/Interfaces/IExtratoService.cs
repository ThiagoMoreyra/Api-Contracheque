using Stone.Api.Contracheque.Domain.Entities;
using System;

namespace Stone.Api.Contracheque.Domain.Shared.Interfaces
{
    public interface IExtratoService
    {
        Extrato ObtemExtrato(Guid idFuncionario);
    }
}
