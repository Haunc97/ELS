using ELS.Core.Entities;
using MediatR;

namespace ELS.UseCase.Queries.Sentences.GetSentenceById
{
    public record GetSentenceByIdQuery(long SentenceId) : IRequest<Sentence?>;
}