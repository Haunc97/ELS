using ELS.UseCase.PluginInterfaces.Common;

namespace ELS.UseCase.Commands.Sentences.EditSentence
{
    public record EditSentenceCommand(
        long SentenceId,
        string Term,
        string Definition,
        string UpdatedBy,
        string Phonetics = ""
        ) : ICommand<long>;
}
