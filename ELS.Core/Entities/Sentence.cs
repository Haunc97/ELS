using ELS.Core.Entities.Base;

namespace ELS.Core.Entities
{
    public class Sentence : Entity
    {
        public long Id { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }
        public string Phonetics { get; set; }
        public bool Status { get; set; }

        public ICollection<StudySetSentence> StudySetSentences { get; set; }
    }
}
