using ELS.Core.Entities;
using ELS.UseCase.PluginInterfaces.Common;
using ELS.UseCase.PluginInterfaces.Repositories;
using MediatR;

namespace ELS.UseCase.Commands.Vocabularies.ImportVocabulary
{
    public class ImportVocabularyCommandHandler : ICommandHandler<ImportVocabularyCommand>
    {
        private readonly IExcelReader excelReader;
        private readonly IVocabularyRepository vocabularyRepository;

        public ImportVocabularyCommandHandler(IExcelReader excelReader, IVocabularyRepository vocabularyRepository)
        {
            this.excelReader = excelReader;
            this.vocabularyRepository = vocabularyRepository;
        }
        public async Task<Unit> Handle(ImportVocabularyCommand request, CancellationToken cancellationToken)
        {
            var models = excelReader.ReadExcel<VocabularyExcelModel>(request.file);

            if (models != null && models.Any())
            {
                var vocabs = new List<Vocabulary>();

                foreach (var model in models)
                {
                    if (string.IsNullOrWhiteSpace(model.Term))
                        throw new InvalidDataException();

                    if (string.IsNullOrWhiteSpace(model.Definition))
                        throw new InvalidDataException();

                    var vocab = new Vocabulary
                    {
                        Term = model.Term.ToLower().Trim(),
                        Definition = model.Definition.ToLower().Trim(),
                        Phonetics = model.Phonetics?.Trim(),
                        Classification = MapClassification(model.Classification),
                        Level = MapLevel(model.Level),
                        Status = true,
                        CreatedBy = request.importedBy,
                        CreatedOn = DateTime.UtcNow
                    };

                    vocabs.Add(vocab);
                }

                await vocabularyRepository.AddRangeAsync(vocabs.ToArray());
            }

            return Unit.Value;
        }

        private WordClassType MapClassification(string value)
        {
            WordClassType classification = WordClassType.Other;
            if (!string.IsNullOrWhiteSpace(value))
            {
                switch (value.Trim().ToLower())
                {
                    case "v":
                        classification = WordClassType.Verb;
                        break;
                    case "n":
                        classification = WordClassType.Noun;
                        break;
                    case "adj":
                        classification = WordClassType.Adjective; 
                        break;
                    case "adv":
                        classification = WordClassType.Adverb;
                        break;
                    case "phrasal v":
                        classification = WordClassType.PhrasalVerb;
                        break;
                    case "phrasal verb":
                        classification = WordClassType.PhrasalVerb;
                        break;
                    case "idiom":
                        classification = WordClassType.Idiom;
                        break;
                    case "conjunction":
                        classification = WordClassType.Conjunction;
                        break;
                    default:
                        break;
                }
            }

            return classification;
        }

        private VocabularyLevel MapLevel(string value)
        {
            VocabularyLevel level = VocabularyLevel.Easy;
            if (!string.IsNullOrWhiteSpace(value))
            {
                switch (value.Trim().ToUpper())
                {
                    case "E":
                        level = VocabularyLevel.Easy;
                        break;
                    case "M":
                        level = VocabularyLevel.Medium;
                        break;
                    case "H":
                        level = VocabularyLevel.Hard;
                        break;
                    default:
                        break;
                }
            }

            return level;
        }
    }



    public class VocabularyExcelModel
    {
        public string Term { get; set; }
        public string Classification { get; set; }
        public string Definition { get; set; }
        public string Phonetics { get; set; }
        public string Level { get; set; }
    }
}
