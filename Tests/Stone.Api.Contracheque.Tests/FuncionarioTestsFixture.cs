using Stone.Api.Contracheque.Domain.Entities;
using Stone.Api.Contracheque.Domain.ValueObjects;
using System;
using Xunit;

namespace Stone.Api.Contracheque.Tests
{
    [CollectionDefinition(nameof(FuncionarioCollection))]
    public class FuncionarioCollection : ICollectionFixture<FuncionarioTestsFixture> { }
    public class FuncionarioTestsFixture : IDisposable
    {
        public Funcionario GerarFuncionarioValido()
        {
            Cpf cpf = new Cpf("515.523.840-47");
            NomeFuncionario nomeFuncionario = new NomeFuncionario("Thiago", "Moreira");

            return new Funcionario(
                nomeFuncionario,
                cpf,
                "TI",
                6.500,
                DateTime.Now,
                true,
                true,
                true
                );
        }

        public Funcionario GerarFuncionarioValido(double salarioBruto)
        {
            Cpf cpf = new Cpf("515.523.840-47");
            NomeFuncionario nomeFuncionario = new NomeFuncionario("Thiago", "Moreira");

            return new Funcionario(
                nomeFuncionario,
                cpf,
                "TI",
                salarioBruto,
                DateTime.Now,
                true,
                true,
                true
                );
        }

        public Funcionario GerarFuncionarioInvalido()
        {
            Cpf cpf = new Cpf("000000000000");
            NomeFuncionario nomeFuncionario = new NomeFuncionario("", "");
            return new Funcionario(
                nomeFuncionario,
                cpf,
                "TI",
                0.0,
                DateTime.Now,
                true,
                true,
                true
                );
        }

        public Funcionario GerarFuncionarioInvalido(double salarioBruto)
        {
            Cpf cpf = new Cpf("000000000000");
            NomeFuncionario nomeFuncionario = new NomeFuncionario("", "");
            return new Funcionario(
                nomeFuncionario,
                cpf,
                "TI",
                salarioBruto,
                DateTime.Now,
                true,
                true,
                true
                );
        }

        public void Dispose()
        {            
        }
    }
}
