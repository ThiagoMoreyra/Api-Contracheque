namespace Stone.Api.Contracheque.Domain.Shared.Notify
{
    public sealed class Notificacao
    {
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; }
    }
}