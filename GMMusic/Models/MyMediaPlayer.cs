using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Threading;

namespace GMMusic.Models
{
    public class MyMediaPlayer : MediaPlayer, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        private double _CurrentPosition = 0;
        public double CurrentPosition
        {
            get => _CurrentPosition;
            set
            {
                double v = !(CurrentTrack is null) ? (value / CurrentTrack.Duration.TotalSeconds) * 1000 : 0;
                Set(ref _CurrentPosition, v);
            }
        }

        private DispatcherTimer Timer = new DispatcherTimer();

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
            Timer.Tick += Tick;
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
        }

        private void Tick(object sender, EventArgs e)
        {
            CurrentPosition = Position.TotalSeconds;
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
            CurrentPosition = 0;
            base.Open(new Uri(CurrentTrack.SourcePath));
        }

        new public void Play()
        {
            base.Play();
            Timer.Start();
        }

        new public void Pause()
        {
            base.Pause();
            Timer.Stop();
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
