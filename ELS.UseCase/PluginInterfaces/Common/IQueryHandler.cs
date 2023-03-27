using MediatR;

namespace ELS.UseCase.PluginInterfaces.Common
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {

    }
}
