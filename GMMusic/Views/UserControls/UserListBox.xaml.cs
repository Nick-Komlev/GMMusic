using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GMMusic.Models;

namespace GMMusic.Views.UserControls
{

    public partial class UserListBox : UserControl, INotifyPropertyChanged
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

        public static readonly DependencyProperty TrulySelectedItemProperty =
            DependencyProperty.Register(
                "TrulySelectedItem",
                typeof(Track),
                typeof(UserListBox),
                new FrameworkPropertyMetadata(
                        null,
                        FrameworkPropertyMetadataOptions.AffectsMeasure |
                        FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                        new PropertyChangedCallback(OnTrulySelectedItemChanged),
                        new CoerceValueCallback(CoerceTrulySelectedItem)));

        public Track TrulySelectedItem
        {
            get { return (Track)GetValue(TrulySelectedItemProperty); }
            set 
            { 
                SetValue(TrulySelectedItemProperty, value);
                SelectedItem = value;
            }
        }

        private static object CoerceTrulySelectedItem(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        private static void OnTrulySelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            return;
        }

        private Track _SelectedItem;
        public Track SelectedItem
        {
            get => _SelectedItem;
            set => Set(ref _SelectedItem, value);
        }

        public UserListBox()
        {
            InitializeComponent();
        }

    }
}
