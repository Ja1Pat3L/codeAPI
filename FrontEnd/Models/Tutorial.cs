using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class Tutorial
    {
        public Tutorial()
        {
            Clients = new HashSet<Client>();
            TutorialComments = new HashSet<TutorialComment>();
        }

        public int TutorialId { get; set; }
        public string TutorialName { get; set; }
        public string TutorialDescription { get; set; }
        public string TutorialLanguagePreference { get; set; }
        public int TutorialHours { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<TutorialComment> TutorialComments { get; set; }
    }
}
