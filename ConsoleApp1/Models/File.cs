using System;
using System.Collections.Generic;

#nullable disable

namespace SpeechToText.Models
{
    public partial class File
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
