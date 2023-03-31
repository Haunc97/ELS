using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ELS.UseCase.Queries.StudySets.SearchStudySets
{
    public class SearchStudySetsQueryHandler : IQueryHandler<SearchStudySetsQuery, List<StudySet>>
    {
        private readonly IStudySetRepository studySetRepository;

        public SearchStudySetsQueryHandler(IStudySetRepository studySetRepository)
        {
            this.studySetRepository = studySetRepository;
        }
        public async Task<List<StudySet>> Handle(SearchStudySetsQuery request, CancellationToken cancellationToken)
        {
            var studSets = await studySetRepository.GetListAsync(x => x.Status
                                                          && (string.IsNullOrWhiteSpace(request.Title) || x.Title.ToLower().IndexOf(request.Title.ToLower()) >= 0),
                                                          includes: y => y.Include(x => x.StudySetVocabularies).ThenInclude(x => x.Vocabulary));
            return studSets;
        }
    }
}
