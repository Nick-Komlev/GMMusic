using GMMusic.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GMMusic.Views.UserControls
{
    public partial class TrackMediaControl : UserControl
    {
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
        }
    }
}
