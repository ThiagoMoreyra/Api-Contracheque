using Stone.Api.Contracheque.App.Inputs;
using Stone.Api.Contracheque.App.Output;
using Stone.Api.Contracheque.App.Outputs;
using Stone.Api.Contracheque.Domain.Entities;

namespace Stone.Api.Contracheque.App.AutoMapper
{
    public static class DomainToOutputMappingProfile
    {
        public static FuncionarioOutput ConverteParaFuncionarioOutput(this Funcionario model)
        {
            return new FuncionarioOutput
            {
                Id = model.Id,
                CPF = model.CPF.Documento,
                Nome = model.NomeFuncionario.Nome,
                SobreNome = model.NomeFuncionario.SobreNome,
                Setor = model.Setor,
                SalarioBruto = model.SalarioBruto,
                DataDeAdmissao = model.DataDeAdmissao,
                PossuiDescontoPlanoDental = model.PossuiDescontoPlanoDental,
                PossuiDescontoPlanoDeSaude = model.PossuiDescontoPlanoDeSaude,
                PossuiDescontoValeTransporte = model.PossuiDescontoValeTransporte,
            };
        }

        public static ExtratoOutput ConverteParaExtratoOutput(this Extrato model)
        {
            return new ExtratoOutput
            {
                Lancamentos = model.Lancamentos,
                MesDeReferencia = model.MesDeReferencia,
                SalarioBruto = model.Funcionario.SalarioBruto,
                SalarioLiquido = model.SalarioLiquido,                
                TotalDeDescontos = model.TotalDeDescontos,                
            };
        }
    }
}
