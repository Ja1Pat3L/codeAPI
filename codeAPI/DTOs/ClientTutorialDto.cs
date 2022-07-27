using codeLibrary.Models;

namespace codeAPI.DTOs
{
    public class ClientTutorialDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int? TutorialId { get; set; }

        public virtual Client Client { get; set; }

    }
}
