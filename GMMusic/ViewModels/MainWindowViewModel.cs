using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMMusic.ViewModels.Base;
using GMMusic.Models;
using GMMusic.Infrastructure;
using GMMusic.Infrastructure.Commands;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System.Collections.ObjectModel;
using Track = GMMusic.Models.Track;
using System.Windows.Controls;

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

        #region Свойство списка медиаплееров

        private ObservableCollection<MyMediaPlayer> _MediaPlayers = new ObservableCollection<MyMediaPlayer>() { 
            new MyMediaPlayer(0), 
            new MyMediaPlayer(1), 
            new MyMediaPlayer(2) };

        /// <summary>Список медиаплееров</summary>

        public ObservableCollection<MyMediaPlayer> MediaPlayers
        {
            get => _MediaPlayers;
            set => Set(ref _MediaPlayers, value);
        }

        #endregion

        #region Свойство списка трэков

        private ICollection<Track> _Tracks = new ObservableCollection<Track>();

        /// <summary>Список трэков</summary>

        public ICollection<Track> Tracks
        {
            get => _Tracks;
            set => Set(ref _Tracks, value);
        }

        #endregion

        #region Свойство списка тэгов

        private ICollection<Tag> _Tags = new ObservableCollection<Tag>();

        /// <summary>Список тэгов</summary>

        public ICollection<Tag> Tags
        {
            get => _Tags;
            set => Set(ref _Tags, value);
        }

        #endregion

        #region Свойство списка плейлистов

        private ICollection<Playlist> _Playlists = new ObservableCollection<Playlist>();

        /// <summary>Список плейлистов</summary>

        public ICollection<Playlist> Playlists
        {
            get => _Playlists;
            set => Set(ref _Playlists, value);
        }

        #endregion

        #region Свойство списка выбранных тэгов

        private ICollection<Tag> _SelectedTags = new ObservableCollection<Tag>();

        /// <summary>Список выбранных тэгов</summary>

        public ICollection<Tag> SelectedTags
        {
            get => _SelectedTags;
            set => Set(ref _SelectedTags, value);
        }



        #endregion

        #region Команда добавления выбранного трэка в плейлист медиаплеера

        public ICommand TrackAddCommand { get; set; }

        public bool CanTrackAddCommandExecute(object p) => true;

        public void OnTrackAddCommandExecuted(object p)
        {
            var t = (p as ListBoxItem).DataContext as Track;
            if (!SelectedTrackMediaPlayer.Tracks.Contains(t))
            {
                SelectedTrackMediaPlayer.Tracks.Add(t);
            }

        }

        #endregion

        #region Команда добавления выбранного тэга в фильтр

        public ICommand TagAddCommand { get; set; }

        public bool CanTagAddCommandExecute(object p) => true;

        public void OnTagAddCommandExecuted(object p)
        {
            var tag = Tags.First(t => t.Name == p.ToString());
            if (!SelectedTags.Contains(tag))
            {
                SelectedTags.Add(tag);
                OnPropertyChanged(nameof(SelectedTags));
            }

        }

        #endregion

        #region Команда удаления выбранного тэга из фильтра

        public ICommand TagDeleteCommand { get; set; }

        public bool CanTagDeleteCommandExecute(object p) => true;

        public void OnTagDeleteCommandExecuted(object p)
        {
            var tag = SelectedTags.First(t => t.Name == p.ToString());
            SelectedTags.Remove(tag);
            OnPropertyChanged(nameof(SelectedTags));

        }

        #endregion

        #region Команда управления скрытием сетки фильтра

        public ICommand FilterRevealCommand { get; set; }

        public bool CanFilterRevealCommandExecute(object p) => true;

        public void OnFilterRevealCommandExecuted(object p)
        {
            var grid = (p as UniformGrid);
            switch(grid.Visibility)
            {
                case System.Windows.Visibility.Collapsed:
                    grid.Visibility = System.Windows.Visibility.Visible;
                    break;
                case System.Windows.Visibility.Visible:
                    grid.Visibility = System.Windows.Visibility.Collapsed;
                    break;
            }

        }

        #endregion

        #region Команда play

        public ICommand PlayCommand { get; set; }

        public bool CanPlayCommandExecute(object p) => true;

        public void OnPlayCommandExecuted(object p)
        {
            var player = p as MyMediaPlayer;
            if (!player.IsPlaying)
            {
                if (!player.HasAudio)
                {
                    if (player.CurrentTrack is null)
                    {
                        if (player.Tracks.Count > 0)
                        {
                            player.CurrentTrack = player.Tracks.ElementAt(0);
                        }
                        else return;
                    }
                    player.Open();
                }
                player.Play();
                player.IsPlaying = true;
            }
            else
            {
                player.Pause();
                player.IsPlaying = false;
            }
        }

        #endregion

        #region Команда repeat

        public ICommand RepeatCommand { get; set; }

        public bool CanRepeatCommandExecute(object p) => true;

        public void OnRepeatCommandExecuted(object p)
        {
            var player = p as MyMediaPlayer;
            player.IsRepeating = !player.IsRepeating;
        }

        #endregion

        public MainWindowViewModel()
        {
            Tracks = new ObservableCollection<Track>(DBController.Tracks);
            Tags = new ObservableCollection<Tag>(DBController.Tags);
            Playlists = new ObservableCollection<Playlist>(DBController.Playlists);

            SelectedTrackMediaPlayer = MediaPlayers[0];
            TrackAddCommand = new LambdaCommand(OnTrackAddCommandExecuted, CanTrackAddCommandExecute);
            TagAddCommand = new LambdaCommand(OnTagAddCommandExecuted, CanTagAddCommandExecute);
            TagDeleteCommand = new LambdaCommand(OnTagDeleteCommandExecuted, CanTagDeleteCommandExecute);
            FilterRevealCommand = new LambdaCommand(OnFilterRevealCommandExecuted, CanFilterRevealCommandExecute);
            PlayCommand = new LambdaCommand(OnPlayCommandExecuted, CanPlayCommandExecute);
            RepeatCommand = new LambdaCommand(OnRepeatCommandExecuted, CanRepeatCommandExecute);

        }

    }
}
