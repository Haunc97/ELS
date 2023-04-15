using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;

namespace ELS.UseCase.Commands.Vocabularies.EditVocabulary
{
    public class EditVocabularyCommandHandler : ICommandHandler<EditVocabularyCommand, long>
    {
        private readonly IVocabularyRepository vocabularyRepository;

        public EditVocabularyCommandHandler(IVocabularyRepository vocabularyRepository)
        {
            this.vocabularyRepository = vocabularyRepository;
        }
        public async Task<long> Handle(EditVocabularyCommand request, CancellationToken cancellationToken)
        {
            var vocb = await vocabularyRepository.GetAsync(x => x.Id == request.VocabularyId);

            if (vocb != null)
            {
                vocb.Term = request.Term.Trim();
                vocb.Definition = request.Definition.Trim();
                vocb.Phonetics = request.Phonetics?.Trim();
                vocb.Classification = request.Classification;
                vocb.Level = request.Level;
                vocb.UpdatedOn = DateTime.UtcNow;
                vocb.UpdatedBy = request.UpdatedBy;
                vocb.Example = request.Example;

                await vocabularyRepository.UpdateAsync(vocb);
            }

            return request.VocabularyId;
        }
    }
}
