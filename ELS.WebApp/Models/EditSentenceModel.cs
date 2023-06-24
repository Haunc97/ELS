using System.ComponentModel.DataAnnotations;

namespace ELS.WebApp.Models
{
    public class EditSentenceModel
    {
        [Required]
        public string Term { get; set; }

        [Required]
        public string Definition { get; set; }

        public string Phonetics { get; set; }
    }
}