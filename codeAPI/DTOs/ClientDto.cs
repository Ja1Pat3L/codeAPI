using codeLibrary.Models;
using System.Collections.Generic;

namespace codeAPI.DTOs
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPassword { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ClientAddress { get; set; }
        public string ClientPostalzip { get; set; }
      
        public int TutorialId { get; set; }

        public virtual Tutorial Tutorial { get; set; }

        // public virtual Tutorial Tutorial { get; set; }

      /*  public virtual ICollection<ClientDto> Clients { get; set; }
       = new List<ClientDto>();
*/

    }
}
