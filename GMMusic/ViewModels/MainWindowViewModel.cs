using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMMusic.ViewModels.Base;
using GMMusic.Models;
using GMMusic.Infrastructure;

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

        public MainWindowViewModel()
        {
            Tracks = DBController.Tracks;
            Tags = DBController.Tags;
            Playlists = DBController.Playlists;        }
    }
}
