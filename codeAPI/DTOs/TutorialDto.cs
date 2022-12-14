using codeLibrary.Models;
using System.Collections.Generic;

namespace codeAPI.DTOs
{
    public class TutorialDto
    {
        public int TutorialId { get; set; }
        public string TutorialName { get; set; }
        public string TutorialDescription { get; set; }
        public string TutorialLanguagePreference { get; set; }
        public int TutorialHours { get; set; }

        //Why do we need this?
        public virtual ICollection<ClientDto> Clients { get; set; }
        = new List<ClientDto>();
    }
}
