using System.Threading.Tasks;

namespace NanoBus
{
    public interface IHandleCommand<TBusCommand> where TBusCommand : IBusCommand
    {
        Task Handle(TBusCommand busCommand);
    }
}