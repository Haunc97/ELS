using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;

namespace ELS.UseCase.Commands.Vocabularies.EditVocabulary
{
    public record EditVocabularyCommand(
        long VocabularyId,
        string Term,
        string Definition,
        WordClassType Classification,
        VocabularyLevel Level,
        string UpdatedBy,
        string Phonetics = "",
        string Description = "",
        string Example = ""
        ) : ICommand<long>;
}