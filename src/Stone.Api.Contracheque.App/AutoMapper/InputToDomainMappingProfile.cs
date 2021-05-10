using Stone.Api.Contracheque.App.Inputs;
using Stone.Api.Contracheque.Domain.Entities;
using Stone.Api.Contracheque.Domain.ValueObjects;

namespace Stone.Api.Contracheque.App.AutoMapper
{
    public static class InputToDomainMappingProfile
    {
        public static Funcionario ConverteParaFuncionario(this FuncionarioInput input)
        {
            return new Funcionario(
                                   new NomeFuncionario(input.Nome, input.SobreNome),
                                   new Cpf(input.CPF),
                                   input.Setor,
                                   input.SalarioBruto,
                                   input.DataDeAdmissao,
                                   input.PossuiDescontoPlanoDeSaude,
                                   input.PossuiDescontoPlanoDental,
                                   input.PossuiDescontoValeTransporte);

        }
    }
}
