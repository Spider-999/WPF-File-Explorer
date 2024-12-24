using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WPF_File_Explorer.ViewModels;


namespace WPF_File_Explorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Default Constructor
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DirectoryTreeViewModel();
        }
        #endregion
    }
}