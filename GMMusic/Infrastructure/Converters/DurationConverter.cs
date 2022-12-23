using GMMusic.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GMMusic.Infrastructure.Converters
{
    internal class DurationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double pos = (double)value;
            return System.Convert.ToInt32(pos);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            double progress = (double) value;
            MyMediaPlayer player = parameter as MyMediaPlayer;
            player.Position = TimeSpan.FromSeconds(System.Convert.ToInt32(player.CurrentTrack.Duration.TotalSeconds * progress));
            return player;
        }
    }
}
