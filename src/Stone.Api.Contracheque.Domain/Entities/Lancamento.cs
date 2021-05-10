using Stone.Api.Contracheque.Domain.Entities.Enum;
using Stone.Api.Contracheque.Domain.Shared.Calculator;
using System.Collections.Generic;

namespace Stone.Api.Contracheque.Domain.Entities
{
    public class Lancamento
    {
        public TipoLancamento TipoLancamento { get; set; }
        public double Valor { get; set; }
        public DescricaoLancamento DescricaoLancamento { get; set; }
        public Funcionario Funcionario { get; set; }

        public List<Lancamento> ObtemLancamentos(Funcionario funcionario)
        {
            List<Lancamento> lancamentos = new List<Lancamento>();
            lancamentos.Add(ObtemLancamentoFGTS(funcionario));
            lancamentos.Add(ObtemLancamentoINSS(funcionario));
            lancamentos.Add(ObtemLancamentoIRRF(funcionario));
            lancamentos.Add(ObtemLancamentoPlanoDeSaude(funcionario));
            lancamentos.Add(ObtemLancamentoPlanoDental(funcionario));
            lancamentos.Add(ObtemLancamentoValeTransporte(funcionario));

            return lancamentos;
        }

        #region [Métodos Privados]

        private Lancamento ObtemLancamentoFGTS(Funcionario funcionario)
        {
            return new Lancamento
            {
                TipoLancamento = TipoLancamento.Desconto,
                DescricaoLancamento = DescricaoLancamento.FGTS,
                Valor = CalculadorDescontosAuxiliares.CalculaDescontoFGTS(funcionario.SalarioBruto),
            };
        }

        private Lancamento ObtemLancamentoINSS(Funcionario funcionario)
        {
            return new Lancamento
            {
                TipoLancamento = TipoLancamento.Desconto,
                DescricaoLancamento = DescricaoLancamento.INSS,
                Valor = CalculadorDescontoAliquotaINSS.CalculaDescontoDeAliquotaINSS(funcionario.SalarioBruto),
            };
        }

        private Lancamento ObtemLancamentoIRRF(Funcionario funcionario)
        {
            return new Lancamento
            {
                TipoLancamento = TipoLancamento.Desconto,
                DescricaoLancamento = DescricaoLancamento.IRRF,
                Valor = CalculadorIRRF.CalculaDescontoIRRF(funcionario.SalarioBruto),
            };
        }

        private Lancamento ObtemLancamentoPlanoDeSaude(Funcionario funcionario)
        {
            return new Lancamento
            {
                TipoLancamento = TipoLancamento.Desconto,
                DescricaoLancamento = DescricaoLancamento.PlanoDeSaude,
                Valor = CalculadorDescontosAuxiliares.CalculaDescontoPlanoDeSaude(funcionario.PossuiDescontoPlanoDeSaude),
            };
        }
        private Lancamento ObtemLancamentoPlanoDental(Funcionario funcionario)
        {
            return new Lancamento
            {
                TipoLancamento = TipoLancamento.Desconto,
                DescricaoLancamento = DescricaoLancamento.PlanoDental,
                Valor = CalculadorDescontosAuxiliares.CalculaDescontoPlanoDeSaude(funcionario.PossuiDescontoPlanoDental),
            };
        }

        private Lancamento ObtemLancamentoValeTransporte(Funcionario funcionario)
        {
            return new Lancamento
            {
                TipoLancamento = TipoLancamento.Desconto,
                DescricaoLancamento = DescricaoLancamento.ValeTransporte,
                Valor = CalculadorDescontosAuxiliares.CalculaDescontoValeTransporte(funcionario.SalarioBruto, true),
            };
        }

        #endregion
    }
}
