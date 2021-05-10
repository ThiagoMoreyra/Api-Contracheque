using System.Collections.Generic;

namespace Stone.Api.Contracheque.Domain.Entities
{
    public class Extrato
    {
        public Extrato() { }
        public Extrato(int mesDeReferencia, Funcionario funcionario, List<Lancamento> lancamentos)
        {
            MesDeReferencia = mesDeReferencia;
            Lancamentos = new List<Lancamento>();
            Funcionario = funcionario;
            TotalDeDescontos = ObtemTotalDeDescontos() * -1;
            SalarioLiquido = Funcionario.ObtemSalarioLiquido();
            Lancamentos.AddRange(lancamentos);
        }

        public int MesDeReferencia { get; private set; }
        public List<Lancamento> Lancamentos { get; private set; }
        public double TotalDeDescontos { get; private set; }
        public double SalarioLiquido { get; private set; }
        public Funcionario Funcionario { get; private set; }

        private double ObtemTotalDeDescontos() => this.Funcionario.SalarioBruto - Funcionario.ObtemSalarioLiquido();
    }
}
