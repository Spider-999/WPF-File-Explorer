using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_File_Explorer.Models
{
    /// <summary>
    /// A class to query informations about directories
    /// </summary>
    public class DirectoryStructure
    {
        /// <summary>
        /// Gets all of the drives on the machine
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetDrives()
        {
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { fullPath = drive, directoryItemType = DirectoryItemType.Drive }).ToList();
        }

        public static List<DirectoryItem> GetDirectoryChildren(string path)
        {
            var items = new List<DirectoryItem>();

            #region Get all of the folders and subfolder
            try
            {
                var systemDirectories = Directory.GetDirectories(path);
                if (systemDirectories.Length > 0)
                    items.AddRange(systemDirectories.Select(systemDirectory=> new DirectoryItem { fullPath = systemDirectory, directoryItemType = DirectoryItemType.Folder }));
            }
            catch
            {

            }
            #endregion

            #region Get all of the files in the directories
            try
            {
                var systemFiles = Directory.GetFiles(path);
                if (systemFiles.Length > 0)
                    items.AddRange(systemFiles.Select(systemFile => new DirectoryItem { fullPath = systemFile, directoryItemType = DirectoryItemType.File} ));
            }
            catch
            {

            }
            #endregion

            return items;
        }
    }
}
