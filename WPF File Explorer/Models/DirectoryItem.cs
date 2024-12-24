using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_File_Explorer.Models
{
    /// <summary>
    /// Information about a directory item which can be a file, folder or drive
    /// </summary>
    public class DirectoryItem
    {
        public DirectoryItemType directoryItemType { get; set; }
        public string fullPath { get; set; }
        public string name { get { return Path.GetFileName(fullPath); } }
    }
}
