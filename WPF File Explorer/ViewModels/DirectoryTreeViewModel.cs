using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_File_Explorer.Models;

namespace WPF_File_Explorer.ViewModels
{
    internal class DirectoryTreeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<DirectoryItemViewModel> treeItems { get; set; }


        #region Constructor
        public DirectoryTreeViewModel()
        {
            var drives = DirectoryStructure.GetDrives();
            treeItems = new ObservableCollection<DirectoryItemViewModel>
                (
                drives.Select(drive => 
                new DirectoryItemViewModel(drive.fullPath, DirectoryItemType.Drive))
                );
        }
        #endregion
    }
}
