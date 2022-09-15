using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMMusic.ViewModels.Base;
using GMMusic.Models;
using GMMusic.Infrastructure;
using System.Windows.Media;

namespace GMMusic.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Свойство заголовока окна

        private string _Title = "Медиаплеер GMMusic";

        /// <summary>Заголовок окна</summary>

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        public List<Track> Tracks { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Playlist> Playlists { get; set; }

        public List<MyMediaPlayer> MediaPlayers { get; set; } = new List<MyMediaPlayer>() {
                                                                                            new MyMediaPlayer(0),
                                                                                            new MyMediaPlayer(1),
                                                                                            new MyMediaPlayer(2) };

        public List<List<Track>> MediaPlayerPlaylists = new List<List<Track>>() { new List<Track>(), new List<Track>(), new List<Track>()};

        public MainWindowViewModel()
        {
            Tracks = DBController.Tracks;
            Tags = DBController.Tags;
            Playlists = DBController.Playlists;        }
    }
}
