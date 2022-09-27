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
            set => Set(ref _CurrentTrack, value);
        }
        public ICollection<Track> Tracks { get; set; } = new ObservableCollection<Track>();

        public MyMediaPlayer(int id) : base()
        {
            Id = id;
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
