using ELS.UseCase.PluginInterfaces.Common;

namespace ELS.UseCase.Commands.Vocabularies.ImportVocabulary
{
    public record ImportVocabularyCommand(byte[] file, string importedBy) : ICommand;
}
