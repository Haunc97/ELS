using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;

namespace ELS.UseCase.Commands.Sentences.AddSentence
{
    public record AddSentenceCommand(
       string Term,
       string Definition,
       string CreatedBy,
       string Phonetics = "") : ICommand<long>;
}
