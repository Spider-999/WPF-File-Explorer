using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WPF_File_Explorer.Models;

namespace WPF_File_Explorer
{
    /// <summary>
    /// Set image based on path(if it's a drive, folder or file)
    /// </summary>
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = "Images/drive.png";

            switch((DirectoryItemType)value)
            {
                case DirectoryItemType.File:
                    image = "Images/file.png";
                    break;
                case DirectoryItemType.Folder:
                    image = "Images/folder_closed.png";
                    break;
                case DirectoryItemType.Drive:
                    image = "Images/drive.png";
                    break;
                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
