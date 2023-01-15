using System;
using System.Globalization;
using System.Windows.Data;
using VendingMachine.Data.Entities;

namespace VendingMachine.Converters;

[ValueConversion(typeof(ProductType), typeof(string))]
public class TypeToIconConverter : IValueConverter
{
    private const string BASE_ICON_PATH = "pack://application:,,,/Resources/Images";
    
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value switch
        {
            ProductType.Agility => $"{BASE_ICON_PATH}/Fiol.jpg",
            ProductType.Health => $"{BASE_ICON_PATH}/Fiol2.jpg",
            ProductType.Intelligence => $"{BASE_ICON_PATH}/Fiol3.jpg",
            ProductType.Invisibility => $"{BASE_ICON_PATH}/Fiol4.jpg",
            ProductType.Strength => $"{BASE_ICON_PATH}/Green2.jpg",
            ProductType.Invulnerability => $"{BASE_ICON_PATH}/Green4.jpg",
            
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}