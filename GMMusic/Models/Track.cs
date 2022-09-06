using System;
using System.Collections.Generic;

namespace GMMusic.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string SourcePath { get; set; }
        public bool  IsAmbience { get; set; }

        public virtual List<Tag> Tags { get; set; } = new List<Tag>();
        public virtual List<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}
