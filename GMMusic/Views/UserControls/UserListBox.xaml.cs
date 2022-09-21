using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GMMusic.Models;

namespace GMMusic.Views.UserControls
{
    public partial class UserListBox : UserControl
    {
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                "ItemsSource",
                typeof(ICollection<Track>),
                typeof(UserListBox),
                new FrameworkPropertyMetadata(
                        null,
                        FrameworkPropertyMetadataOptions.AffectsMeasure |
                        FrameworkPropertyMetadataOptions.AffectsRender,
                        new PropertyChangedCallback(OnItemsSourceChanged),
                        new CoerceValueCallback(CoerceItemsSource)));

        public ICollection<Track> ItemsSource
        {
            get { return (ICollection<Track>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        private static object CoerceItemsSource(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            return;
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                "SelectedItem",
                typeof(Track),
                typeof(UserListBox),
                new FrameworkPropertyMetadata(
                        null,
                        FrameworkPropertyMetadataOptions.AffectsMeasure |
                        FrameworkPropertyMetadataOptions.AffectsRender,
                        new PropertyChangedCallback(OnSelectedItemChanged),
                        new CoerceValueCallback(CoerceSelectedItem)));

        public Track SelectedItem
        {
            get { return (Track)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        private static object CoerceSelectedItem(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            return;
        }

        public UserListBox()
        {
            InitializeComponent();
        }

        private void ListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SelectedItem = ((sender as ListBox).SelectedItem as Track);
        }
    }
}
