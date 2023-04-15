using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;

namespace ELS.UseCase.Commands.Vocabularies.AddVocabulary
{
    public record AddVocabularyCommand(
        string Term,
        string Definition,
        WordClassType Classification,
        VocabularyLevel Level,
        string CreatedBy,
        string Phonetics = "",
        string Description = "",
        string Example = "") : ICommand<long>;
}