using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ELS.UseCase.Commands.StudySets.EditStudySet
{
    public class EditStudySetCommandHandler : ICommandHandler<EditStudySetCommand, long?>
    {
        private readonly IStudySetRepository studySetRepository;
        private readonly IStudySetVocabularyRepository studySetVocabularyRepository;

        public EditStudySetCommandHandler(IStudySetRepository studySetRepository, IStudySetVocabularyRepository studySetVocabularyRepository)
        {
            this.studySetRepository = studySetRepository;
            this.studySetVocabularyRepository = studySetVocabularyRepository;
        }

        public async Task<long?> Handle(EditStudySetCommand request, CancellationToken cancellationToken)
        {
            var stdSet = await studySetRepository.GetAsync(x => x.Id == request.Id && x.Status,
                includes: y => y.Include(x => x.StudySetVocabularies));

            if (stdSet != null)
            {
                stdSet.Title = request.Title;
                stdSet.Description = request.Description;
                stdSet.UpdatedOn = DateTime.UtcNow;
                stdSet.UpdatedBy = request.UpdatedBy;

                await studySetRepository.UpdateAsync(stdSet);

                var toAddStdSetVocs = new List<StudySetVocabulary>();
                var toDeleteStdSetVocs = new List<StudySetVocabulary>();
                var currentVocIds = new List<long>();

                foreach (var stdSetVoc in stdSet.StudySetVocabularies)
                {
                    var voc = request.Vocabularies.FirstOrDefault(x => x.Id == stdSetVoc.VocabularyId);

                    if (voc == null)
                    {
                        toDeleteStdSetVocs.Add(stdSetVoc);
                    }
                    else
                    {
                        currentVocIds.Add(voc.Id);
                    }
                }

                foreach (var voc in request.Vocabularies)
                {
                    if (!currentVocIds.Contains(voc.Id))
                    {
                        toAddStdSetVocs.Add(new StudySetVocabulary
                        {
                            StudySetId = stdSet.Id,
                            VocabularyId = voc.Id,
                            CreatedBy = request.UpdatedBy,
                            CreatedOn = DateTime.UtcNow
                        });
                    }
                }

                await studySetVocabularyRepository.RemoveRangeAsync(toDeleteStdSetVocs.ToArray());
                await studySetVocabularyRepository.AddRangeAsync(toAddStdSetVocs.ToArray());

                return stdSet.Id;
            }

            return null;
        }
    }
}
