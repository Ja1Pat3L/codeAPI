
using System.ComponentModel.DataAnnotations;

namespace codeAPI.DTOs

{
    public class ClientTutorialForCreateDto
    { 
        [Required(ErrorMessage = "ClientId required")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "TutorialId length required")]
        public int? TutorialId { get; set; }

    }
}
