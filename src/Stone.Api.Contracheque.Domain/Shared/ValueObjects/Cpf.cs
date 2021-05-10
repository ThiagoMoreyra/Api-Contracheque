using Stone.Api.Contracheque.Domain.Validations;
using System;

namespace Stone.Api.Contracheque.Domain.ValueObjects
{
    public class Cpf
    {
        public Cpf(string documento)
        {
            Documento = documento;
        }

        public string Documento { get; private set; }
        public bool EhValido()
        {
            return ValidadorCpf.Validar(this.Documento);
        }
    }
}
