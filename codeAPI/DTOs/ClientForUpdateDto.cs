using System.ComponentModel.DataAnnotations;

namespace codeAPI.DTOs
{
    public class ClientForUpdateDto
    {
        [Required(ErrorMessage = "Client name required")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Client email required")]
        public string ClientEmail { get; set; }


        [Required(ErrorMessage = "Client password required")]
        public string ClientPassword { get; set; }


        [Required(ErrorMessage = "Client phone required")]
        public string ClientPhone { get; set; }

        [Required(ErrorMessage = "Client address required")]
        public string ClientAddress { get; set; }

        [Required(ErrorMessage = "Client postal code required")]
        public string ClientPostalzip { get; set; }

        public int TutorialId { get; set; }

    }
}
