using MediatR;

namespace ELS.UseCase.PluginInterfaces.Common
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}
