using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMMusic.ViewModels.Base;
using GMMusic.Models;
using GMMusic.Infrastructure;
using GMMusic.Infrastructure.Commands;
using System.Windows.Input;

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

        #region Свойство выбранной дорожки

        private MyMediaPlayer _SelectedTrackMediaPlayer;

        /// <summary>Выбранная дорожка</summary>

        public MyMediaPlayer SelectedTrackMediaPlayer
        {
            get => _SelectedTrackMediaPlayer;
            set => Set(ref _SelectedTrackMediaPlayer, value);
        }

        #endregion

        #region Свойство выбранного в браузере трэка

        private Track _SelectedBrowserTrack;

        /// <summary>Выбранный в браузере трэк</summary>

        public Track SelectedBrowserTrack
        {
            get => _SelectedBrowserTrack;
            set => Set(ref _SelectedBrowserTrack, value);
        }

        #endregion

        #region Команда добавления выбранного трэка в плейлист медиаплеера

        public ICommand TrackAddCommand { get; set; }

        public bool CanTrackAddCommandExecute(object p) => true;

        public void OnTrackAddCommandExecuted(object p)
        {
            if (!SelectedTrackMediaPlayer.Tracks.Contains(SelectedBrowserTrack))
            {
                SelectedTrackMediaPlayer.Tracks.Add(SelectedBrowserTrack);
            }
                
        }

        #endregion

        #region Свойство списка медиаплееров

        private List<MyMediaPlayer> _MediaPlayers = new List<MyMediaPlayer>() { 
            new MyMediaPlayer(0), 
            new MyMediaPlayer(1), 
            new MyMediaPlayer(2) };

        /// <summary>Список медиаплееров</summary>

        public List<MyMediaPlayer> MediaPlayers
        {
            get => _MediaPlayers;
            set => Set(ref _MediaPlayers, value);
        }

        #endregion

        public List<Track> Tracks { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Playlist> Playlists { get; set; }

        public MainWindowViewModel()
        {
            Tracks = DBController.Tracks;
            Tags = DBController.Tags;
            Playlists = DBController.Playlists;

            SelectedTrackMediaPlayer = MediaPlayers[0];
            TrackAddCommand = new LambdaCommand(OnTrackAddCommandExecuted, CanTrackAddCommandExecute);
        }

    }
}
