using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELS.UseCase.Queries.StudySets.GetStudySetById
{
    public class GetStudySetByIdQueryHandler : IRequestHandler<GetStudySetByIdQuery, StudySet?>
    {
        private readonly IStudySetRepository studySetRepository;

        public GetStudySetByIdQueryHandler(IStudySetRepository studySetRepository)
        {
            this.studySetRepository = studySetRepository;
        }

        public async Task<StudySet?> Handle(GetStudySetByIdQuery request, CancellationToken cancellationToken)
        {
            var stdSet = await studySetRepository.GetAsync(x => x.Id == request.Id && x.Status,
                includes: y => y.Include(x => x.StudySetVocabularies).ThenInclude(x => x.Vocabulary));

            return stdSet;
        }
    }
}
