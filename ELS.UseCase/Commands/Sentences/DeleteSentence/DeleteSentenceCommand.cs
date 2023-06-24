using ELS.UseCase.PluginInterfaces.Common;

namespace ELS.UseCase.Commands.Sentences.DeleteSentence
{
    public record DeleteSentenceCommand(long sentenceId, string DeletedBy) : ICommand;
}