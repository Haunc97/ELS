using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;

namespace ELS.UseCase.Commands.StudySets.AddStudySet
{
    public class AddStudySetCommandHandler : ICommandHandler<AddStudySetCommand, long>
    {
        private readonly IStudySetRepository studySetRepository;

        public AddStudySetCommandHandler(IStudySetRepository studySetRepository)
        {
            this.studySetRepository = studySetRepository;
        }
        public async Task<long> Handle(AddStudySetCommand request, CancellationToken cancellationToken)
        {
            var stdSet = new StudySet
            {
                Title = request.Title,
                Description = request.Description,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow,
                Status = true,
                StudySetVocabularies = new List<StudySetVocabulary>()
            };

            foreach (var voc in request.Vocabularies)
            {
                var stdSetVoc = new StudySetVocabulary
                {
                    VocabularyId = voc.Id,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = request.CreatedBy
                };
                stdSet.StudySetVocabularies.Add(stdSetVoc);
            }

            await studySetRepository.AddAsync(stdSet);

            return stdSet.Id;
        }
    }
}