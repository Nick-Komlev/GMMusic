using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace GMMusic.Models
{
    public class MyMediaPlayer : MediaPlayer, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        private Track _CurrentTrack;
        public Track CurrentTrack 
        {
            get => _CurrentTrack;
            set
            {
                Set(ref _CurrentTrack, value);
                if (!(value is null))
                {
                    try
                    {
                        Open(new Uri(_CurrentTrack.SourcePath));
                        if (IsPlaying) Play();
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат или путь файла");
                    }
                }
            }
        }
        public ICollection<Track> Tracks { get; set; } = new ObservableCollection<Track>();

        private bool _IsPlaying = false;
        public bool IsPlaying
        {
            get => _IsPlaying;
            set => Set(ref _IsPlaying, value);
        }

        private bool _IsRepeating = false;
        public bool IsRepeating 
        { 
            get => _IsRepeating; 
            set => Set(ref _IsRepeating, value); 
        }

        public MyMediaPlayer(int id) : base()
        {
            Id = id;
            MediaEnded += MyMediaPlayer_MediaEnded;
        }

        private void MyMediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            if (!IsRepeating)
            {
                CurrentTrack = GetNextTrack();
                Open();
            }
            Position = new TimeSpan(0, 0, 0);
            Play();
        }

        private Track GetNextTrack()
        {
            var tracks = Tracks as ObservableCollection<Track>;
            var curIndex = tracks.IndexOf(CurrentTrack);
            if (curIndex == Tracks.Count - 1)
                return tracks[0];
            return tracks[curIndex + 1];
        }

        public void Open()
        {
            base.Open(new Uri(CurrentTrack.SourcePath));
        }

        public override string ToString()
        {
            return "MP " + Id.ToString();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

    }
}
