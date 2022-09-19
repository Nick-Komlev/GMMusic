using System.Collections.Generic;

namespace GMMusic.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Track> Tracks { get; set; } = new List<Track>();

        public override string ToString()
        {
            return Name;
        }
    }
}
