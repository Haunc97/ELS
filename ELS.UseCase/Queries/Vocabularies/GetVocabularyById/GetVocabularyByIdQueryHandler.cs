using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Repositories;
using MediatR;

namespace ELS.UseCase.Queries.Vocabularies.GetVocabularyById
{
    public class GetVocabularyByIdQueryHandler : IRequestHandler<GetVocabularyByIdQuery, Vocabulary?>
    {
        private readonly IVocabularyRepository vocabularyRepository;

        public GetVocabularyByIdQueryHandler(IVocabularyRepository vocabularyRepository)
        {
            this.vocabularyRepository = vocabularyRepository;
        }
        public async Task<Vocabulary?> Handle(GetVocabularyByIdQuery request, CancellationToken cancellationToken)
        {
            var vocb = await vocabularyRepository.GetAsync(x => x.Id == request.VocabularyId && x.Status == true);

            return vocb;
        }
    }
}
