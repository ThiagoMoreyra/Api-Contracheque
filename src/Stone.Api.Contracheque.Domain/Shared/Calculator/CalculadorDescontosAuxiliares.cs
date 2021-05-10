using Stone.Api.Contracheque.Domain.Shared.Fees;

namespace Stone.Api.Contracheque.Domain.Shared.Calculator
{
    public static class CalculadorDescontosAuxiliares
    {
        public static double CalculaDescontoPlanoDeSaude(bool possuiPlanoDeSaude) =>
             (possuiPlanoDeSaude) ? DescontoBeneficios.DescontoPlanoDeSaude : 0.0;

        public static double CalculaDescontoPlanoDental(bool possuiPlanoDental) =>
            (possuiPlanoDental) ? DescontoBeneficios.DescontoPlanoDental : 0.0;

        public static double CalculaDescontoValeTransporte(double salarioBruto, bool possuiValeTransporte) =>
            (possuiValeTransporte && salarioBruto > 1500.0) ? salarioBruto * DescontoBeneficios.DescontoValeTransporte : 0.0;

        public static double CalculaDescontoFGTS(double salarioBruto) =>
            salarioBruto * DescontoBeneficios.DescontoFGTS;
    }
}
