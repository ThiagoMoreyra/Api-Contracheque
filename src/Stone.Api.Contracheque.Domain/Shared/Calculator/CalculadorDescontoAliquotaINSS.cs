using Stone.Api.Contracheque.Domain.Shared.Calculator.Fees;

namespace Stone.Api.Contracheque.Domain.Shared.Calculator
{
    public static class CalculadorDescontoAliquotaINSS
    {
        public static double CalculaDescontoDeAliquotaINSS(double salarioBruto)
        {
            return salarioBruto * ObtemAliquotaINSS(salarioBruto);
        }

        private static double ObtemAliquotaINSS(double salario)
        {
            if (salario <= 1045.0)
                return AliquotaINSS.Aliquota_7_5;

            if (salario >= 1045.01 && salario <= 2089.60)
                return AliquotaINSS.Aliquota_9_0;

            if (salario >= 2089.61 && salario <= 3134.40)
                return AliquotaINSS.Aliquota_12_0;

            if (salario >= 3134.41 && salario <= 6101.06)
                return AliquotaINSS.Aliquota_14_0;

            return AliquotaINSS.AliquotaNaoEncontrada;
        }
    }
}
