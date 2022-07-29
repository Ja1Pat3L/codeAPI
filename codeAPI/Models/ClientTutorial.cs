using System;
using System.Collections.Generic;

#nullable disable

namespace codeLibrary.Models
{
    public partial class ClientTutorial
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int? TutorialId { get; set; }

        public virtual Client Client { get; set; }
    }
}
