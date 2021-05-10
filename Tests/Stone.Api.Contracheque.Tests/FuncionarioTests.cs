using Stone.Api.Contracheque.Domain.Entities;
using Stone.Api.Contracheque.Domain.ValueObjects;
using System;
using System.Linq;
using Xunit;

namespace Stone.Api.Contracheque.Tests
{
    [Collection(nameof(FuncionarioCollection))]
    public class FuncionarioTests
    {
        readonly FuncionarioTestsFixture _funcionarioTestsFixture;
        public FuncionarioTests(FuncionarioTestsFixture funcionarioTestsFixture)
        {
            _funcionarioTestsFixture = funcionarioTestsFixture;
        }

        [Fact(DisplayName = "Novo Funcionário Válido")]
        [Trait("Funcionario", "Funcionario Trait Testes")]
        public void Funcionario_NovoFuncionario_DeveEstarValido()
        {
            var funcionario = _funcionarioTestsFixture.GerarFuncionarioValido();

            var result = funcionario.EhValido();

            Assert.True(result);
            Assert.Empty(funcionario.ObtemErrosFuncionario());

        }

        [Fact(DisplayName = "Novo Funcionário Inválido")]
        [Trait("Funcionario", "Funcionario Trait Testes")]
        public void Funcionario_NovoFuncionario_DeveEstarInvalido()
        {
            var funcionario = _funcionarioTestsFixture.GerarFuncionarioInvalido();

            var result = funcionario.EhValido();

            Assert.False(result);
            Assert.Equal(3, funcionario.ObtemErrosFuncionario().Count());
        }

        [Theory(DisplayName = "Obtém salário líquido correto do funcionário")]
        [Trait("Funcionario ", "Funcionario Trail Testes")]
        [InlineData(6000.0, 3435.64)]
        [InlineData(3000.0, 1850.20)]
        [InlineData(2000.0, 1382.20)]
        [InlineData(1000.0, 830.0)]
        public void Funcionario_ObtemSalarioLiquido_RetornaSalarioLiquidoValido(double salarioBruto, double salarioLiquido)
        {
            var funcionario = _funcionarioTestsFixture.GerarFuncionarioValido(salarioBruto);

            var result = funcionario.ObtemSalarioLiquido();

            Assert.Equal(salarioLiquido, result);
        }

        [Theory(DisplayName = "Obtém salário líquido incorreto do funcionário")]
        [Trait("Funcionario ", "Funcionario Trail Testes")]
        [InlineData(0.0, 3435.64)]
        [InlineData(-1, 1850.20)]
        [InlineData(500.0, 1382.20)]        
        public void Funcionario_ObtemSalarioLiquido_RetornaSalarioLiquidoInvalido(double salarioBruto, double salarioLiquido)
        {
            var funcionario = _funcionarioTestsFixture.GerarFuncionarioValido(salarioBruto);

            var result = funcionario.ObtemSalarioLiquido();

            Assert.NotEqual(salarioLiquido, result);
        }
    }
}
