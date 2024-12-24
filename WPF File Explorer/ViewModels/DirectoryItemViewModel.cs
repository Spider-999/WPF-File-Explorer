using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string name { get { return Path.GetFileName(fullPath); } }
    }
}
