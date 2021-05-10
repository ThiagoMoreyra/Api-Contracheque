using System;

namespace Stone.Api.Contracheque.App.Outputs
{
    public class FuncionarioOutput
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string CPF { get; set; }
        public string Setor { get; set; }
        public double SalarioBruto { get; set; }
        public DateTime DataDeAdmissao { get; set; }
        public bool PossuiDescontoPlanoDeSaude { get; set; }
        public bool PossuiDescontoPlanoDental { get; set; }
        public bool PossuiDescontoValeTransporte { get; set; }
    }
}
