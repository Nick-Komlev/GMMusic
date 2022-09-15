using System.Collections.Generic;
using System.Windows.Media;

namespace GMMusic.Models
{
    public class MyMediaPlayer : MediaPlayer
    {
        public int Id { get; set; }
        public Track CurrentTrack { get; set; }
        public List<Track> Tracks { get; set; } = new List<Track>();

        public MyMediaPlayer(int id) : base()
        {
            Id = id;
        }
    }
}
