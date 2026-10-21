namespace WeatherForecast;

public partial class DailyConditions : UserControl
{
  static ImageList imageListIcons = new();  // shared with all DailyConditions!

  public DailyConditions()
  {
    InitializeComponent();

    LoadIconsIntoImageList();  // icons for Sunny, Cloudy, etc.
  }

  void LoadIconsIntoImageList()
  {
    if (imageListIcons.Images.Count > 0) return;  // already loaded

    imageListIcons.ImageSize = new Size(128, 128);

    using Bitmap icons = new Bitmap(Properties.Resources.WeatherIcons);  // contains 8 icons

    int numberOfIcons = 8;

    int cellWidth = icons.Width / numberOfIcons;
    int cellHeight = icons.Height;

    // extract each of the 8 icons (Sunny, Cloudy, etc) into individual Bitmaps and add to ImageList
    for (int i = 0; i < numberOfIcons; i++)
    {
      Rectangle iconRect = new Rectangle(i * cellWidth, 0, cellWidth, cellHeight);
      Bitmap subImage = icons.Clone(iconRect, icons.PixelFormat);
      imageListIcons.Images.Add(subImage);
    }
  }

  public void SetWeatherData(WeatherData weather, bool isCelsius)
  {
    if (weather == null) return;

    var tempHigh = isCelsius ? weather.TemperatureHigh : ToFahrenheit(weather.TemperatureHigh);
    var tempLow = isCelsius ? weather.TemperatureLow : ToFahrenheit(weather.TemperatureLow);

    pictureBox.Image = imageListIcons.Images[(int)weather.WeatherType];
    labelDay.Text = weather.Date == DateTime.Today ? "Today" : weather.Date.Date.ToString("ddd");
    labelDate.Text = weather.Date.ToString("MMM dd");
    labelTemperatureHigh.Text = tempHigh.ToString("F1");
    labelTemperatureLow.Text = tempLow.ToString("F1");
    labelPrecipitationsChance.Text = $"{weather.PrecipitationProbability}%";
    labelMaxWind.Text = $"{weather.WindSpeedMax:F0} km/h";
    labelCloudCover.Text = $"{weather.CloudCoverMean}%";

    temperatureBar.SetTemperatures(weather);
  }

  static double ToFahrenheit(double celsius) => 32 + (9 * celsius / 5);
}
