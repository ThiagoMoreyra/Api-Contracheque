using Stone.Api.Contracheque.Domain.Entities.Enum;
using Stone.Api.Contracheque.Domain.Shared.Calculator;
using System.Collections.Generic;

namespace Stone.Api.Contracheque.Domain.Entities
{
    public class Lancamento
    {
        public string TipoLancamento { get; set; }
        public double Valor { get; set; }
        public string DescricaoLancamento { get; set; }

        public List<Lancamento> ObtemLancamentos(Funcionario funcionario)
        {
            List<Lancamento> lancamentos = new List<Lancamento>();
            lancamentos.Add(ObtemLancamentoFGTS(funcionario));
            lancamentos.Add(ObtemLancamentoINSS(funcionario));
            lancamentos.Add(ObtemLancamentoIRRF(funcionario));
            lancamentos.Add(ObtemLancamentoPlanoDeSaude(funcionario));
            lancamentos.Add(ObtemLancamentoPlanoDental(funcionario));
            lancamentos.Add(ObtemLancamentoValeTransporte(funcionario));
            lancamentos.Add(ObtemLancamentoSalarioLiquido(funcionario));

            return lancamentos;
        }

        #region [Métodos Privados]

        private Lancamento ObtemLancamentoFGTS(Funcionario funcionario)
        {
            return new Lancamento
            {
                TipoLancamento = System.Enum.GetName(typeof(TipoLancamento), Enum.TipoLancamento.Desconto),
                DescricaoLancamento = System.Enum.GetName(typeof(DescricaoLancamento), Enum.DescricaoLancamento.FGTS),
                Valor = CalculadorDescontosAuxiliares.CalculaDescontoFGTS(funcionario.SalarioBruto),
            };
        }

        private Lancamento ObtemLancamentoINSS(Funcionario funcionario)
        {
            return new Lancamento
            {
                TipoLancamento = System.Enum.GetName(typeof(TipoLancamento), Enum.TipoLancamento.Desconto),
                DescricaoLancamento = System.Enum.GetName(typeof(DescricaoLancamento), Enum.DescricaoLancamento.INSS),
                Valor = CalculadorDescontoAliquotaINSS.CalculaDescontoDeAliquotaINSS(funcionario.SalarioBruto),
            };
        }

        private Lancamento ObtemLancamentoIRRF(Funcionario funcionario)
        {
            return new Lancamento
            {
                TipoLancamento = System.Enum.GetName(typeof(TipoLancamento), Enum.TipoLancamento.Desconto),
                DescricaoLancamento = System.Enum.GetName(typeof(DescricaoLancamento), Enum.DescricaoLancamento.IRRF),
                Valor = CalculadorIRRF.CalculaDescontoIRRF(funcionario.SalarioBruto),
            };
        }

        private Lancamento ObtemLancamentoPlanoDeSaude(Funcionario funcionario)
        {
            return new Lancamento
            {
                TipoLancamento = System.Enum.GetName(typeof(TipoLancamento), Enum.TipoLancamento.Desconto),
                DescricaoLancamento = System.Enum.GetName(typeof(DescricaoLancamento), Enum.DescricaoLancamento.PlanoDeSaude),
                Valor = CalculadorDescontosAuxiliares.CalculaDescontoPlanoDeSaude(funcionario.PossuiDescontoPlanoDeSaude),
            };
        }
        private Lancamento ObtemLancamentoPlanoDental(Funcionario funcionario)
        {
            return new Lancamento
            {
                TipoLancamento = System.Enum.GetName(typeof(TipoLancamento), Enum.TipoLancamento.Desconto),
                DescricaoLancamento = System.Enum.GetName(typeof(DescricaoLancamento), Enum.DescricaoLancamento.PlanoDental),
                Valor = CalculadorDescontosAuxiliares.CalculaDescontoPlanoDeSaude(funcionario.PossuiDescontoPlanoDental),
            };
        }

        private Lancamento ObtemLancamentoValeTransporte(Funcionario funcionario)
        {
            return new Lancamento
            {
                TipoLancamento = System.Enum.GetName(typeof(TipoLancamento), Enum.TipoLancamento.Desconto),
                DescricaoLancamento = System.Enum.GetName(typeof(DescricaoLancamento), Enum.DescricaoLancamento.ValeTransporte),
                Valor = CalculadorDescontosAuxiliares.CalculaDescontoValeTransporte(funcionario.SalarioBruto, true),
            };
        }

        private Lancamento ObtemLancamentoSalarioLiquido(Funcionario funcionario)
        {
            return new Lancamento
            {
                TipoLancamento = System.Enum.GetName(typeof(TipoLancamento), Enum.TipoLancamento.Remuneracao),
                DescricaoLancamento = System.Enum.GetName(typeof(DescricaoLancamento), Enum.DescricaoLancamento.Salario),
                Valor = CalculadorSalarioLiquido.
                CalculaSalarioLiquido(funcionario.SalarioBruto, funcionario.PossuiDescontoPlanoDental, funcionario.PossuiDescontoPlanoDeSaude, funcionario.PossuiDescontoValeTransporte),
            };
        }

        #endregion
    }
}
