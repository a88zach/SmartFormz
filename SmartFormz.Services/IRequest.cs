using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFormz.Services
{

    public interface IRequest<TMessage> where TMessage : IMessage
    {
        TMessage Message { get; set; }
        void Execute();
    }

    public interface IRequest<TMessage, T> where TMessage : IMessage
    {
        TMessage Message { get; set; }
        T Execute();
    }

    public interface IAsyncRequest<TMessage, T> where TMessage : IMessage
    {
        TMessage Message { get; set; }
        Task<T> Execute();
    }
}
