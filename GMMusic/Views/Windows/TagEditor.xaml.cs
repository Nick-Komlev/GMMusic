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
        public Tag ThisTag;

        public TagEditor()
        {
            InitializeComponent();
            TagEditorViewModel view = DataContext as TagEditorViewModel;
            ThisTag = new Tag("Новый тэг", "Зеленый - Локация");
            view.ThisTag = ThisTag;
        }

        public TagEditor(Tag tag)
        {
            InitializeComponent();
            TagEditorViewModel view = DataContext as TagEditorViewModel;
            ThisTag = tag;
            view.ThisTag = ThisTag;
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
