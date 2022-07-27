using System;
using System.ComponentModel.DataAnnotations;
namespace codeAPI.DTOs
{
    public class TutorialCommentForUpdateDto
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public int? TutorialId { get; set; }

        [Required(ErrorMessage ="Comment Required")]
        [MaxLength(1000)]
        public string TutorialComment1 { get; set; }
        public DateTime? TutorialCommentTimestamp { get; set; }
    }
}
