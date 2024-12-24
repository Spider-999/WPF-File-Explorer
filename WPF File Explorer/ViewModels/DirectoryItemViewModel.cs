using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_File_Explorer.Models;

namespace WPF_File_Explorer.ViewModels
{
    /// <summary>
    /// A view model for each system directory item
    /// </summary>
    public class DirectoryItemViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// This event fires every time a child property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        public DirectoryItemType directoryItemType { get; set; }
        public string fullPath { get; set; }
        public string name 
        { 
            get 
            {
                return directoryItemType == DirectoryItemType.Drive ? fullPath : Path.GetFileName(fullPath);
            } 
        }
        public ObservableCollection<DirectoryItemViewModel> subItems { get; set; }

        #region UI specific properties
        public bool canExpand { get { return this.directoryItemType != DirectoryItemType.File; } }
        public bool isExpanded 
        { 
            get 
            { 
                return subItems?.Count(item => item != null) > 0; 
            } 
            set 
            { 
                if (value == true)
                    ExpandDirectoryItems();
                else
                    ClearDirectoryItems();
            } 
        }
        #endregion

        #region Commands
        public ICommand expandDirectoryItemsCommand { get; set; }
        #endregion

        #region Constructor
        public DirectoryItemViewModel(string fPath, DirectoryItemType type)
        {
            expandDirectoryItemsCommand = new RelayCommand(ExpandDirectoryItems);
            fullPath = fPath;
            directoryItemType = type;

            ClearDirectoryItems();
        }
        #endregion

        #region Helper methods
        public void ExpandDirectoryItems()
        {
            // A file can't be expanded further
            if (directoryItemType == DirectoryItemType.File)
                return;

            // Find all children when the directory gets expanded
            subItems = new ObservableCollection<DirectoryItemViewModel>(
                DirectoryStructure.GetDirectoryChildren(fullPath)
                .Select
                (subItem => new DirectoryItemViewModel(subItem.fullPath, subItem.directoryItemType))
                );

        }

        public void ClearDirectoryItems()
        {
            subItems = new ObservableCollection<DirectoryItemViewModel>();

            // Show the expand item if the item is not a file
            if (directoryItemType != DirectoryItemType.File)
                subItems.Add(null);
        }
        #endregion


    }
}
