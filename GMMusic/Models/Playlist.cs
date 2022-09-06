using System.Collections.Generic;

namespace GMMusic.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Track> Tracks { get; set; } = new List<Track>();
    }
}
