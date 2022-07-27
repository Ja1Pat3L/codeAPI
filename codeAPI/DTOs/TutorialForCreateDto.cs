using System.ComponentModel.DataAnnotations;

namespace codeAPI.DTOs
{
    public class TutorialForCreateDto
    {
        [Required(ErrorMessage="Tutorial name required")]
        [MaxLength(80)]
        public string TutorialName { get; set; }
        [Required(ErrorMessage = "Tutorial description required")]
        public string TutorialDescription { get; set; }
        [Required(ErrorMessage = "Language preference required")]
        public string TutorialLanguagePreference { get; set; }
        [Required(ErrorMessage = "Tutorial length required")]
        public int TutorialHours { get; set; }
    }
}
