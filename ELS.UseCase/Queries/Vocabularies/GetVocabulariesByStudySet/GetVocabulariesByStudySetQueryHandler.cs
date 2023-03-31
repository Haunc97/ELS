using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;

namespace ELS.UseCase.Queries.Vocabularies.GetVocabulariesByStudySet
{
    public class GetVocabulariesByStudySetQueryHandler : IQueryHandler<GetVocabulariesByStudySetQuery, List<Vocabulary>>
    {
        private readonly IVocabularyRepository vocabularyRepository;

        public GetVocabulariesByStudySetQueryHandler(IVocabularyRepository vocabularyRepository)
        {
            this.vocabularyRepository = vocabularyRepository;
        }

        public async Task<List<Vocabulary>> Handle(GetVocabulariesByStudySetQuery request, CancellationToken cancellationToken)
        {
            var vocs = await vocabularyRepository.GetListAsync(x => x.Status && x.StudySetVocabularies.Any(a => a.StudySetId == request.StudySetId));

            return vocs;
        }
    }
}
