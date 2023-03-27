using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;

namespace ELS.UseCase.Commands.Vocabularies.AddVocabulary
{
    public class AddVocabularyCommandHandler : ICommandHandler<AddVocabularyCommand, long>
    {
        private readonly IVocabularyRepository vocabularyRepository;

        public AddVocabularyCommandHandler(IVocabularyRepository vocabularyRepository)
        {
            this.vocabularyRepository = vocabularyRepository;
        }
        public async Task<long> Handle(AddVocabularyCommand request, CancellationToken cancellationToken)
        {
            Vocabulary voc = new()
            {
                Term = request.Term.Trim(),
                Definition = request.Definition.Trim(),
                Phonetics = request.Phonetics?.Trim(),
                Classification = request.Classification,
                Level = request.Level,
                Description = request.Description,
                Status = true,
                CreatedBy = request.CreatedBy,
                CreatedOn = DateTime.UtcNow
            };
            await vocabularyRepository.AddAsync(voc);
            return voc.Id;
        }
    }
}
