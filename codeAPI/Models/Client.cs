using System;
using System.Collections.Generic;

#nullable disable

namespace codeLibrary.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientTutorials = new HashSet<ClientTutorial>();
        }

        public int ClientId { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPassword { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ClientAddress { get; set; }
        public string ClientPostalzip { get; set; }
        public int TutorialId { get; set; }

        public virtual Tutorial Tutorial { get; set; }
        public virtual ICollection<ClientTutorial> ClientTutorials { get; set; }
    }
}
