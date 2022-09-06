using System;
using System.Collections.Generic;

namespace GMMusic.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Duration { get; set; }
        public string SourcePath { get; set; }
        public bool  IsAmbience { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
