using ELS.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace ELS.Core.Entities
{
    public class Vocabulary : Entity
    {
        public long Id { get; set; }

        [Required]
        public string Term { get; set; }
        public WordClassType Classification { get; set; }
        public string Definition { get; set; }
        public string Phonetics { get; set; }
        public VocabularyLevel Level { get; set; }
        public string Description { get; set; }
        public string Example { get; set; }
        public bool Status { get; set; }
        public ICollection<StudySetVocabulary> StudySetVocabularies { get; set; }
    }
}