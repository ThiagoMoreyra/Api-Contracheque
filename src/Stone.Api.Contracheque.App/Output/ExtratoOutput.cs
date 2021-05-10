using Stone.Api.Contracheque.Domain.Entities;
using System.Collections.Generic;

namespace Stone.Api.Contracheque.App.Output
{
    public class ExtratoOutput
    {
        public int MesDeReferencia { get; set; }
        public double TotalDeDescontos { get; set; }
        public double SalarioLiquido { get; set; }
        public double SalarioBruto { get; set; }
        public List<Lancamento> Lancamentos { get; set; } = new List<Lancamento>();
    }
}
