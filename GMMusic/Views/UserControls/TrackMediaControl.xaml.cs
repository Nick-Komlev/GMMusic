using GMMusic.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GMMusic.Views.UserControls
{
    public partial class TrackMediaControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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


        public static readonly DependencyProperty MediaPlayerProperty = 
            DependencyProperty.Register(
                "MediaPlayer",
                typeof(MyMediaPlayer),
                typeof(TrackMediaControl),
                new FrameworkPropertyMetadata(
                        null,
                        FrameworkPropertyMetadataOptions.AffectsMeasure |
                        FrameworkPropertyMetadataOptions.AffectsRender,
                        new PropertyChangedCallback(OnMediaPlayerChanged),
                        new CoerceValueCallback(CoerceMediaPlayer)));       

        public MyMediaPlayer MediaPlayer
        {
            get { return (MyMediaPlayer)GetValue(MediaPlayerProperty); }
            set { SetValue(MediaPlayerProperty, value); }
        }

        private Track _TrackName;

        public Track TrackName
        {
            get => _TrackName;
            set => Set(ref _TrackName, value);
        }

        private static object CoerceMediaPlayer(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        private static void OnMediaPlayerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            return;
        }

        public TrackMediaControl()
        {
            InitializeComponent();

            TrackName = MediaPlayer?.CurrentTrack;
        }
    }
}
