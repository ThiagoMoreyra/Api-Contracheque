namespace Stone.Api.Contracheque.Domain.Shared.Calculator
{
    public static class CalculadorSalarioLiquido
    {
        public static double CalculaSalarioLiquido(double salarioBruto, bool possuiPlanoDental, bool possuiPlanoDeSaude, bool possuiValeTransporte)
        {
            var descontoINSS = CalculadorDescontoAliquotaINSS.CalculaDescontoDeAliquotaINSS(salarioBruto);
            var descontoIRRF = CalculadorIRRF.CalculaDescontoIRRF(salarioBruto);
            var descontoFGTS = CalculadorDescontosAuxiliares.CalculaDescontoFGTS(salarioBruto);
            var descontoPlanoDeSaude = CalculadorDescontosAuxiliares.CalculaDescontoPlanoDeSaude(possuiPlanoDeSaude);
            var descontoPlanoDental = CalculadorDescontosAuxiliares.CalculaDescontoPlanoDental(possuiPlanoDental);
            var descontoValeTransporte = CalculadorDescontosAuxiliares.CalculaDescontoValeTransporte(salarioBruto, possuiValeTransporte);
            var totalDescontos = ObtemTotalDeDescontos(descontoINSS, descontoIRRF, descontoFGTS, descontoPlanoDeSaude, descontoPlanoDental, descontoValeTransporte);

            return salarioBruto - totalDescontos;
        }

        public static double ObtemTotalDeDescontos(double inss, double irrf, double fgts, double planoDeSaude, double planoDental, double valeTransporte)
        {
            return (inss + irrf + fgts + planoDeSaude + planoDental + valeTransporte);
        }
    }
}
