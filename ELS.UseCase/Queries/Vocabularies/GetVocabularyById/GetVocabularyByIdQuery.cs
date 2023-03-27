using ELS.Core.Entities;
using MediatR;

namespace ELS.UseCase.Queries.Vocabularies.GetVocabularyById
{
    public record GetVocabularyByIdQuery(long VocabularyId) : IRequest<Vocabulary?>;
}