using GMMusic.ViewModels;
using GMMusic.Models;
using System.Windows;

namespace GMMusic
{
    /// <summary>
    /// Логика взаимодействия для TagEditor.xaml
    /// </summary>
    public partial class TagEditor : Window
    {
        public TagEditor()
        {
            InitializeComponent();
            TagEditorViewModel view = DataContext as TagEditorViewModel;
            view.ThisTag = new Tag();
        }

        public TagEditor(Tag tag)
        {
            InitializeComponent();
            TagEditorViewModel view = DataContext as TagEditorViewModel;
            view.ThisTag = tag;
        }


        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
