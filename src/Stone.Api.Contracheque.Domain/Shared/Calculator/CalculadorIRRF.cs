using Stone.Api.Contracheque.Domain.Shared.Calculator.Fees;

namespace Stone.Api.Contracheque.Domain.Shared.Calculator
{
    public static class CalculadorIRRF
    {
        public static double CalculaDescontoIRRF(double salarioBruto)
        {
            var aliquotaIRPF = ObtemAliquotaImpostoRetidoNaFonte(salarioBruto);
            var descontoIRPF = salarioBruto * aliquotaIRPF;
            var parcelaADeduzirIRPF = VerificaParelaADeduzirIRPF(aliquotaIRPF, descontoIRPF);
            if (parcelaADeduzirIRPF != ParcelaADeduzirIRPF.ParcelaIRPFNaoEncontrada)
                return parcelaADeduzirIRPF;

            return descontoIRPF;
        }

        private static double ObtemAliquotaImpostoRetidoNaFonte(double salario)
        {
            if (salario <= 1903.90)
                return 0.0;

            if (salario >= 1903.98 && salario <= 2826.65)
                return AliquotaIRRetidoNaFonte.Aliquota_7_5;

            if (salario >= 2826.66 && salario <= 3751.05)
                return AliquotaIRRetidoNaFonte.Aliquota_15;

            if (salario >= 3751.06 && salario <= 4664.68)
                return AliquotaIRRetidoNaFonte.Aliquota_22_5;

            if (salario > 4664.68)
                return AliquotaIRRetidoNaFonte.Aliquota_27_5;

            return AliquotaINSS.AliquotaNaoEncontrada;
        }

        private static double VerificaParelaADeduzirIRPF(double aliquota, double desconto)
        {
            if (aliquota == AliquotaIRRetidoNaFonte.Aliquota_7_5 && desconto > ParcelaADeduzirIRPF.Parcela_Aliquota_7_5)
                return ParcelaADeduzirIRPF.Parcela_Aliquota_7_5;

            if (aliquota == AliquotaIRRetidoNaFonte.Aliquota_15 && desconto > ParcelaADeduzirIRPF.Parcela_Aliquota_15)
                return ParcelaADeduzirIRPF.Parcela_Aliquota_15;

            if (aliquota == AliquotaIRRetidoNaFonte.Aliquota_22_5 && desconto > ParcelaADeduzirIRPF.Parcela_Aliquota_22_5)
                return ParcelaADeduzirIRPF.Parcela_Aliquota_22_5;

            if (aliquota == AliquotaIRRetidoNaFonte.Aliquota_27_5 && desconto > ParcelaADeduzirIRPF.Parcela_Aliquota_27_5)
                return ParcelaADeduzirIRPF.Parcela_Aliquota_27_5;

            return ParcelaADeduzirIRPF.ParcelaIRPFNaoEncontrada;
        }
    }
}
