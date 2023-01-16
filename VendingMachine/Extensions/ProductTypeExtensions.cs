using System.Globalization;
using VendingMachine.Converters;
using VendingMachine.Data.Entities;

namespace VendingMachine.Extensions;

public static class ProductTypeExtensions
{
    public static string ToProductIcon(this ProductType self)
    {
        var converter = new TypeToIconConverter();

        var productIcon = converter.Convert(self, typeof(string), null, CultureInfo.InvariantCulture) as string;
        
        return productIcon ?? "";
    }
}