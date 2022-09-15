using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace GMMusic.Models
{
    public class MyMediaPlayer : MediaPlayer
    {

        public int Id { get; set; }
        public Track CurrentTrack { get; set; }
        public ICollection<Track> Tracks { get; set; } = new ObservableCollection<Track>();

        public MyMediaPlayer(int id) : base()
        {
            Id = id;
        }


        public override string ToString()
        {
            return "MP " + Id.ToString();
        }
    }
}
