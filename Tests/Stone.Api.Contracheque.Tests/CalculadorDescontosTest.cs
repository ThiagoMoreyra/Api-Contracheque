using Stone.Api.Contracheque.Domain.Shared.Calculator;
using Xunit;

namespace Stone.Api.Contracheque.Tests
{
    public class CalculadorDescontosTest
    {
        #region [Cáculo Desconto INSS]

        [Theory(DisplayName = "Desconto INSS executado com sucesso")]
        [Trait("Desconto ", "Desconto Trail INSS")]
        [InlineData(1045.0, 78.375)]
        [InlineData(1045.01, 94.0509)]
        [InlineData(2089.60, 188.064)]
        [InlineData(2089.61, 250.7532)]
        [InlineData(3134.40, 376.128)]
        [InlineData(3134.41, 438.8174)]
        [InlineData(6101.06, 854.1484000000002)]
        [InlineData(3134.60, 438.84400000000005)]
        [InlineData(6101.30, 0)]
        public void Funcionario_Desconto_DescontosDevemRespeitarRegraDeAliquotaINSS(double salarioBruto, double valorDesconto)
        {
            var desconto = CalculadorDescontoAliquotaINSS.CalculaDescontoDeAliquotaINSS(salarioBruto);

            Assert.Equal(desconto, valorDesconto);
        }

        [Theory(DisplayName = "Desconto INSS Valor retorno inválido")]
        [Trait("Desconto ", "Desconto Trail INSS")]
        [InlineData(6101.30, 854.1484000000002)]
        [InlineData(0.0, 854.1484000000002)]
        [InlineData(-1, 854.1484000000002)]
        public void Funcionario_Desconto_RetornaValorAliquotaINSSInvalido(double salarioBruto, double valorDesconto)
        {
            var desconto = CalculadorDescontoAliquotaINSS.CalculaDescontoDeAliquotaINSS(salarioBruto);

            Assert.NotEqual(desconto, valorDesconto);
        }

        #endregion

        #region [Cáculo Desconto IRPF]

        [Theory(DisplayName = "Desconto IRPF executado com sucesso")]
        [Trait("Desconto ", "Desconto Trail IRPF")]
        [InlineData(1903.90, 0.0)]
        [InlineData(1903.98, 142.7985)]
        [InlineData(2826.65, 142.80)]
        [InlineData(2826.66, 354.80)]
        [InlineData(3751.05, 354.80)]
        [InlineData(3751.06, 636.13)]
        [InlineData(4664.68, 636.13)]
        [InlineData(4664.69, 869.36)]
        public void Funcionario_Desconto_DescontosDevemRespeitarRegraDeAliquotaIRRF(double salarioBruto, double valorDesconto)
        {
            var desconto = CalculadorIRRF.CalculaDescontoIRRF(salarioBruto);

            Assert.Equal(desconto, valorDesconto);
        }

        [Theory(DisplayName = "Desconto INSS retorno inválido")]
        [Trait("Desconto ", "Desconto Trail INSS")]
        [InlineData(1903.98, 142.8)]
        [InlineData(2826.65, 423.999)]
        [InlineData(2826.66, 562.6575)]
        [InlineData(3751.05, 843.9885)]
        [InlineData(3751.06, 1049.553)]
        [InlineData(4664.68, 1282.787)]
        [InlineData(4664.69, 1282.78975)]
        public void Funcionario_Desconto_RetornaDeAliquotaIRRFInvalido(double salarioBruto, double valorDesconto)
        {
            var desconto = CalculadorIRRF.CalculaDescontoIRRF(salarioBruto);

            Assert.NotEqual(desconto, valorDesconto);
        }

        #endregion

        #region [Cáculo Desconto Plano de Saúde]

        [Theory(DisplayName = "Desconto Plano de saúde executado com sucesso")]
        [Trait("Desconto ", "Desconto Trail Plano de saúde")]
        [InlineData(1045.01, 1035.01)]
        [InlineData(1903.90, 1893.90)]
        [InlineData(3751.06, 3741.06)]
        [InlineData(4664.68, 4654.68)]
        [InlineData(4664.69, 4654.69)]
        public void Funcionario_Desconto_DescontoDeveRespeitarRegraPlanoDeSaude(double salarioBruto, double valorDesconto)
        {
            var desconto = CalculadorDescontosAuxiliares.CalculaDescontoPlanoDeSaude(true);

            Assert.Equal(salarioBruto - desconto, valorDesconto);
        }

        [Theory(DisplayName = "Desconto INSS retorno inválido")]
        [Trait("Desconto ", "Desconto Trail Plano de saúde")]
        [InlineData(-1045.01, 1035.01)]
        [InlineData(1903.90, 1893.90)]
        public void Funcionario_Desconto_DescontoNaoDeveExecutarRegraPlanoDeSaude(double salarioBruto, double valorDesconto)
        {
            var desconto = CalculadorDescontosAuxiliares.CalculaDescontoPlanoDeSaude(false);

            Assert.NotEqual(salarioBruto - desconto, valorDesconto);
        }

        #endregion

        #region [Cáculo Desconto Plano Dental]

        [Theory(DisplayName = "Desconto Plano Dental executado com sucesso")]
        [Trait("Desconto ", "Desconto Trail Plano Dental")]
        [InlineData(1045.01, 1040.01)]
        [InlineData(1903.90, 1898.90)]
        public void Funcionario_Desconto_DescontoDeveRespeitarRegraPlanoDental(double salarioBruto, double valorDesconto)
        {
            var desconto = CalculadorDescontosAuxiliares.CalculaDescontoPlanoDental(true);

            Assert.Equal(salarioBruto - desconto, valorDesconto);
        }

        [Theory(DisplayName = "Desconto Plano Dental retorno inválido")]
        [Trait("Desconto ", "Desconto Trail Plano Dental")]
        [InlineData(1045.01, 1040.01)]
        [InlineData(1903.90, 1898.90)]
        public void Funcionario_Desconto_DescontoNaoDeveExecutarRegraPlanoDental(double salarioBruto, double valorDesconto)
        {
            var desconto = CalculadorDescontosAuxiliares.CalculaDescontoPlanoDental(false);

            Assert.NotEqual(salarioBruto - desconto, valorDesconto);
        }

        #endregion

        #region [Cáculo Desconto Vale Transporte]

        [Theory(DisplayName = "Desconto Vale Transporte executado com sucesso")]
        [Trait("Desconto ", "Desconto Trail Vale Transporte")]
        [InlineData(1700.01, 102.00059999999999)]
        [InlineData(1903.90, 114.234)]
        [InlineData(1400.90, 0.0)]
        public void Funcionario_Desconto_DescontoDeveRespeitarRegraDeValeTransporte(double salarioBruto, double valorDesconto)
        {
            var desconto = CalculadorDescontosAuxiliares.CalculaDescontoValeTransporte(salarioBruto, true);

            Assert.Equal(desconto, valorDesconto);
        }

        [Theory(DisplayName = "Desconto Vale Transporte retorno inválido")]
        [Trait("Desconto ", "Desconto Trail Vale Transporte")]
        [InlineData(1400.01, 1699.95)]
        [InlineData(1903.90, 1903.8400000000001)]
        public void Funcionario_Desconto_DescontoNaoDeveExecutarRegraDeValeTransporte(double salarioBruto, double valorDesconto)
        {
            var desconto = CalculadorDescontosAuxiliares.CalculaDescontoValeTransporte(salarioBruto, false);

            Assert.NotEqual(desconto, valorDesconto);
        }

        #endregion

        #region [Cáculo Desconto FGTS]

        [Theory(DisplayName = "Desconto FGTS executado com sucesso")]
        [Trait("Desconto ", "Desconto Trail FGTS")]
        [InlineData(1700.01, 136.0008)]
        [InlineData(1903.90, 152.312)]
        [InlineData(1400.90, 112.072)]
        public void Funcionario_Desconto_DescontoDeveRespeitarRegraDeFGTS(double salarioBruto, double valorDesconto)
        {
            var desconto = CalculadorDescontosAuxiliares.CalculaDescontoFGTS(salarioBruto);

            Assert.Equal(desconto, valorDesconto);
        }

        [Theory(DisplayName = "Desconto FGTS Retorno Inválido")]
        [Trait("Desconto ", "Desconto Trail FGTS")]
        [InlineData(0, 136.0008)]
        [InlineData(-1, 152.312)]
        [InlineData(1400.90, 112.070)]
        public void Funcionario_Desconto_DescontontoNaoDeveExecutarRegraDeFGTS(double salarioBruto, double valorDesconto)
        {
            var desconto = CalculadorDescontosAuxiliares.CalculaDescontoFGTS(salarioBruto);

            Assert.NotEqual(desconto, valorDesconto);
        }

        #endregion
    }
}
