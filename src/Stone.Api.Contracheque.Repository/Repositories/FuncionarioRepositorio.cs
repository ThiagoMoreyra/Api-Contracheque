using Microsoft.EntityFrameworkCore;
using Stone.Api.Contracheque.Domain.Entities;
using Stone.Api.Contracheque.Domain.Shared.Interfaces;
using Stone.Api.Contracheque.Repository.Context;
using System;
using System.Threading.Tasks;

namespace Stone.Api.Contracheque.Repository.Repositories
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly FuncionarioContext _context;

        public FuncionarioRepositorio(FuncionarioContext context)
        {
            _context = context;
        }

        public async Task<Funcionario> ObtemPorCpf(string cpf)
        {
            return await _context.Funcionarios.AsNoTracking().FirstOrDefaultAsync(p => p.CPF.Documento == cpf);
        }

        public async Task<Funcionario> ObtemPorId(Guid id)
        {
            return await _context.Funcionarios.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> Salvar(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
