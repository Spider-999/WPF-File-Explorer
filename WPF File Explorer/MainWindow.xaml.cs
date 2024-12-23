using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;


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
        }
        #endregion

        #region On Load
        /// <summary>
        /// Get every drive on the computer, create a new item for it
        /// and then add it to the main tree view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var drives = Directory.GetLogicalDrives();
            foreach(var drive in drives)
            {
                var treeItem = new TreeViewItem();
                // Header
                treeItem.Header = drive;
                // Full path
                treeItem.Tag = drive;
                // Add a null item to get the ability to expand the tree view
                treeItem.Items.Add(null);
                treeItem.Expanded += FolderView_Expanded;
                FolderView.Items.Add(treeItem);
            }
        }
        #endregion

        /// <summary>
        /// Get all the children of the parent folder when expanded, repeat for every folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderView_Expanded(object sender, RoutedEventArgs e)
        {
            // Sender of the event
            var treeItem = (TreeViewItem)sender;
            // Get the full path of the sender, for example the drive located at C:
            var fullPath = (string)treeItem.Tag;
            var directories = new List<string>();
            if (treeItem.Items.Count != 1 || treeItem.Items[0] != null)
                return;
            treeItem.Items.Clear();
            #region Get all of the directories on the system
            try
            {
                var systemDirectories = Directory.GetDirectories(fullPath);
                if (systemDirectories.Length > 0)
                    directories.AddRange(systemDirectories);
            }
            catch
            {

            }

            directories.ForEach(directoryPath => 
            {
                var subdirTreeItem = new TreeViewItem()
                {
                    // Header is the folder name
                    Header = Path.GetFileName(directoryPath),
                    // Tag is the full system path
                    Tag = directoryPath
                };
                // Add a null item to get the ability to expand the tree view
                subdirTreeItem.Items.Add(null);

                // Handle the expansion of every item
                subdirTreeItem.Expanded += FolderView_Expanded;
                // Add the item to the parent item
                treeItem.Items.Add(subdirTreeItem);
            });
            #endregion

            #region Get all of the files in the directories
            var files = new List<string>();
            try
            {
                var systemFiles = Directory.GetFiles(fullPath);
                if (systemFiles.Length > 0)
                    files.AddRange(systemFiles);
            }
            catch
            {

            }

            files.ForEach(filePath =>
            {
                var subdirTreeItem = new TreeViewItem()
                {
                    // Header is the file name
                    Header = Path.GetFileName(filePath),
                    // Tag is the full system path
                    Tag = filePath
                };
               
                // Add the item to the parent item
                treeItem.Items.Add(subdirTreeItem);
            });
            #endregion
        }
    }
}