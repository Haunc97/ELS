using MediatR;

namespace ELS.UseCase.PluginInterfaces.Common
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
