using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace GMMusic.Models
{
    public class MyMediaPlayer : MediaPlayer
    {

        public int Id { get; set; }
        public string Text { get; set; }
        private Track _CurrentTrack;
        public Track CurrentTrack 
        { 
            get=>_CurrentTrack; 
            set
            {
                _CurrentTrack = value;
                Text = _CurrentTrack?.Name;
            }
        }
        public ICollection<Track> Tracks { get; set; } = new ObservableCollection<Track>();

        public MyMediaPlayer(int id) : base()
        {
            Id = id;
            CurrentTrack = new Track
            {
                Id = 100,
                Name = "Unnamed",
                Duration = new System.TimeSpan(1, 1, 1),
                Tags = new List<Tag>(),
                Playlists = new List<Playlist>(),
                SourcePath = "c:"
            };
        }

        public override string ToString()
        {
            return "MP " + Id.ToString();
        }
    }
}
