namespace InkWell.MAUI.Common;

public class ImageUrlToDefaultConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	{
		var imageUrl = value as string;
		return string.IsNullOrEmpty(imageUrl) ? "dotnet_bot.png" : imageUrl;
	}

	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
