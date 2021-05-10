using Stone.Api.Contracheque.Domain.Shared.Calculator;
using Stone.Api.Contracheque.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Stone.Api.Contracheque.Domain.Entities
{
    public class Funcionario
    {
        private List<string> Erros;

        protected Funcionario() { }
        public Funcionario(NomeFuncionario nomeFuncionario, Cpf cpf, string setor, double salarioBruto, DateTime dataDeAdmissao, bool possuiDescontoPlanoDeSaude,
            bool possuiDescontoPlanoDental, bool possuiDescontoValeTransporte)
        {
            Id = Guid.NewGuid();
            NomeFuncionario = nomeFuncionario;
            CPF = cpf;
            Setor = setor;
            SalarioBruto = salarioBruto;
            DataDeAdmissao = dataDeAdmissao;
            PossuiDescontoPlanoDeSaude = possuiDescontoPlanoDeSaude;
            PossuiDescontoPlanoDental = possuiDescontoPlanoDental;
            PossuiDescontoValeTransporte = possuiDescontoValeTransporte;
            Erros = new List<string>();
        }

        [Key]
        public Guid Id { get; private set; }
        public NomeFuncionario NomeFuncionario { get; private set; }
        public Cpf CPF { get; private set; }
        public string Setor { get; private set; }
        public double SalarioBruto { get; private set; }
        public DateTime DataDeAdmissao { get; private set; }
        public bool PossuiDescontoPlanoDeSaude { get; private set; }
        public bool PossuiDescontoPlanoDental { get; private set; }
        public bool PossuiDescontoValeTransporte { get; private set; }

        public bool EhValido()
        {
            ValidaNome();
            ValidaCpf();
            ValidaSalarioBruto();
            return !Erros.Any();
        }

        public List<string> ObtemErrosFuncionario() => Erros;

        private void ValidaNome()
        {
            if (this.NomeFuncionario.EhValido() is false)
                Erros.Add("O nome do funcionário está inválido");
        }

        private void ValidaCpf()
        {
            if (this.CPF.EhValido() is false)
                Erros.Add("O cpf do funcionário está inválido");
        }

        private void ValidaSalarioBruto()
        {
            if (this.SalarioBruto <= 0.0)
                Erros.Add("O salário do funcionário está inválido");
        }

        public double ObtemSalarioLiquido() =>
             CalculadorSalarioLiquido.
                CalculaSalarioLiquido(this.SalarioBruto, this.PossuiDescontoPlanoDental, this.PossuiDescontoPlanoDeSaude, this.PossuiDescontoValeTransporte);
    }
}