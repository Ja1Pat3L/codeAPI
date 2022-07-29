using System.ComponentModel.DataAnnotations;

namespace codeAPI.DTOs
{
    public class ClientTutorialForUpdateDto
    {
        [Required(ErrorMessage = "Id required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "ClientId required")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "TutorialId length required")]
        public int? TutorialId { get; set; }

    }
}
