using System.Windows.Input;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;
using System.Windows.Media;
using System.Windows;
using GMMusic.Models;
using GMMusic.Views.UserControls;

namespace GMMusic.Behaviors
{
    public class ListBoxElementDoubleClickSelection : Behavior<Border>
    {
        private ListBoxItem _Element;
        private ListBox _ListBox;
        private UserListBox _UserListBox;
        private object CurrentSelection;
        bool DenySelection = false;

        protected override void OnAttached()
        {
            _Element = VisualTreeHelper.GetParent(AssociatedObject) as ListBoxItem;
            DependencyObject par = _Element;
            do
            {
                par = VisualTreeHelper.GetParent(par);
            }
            while (!(par is ListBox));
            _ListBox = par as ListBox;
            _UserListBox = (_ListBox.Parent as DockPanel).Parent as UserListBox;

            AssociatedObject.PreviewMouseLeftButtonDown += PreviewMouseLeftButtonDown;
            _ListBox.SelectionChanged += SelectionChanged;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DenySelection)
            {
                DenySelection = false;
                _ListBox.SelectedItem = CurrentSelection;
            }
        }

        private void PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount < 2)
            {
                CurrentSelection = _ListBox.SelectedItem;
                DenySelection = true;
            }
            else
            {
                _UserListBox.TrulySelectedItem = _Element.DataContext as Track;
            }
        }

        protected override void OnDetaching()
        {

        }
    }
}
