using System;

namespace Stone.Api.Contracheque.Domain.ValueObjects
{
    public class NomeFuncionario
    {
        public NomeFuncionario(string nome, string sobreNome)
        {
            Nome = nome;
            SobreNome = sobreNome;
        }

        public string Nome { get; private set; }
        public string SobreNome { get; private set;}

        public bool EhValido()
        {
            if (String.IsNullOrEmpty(this.Nome) && String.IsNullOrEmpty(this.SobreNome)) return false;
            
            return true;
        }
    }
}
