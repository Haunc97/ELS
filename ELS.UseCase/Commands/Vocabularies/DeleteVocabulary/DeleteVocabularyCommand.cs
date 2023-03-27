using ELS.UseCase.PluginInterfaces.Common;

namespace ELS.UseCase.Commands.Vocabularies.DeleteVocabulary
{
    public record DeleteVocabularyCommand(long VocabularyId, string DeletedBy) : ICommand;
}