using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using DirectoryScanner.Core.Model.Impl;

namespace DirectoryScanner;

[ValueConversion(typeof(string), typeof(BitmapImage))]
public class HeaderToImageConverter : IValueConverter
{
    public static HeaderToImageConverter Instance = new HeaderToImageConverter();
    
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var path = "C:\\Users\\alex\\Desktop\\Лабы 5 семестр\\СПП\\lab3\\DirectoryScanner.View\\Images\\";
        path = value is DirectoryNode ? $"{path}dir.png" : $"{path}file.png";
        var uri = new Uri(path);
        var source = new BitmapImage(uri);
        return source;
    }

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}