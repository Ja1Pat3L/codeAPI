using codeLibrary.Models;
using System;
using System.Collections.Generic;

namespace codeAPI.DTOs
{
    public class TutorialCommentDto
    {

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int? TutorialId { get; set; }
        public string TutorialComment1 { get; set; }
        public DateTime? TutorialCommentTimestamp { get; set; }

        public virtual Tutorial Tutorial { get; set; }
    }
}
