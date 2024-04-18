using DevIO.Business.Notificacoes;
using System.Collections.Generic;

namespace DevIO.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotifiacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
