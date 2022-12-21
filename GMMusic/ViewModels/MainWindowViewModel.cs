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
using Microsoft.Win32;

namespace GMMusic.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public List<Track> DeletedTracks;
        public List<Tag> DeletedTags;

        #region Свойство заголовока окна

        private string _Title = "Медиаплеер GMMusic";

        /// <summary>Заголовок окна</summary>

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        #region Свойство текста статуса

        private string _State = "Готов!";

        /// <summary>Заголовок окна</summary>

        public string State
        {
            get => _State;
            set => Set(ref _State, value);
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

        #region Свойство активации кнопок удаления трэков

        private bool _CanDeleteTrack = false;

        /// <summary>Флаг возможности удаления трэков</summary>

        public bool CanDeleteTrack
        {
            get => _CanDeleteTrack;
            set => Set(ref _CanDeleteTrack, value);
        }

        #endregion

        #region Свойство активации кнопок удаления тэгов

        private bool _CanDeleteTag = false;

        /// <summary>Флаг возможности удаления трэков</summary>

        public bool CanDeleteTag
        {
            get => _CanDeleteTag;
            set => Set(ref _CanDeleteTag, value);
        }

        #endregion

        //=========   Команды ============

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
            Tag tag = p as Tag;
            if (!SelectedTags.Contains(tag))
            {
                SelectedTags.Add(tag);
            }

        }

        #endregion

        #region Команда удаления выбранного тэга из фильтра

        public ICommand TagDeleteCommand { get; set; }

        public bool CanTagDeleteCommandExecute(object p) => true;

        public void OnTagDeleteCommandExecuted(object p)
        {
            Tag tag = p as Tag;
            SelectedTags.Remove(tag);
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

        #region Команда управления активации кнопок удаления треков

        public ICommand AllowTrackDeleteCommand { get; set; }

        public bool CanAllowTrackDeleteCommandExecute(object p) => true;

        public void OnAllowTrackDeleteCommandExecuted(object p)
        {
            CanDeleteTrack = !CanDeleteTrack;
        }

        #endregion

        #region Команда управления активации кнопок удаления тэгов

        public ICommand AllowTagDeleteCommand { get; set; }

        public bool CanAllowTagDeleteCommandExecute(object p) => true;

        public void OnAllowTagDeleteCommandExecuted(object p)
        {
            CanDeleteTag = !CanDeleteTag;
        }

        #endregion

        #region Команда удаления трека

        public ICommand DeleteTrackCommand { get; set; }

        public bool CanDeleteTrackCommandExecute(object p) => true;

        public void OnDeleteTrackCommandExecuted(object p)
        {
            Track t = p as Track;
            Tracks.Remove(t);
            if (t.Id > -1)
            {
                DeletedTracks.Add(t);
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

        #region Команда выбора файла для трэка

        public ICommand ChooseFileTrackCommand { get; set; }

        public bool CanChooseFileTrackCommandExecute(object p) => true;

        public void OnChooseFileTrackCommandExecuted(object p)
        {
            Track track = p as Track;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == true)
            {
                track.Name = dialog.SafeFileName.Split('.')[0];
                track.SourcePath = dialog.FileName;
                var file = TagLib.File.Create(dialog.FileName);
                track.Duration = new TimeSpan(file.Properties.Duration.Hours, file.Properties.Duration.Minutes, file.Properties.Duration.Seconds);
            }
        }

        #endregion

        #region Команда создания нового трэка

        public ICommand AddTrackCommand { get; set; }

        public bool CanAddTrackCommandExecute(object p) => true;

        public void OnAddTrackCommandExecuted(object p)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == true)
            {
                for (int i = 0; i < dialog.FileNames.Length; i++)
                {
                    var file = TagLib.File.Create(dialog.FileNames[i]);
                    Tracks.Add(new Track(dialog.SafeFileNames[i].Split('.')[0],
                                         new TimeSpan(file.Properties.Duration.Hours, file.Properties.Duration.Minutes, file.Properties.Duration.Seconds),
                                         dialog.FileNames[i]));
                }
            }
        }

        #endregion

        #region Команда сохранения изменений треков

        public ICommand SaveTrackCommand { get; set; }

        public bool CanSaveTrackCommandExecute(object p) => true;

        public void OnSaveTrackCommandExecuted(object p)
        {
            State = "Изменения сохраняются...";
            DBController.Tracks = Tracks;
            DBController.SaveTrackChanges(DeletedTracks);
            State = "Изменения сохранены!";
        }

        #endregion

        #region Команда создания нового тэга

        public ICommand AddTagCommand { get; set; }

        public bool CanAddTagCommandExecute(object p) => true;

        public void OnAddTagCommandExecuted(object p)
        {
            TagEditor tagEdit = new TagEditor();
            if (tagEdit.ShowDialog() == true)
            {
                if (Tags.FirstOrDefault(t => t.Name == tagEdit.ThisTag.Name) == null)
                {
                    Tags.Add(tagEdit.ThisTag);
                }
            }
        }

        #endregion

        #region Команда изменения  тэга

        public ICommand EditTagCommand { get; set; }

        public bool CanEditTagCommandExecute(object p) => true;

        public void OnEditTagCommandExecuted(object p)
        {
            Tag tag = p as Tag;
            TagEditor tagEdit = new TagEditor(tag);
            if (tagEdit.ShowDialog() == false)
            {
                tag.Name = tagEdit.PrevName;
                tag.Color = tagEdit.PrevColor;
            }
            else 
            {
                try
                {
                    Tags.SingleOrDefault(t => tag.Name == t.Name);
                }
                catch
                {
                    tag.Name = tagEdit.PrevName;
                    tag.Color = tagEdit.PrevColor;
                }
            }
        }

        #endregion

        #region Команда сохранения изменений тэгов

        public ICommand SaveTagCommand { get; set; }

        public bool CanSaveTagCommandExecute(object p) => true;

        public void OnSaveTagCommandExecuted(object p)
        {
            State = "Изменения сохраняются...";
            DBController.Tags = Tags;
            DBController.SaveTagChanges(DeletedTags);
            State = "Изменения сохранены!";
        }

        #endregion

        #region Команда удаления тэга

        public ICommand DeleteTagCommand { get; set; }

        public bool CanDeleteTagCommandExecute(object p) => true;

        public void OnDeleteTagCommandExecuted(object p)
        {
            Tag t = p as Tag;
            Tags.Remove(t);
            if (t.Id > -1)
            {
                DeletedTags.Add(t);
            }
        }

        #endregion

        public MainWindowViewModel()
        {
            Tracks = new ObservableCollection<Track>(DBController.Tracks);
            Tags = new ObservableCollection<Tag>(DBController.Tags);
            Playlists = new ObservableCollection<Playlist>(DBController.Playlists);
            DeletedTracks = new List<Track>();
            DeletedTags = new List<Tag>();

            SelectedTrackMediaPlayer = MediaPlayers[0];
            TrackAddCommand = new LambdaCommand(OnTrackAddCommandExecuted, CanTrackAddCommandExecute);
            TagAddCommand = new LambdaCommand(OnTagAddCommandExecuted, CanTagAddCommandExecute);
            TagDeleteCommand = new LambdaCommand(OnTagDeleteCommandExecuted, CanTagDeleteCommandExecute);
            FilterRevealCommand = new LambdaCommand(OnFilterRevealCommandExecuted, CanFilterRevealCommandExecute);
            PlayCommand = new LambdaCommand(OnPlayCommandExecuted, CanPlayCommandExecute);
            RepeatCommand = new LambdaCommand(OnRepeatCommandExecuted, CanRepeatCommandExecute);
            SaveTrackCommand = new LambdaCommand(OnSaveTrackCommandExecuted, CanSaveTrackCommandExecute);
            ChooseFileTrackCommand = new LambdaCommand(OnChooseFileTrackCommandExecuted, CanChooseFileTrackCommandExecute);
            AddTrackCommand = new LambdaCommand(OnAddTrackCommandExecuted, CanAddTrackCommandExecute);
            AllowTrackDeleteCommand = new LambdaCommand(OnAllowTrackDeleteCommandExecuted, CanAllowTrackDeleteCommandExecute);
            AllowTagDeleteCommand = new LambdaCommand(OnAllowTagDeleteCommandExecuted, CanAllowTagDeleteCommandExecute);
            DeleteTrackCommand = new LambdaCommand(OnDeleteTrackCommandExecuted, CanDeleteTrackCommandExecute);
            AddTagCommand = new LambdaCommand(OnAddTagCommandExecuted, CanAddTagCommandExecute);
            SaveTagCommand = new LambdaCommand(OnSaveTagCommandExecuted, CanSaveTagCommandExecute);
            DeleteTagCommand = new LambdaCommand(OnDeleteTagCommandExecuted, CanDeleteTagCommandExecute);
            EditTagCommand = new LambdaCommand(OnEditTagCommandExecuted, CanEditTagCommandExecute);

        }

    }
}
