# Weather Forecast

A .Net 10 WinForms desktop app that shows a 7-day weather forecast for any major city in the world.

## Features
* Great project for getting started with online weather services.
* No dependencies on GitHub packages or third-party components.
* Uses free web service APIs from Open-Meteo.com.
* No API keys required.

The following figure shows WeatherForecast in action after entering the city name *Paris*.

<img width="812" height="572" alt="image" src="https://github.com/user-attachments/assets/af664a25-9d6f-4b1d-9576-03e08a325128" />

*Figure 1* - The app showing cities matching the name *Paris*.
<br><br>

Selecting the first entry selects Paris, France. The app then downloads and displays the forecast for that city, as shown below.

<img width="812" height="572" alt="image" src="https://github.com/user-attachments/assets/2111e4cb-ed67-4ea8-b458-80b93ce4701c" />

*Figure 2* - The forecast for Paris, France.

When you type a city in the ComboBox, WeatherForecast saves it so you don't have to type it in again on the next run of the app.

## The UI Layout

The user interface uses docked panels for the main layout, as shown in red in the following figure.

<img width="772" height="557" alt="image" src="https://github.com/user-attachments/assets/c40ff0e8-24b4-4bb5-979a-06bb770178f7" />

*Figure 3* - The docked panels for the user interface.

The red layer divides the screen vertically, with the middle area filling available space.
To achieve the required layout, the panels must be added in the proper back-to-front order, like this:

  1. PanelTop.
  2. PanelBottom.
  3. PanelMiddle.

As a general rule, components with Dock=Fill must always be added last to their parent container.

Inside PanelMiddle there are seven instances of the DailyConditions UserControl, laid out next to each other. As the name implies, DailyConditions shows the forecast data for the given data.
The following figure shows how DailyConditions looks in the Visual Studio Forms Designer.

<img width="117" height="429" alt="image" src="https://github.com/user-attachments/assets/fbb73e9c-6de8-4319-b1a8-fb8ab5822f91" />

*Figure 4* - The layout of DailyConditions in the Visual Studio Forms Designer.

To display the colored temperature bar graph, DailyConditions contains another UserControl called TemperatureBar. At design time it just appears as a bar with a gray background, as shown in the next figure. 

<img width="37" height="194" alt="image" src="https://github.com/user-attachments/assets/adf3d9f9-421f-4f81-b206-a5bc1107b35f" />

*Figure 5* - The appearance of TemperatureBar in the Visual Studio Forms Designer.

The colored gradient bar in TemperatureBar is painted at runtime in the OnPaint method, as shown later. 
<br><br>
Putting all the pieces together, the following figure shows how FormMain looks at design time.

<img width="840" height="592" alt="image" src="https://github.com/user-attachments/assets/ea5c09a8-6e32-475e-8b43-1dd6e5b4fe1f" />

*Figure 6* - The layout of FormMain in the Visual Studio Forms Designer.

## How it Works

The main form is used mainly to setup the layout and handle user interactions with the UI controls. The code deals primarily with two things:

1. Handling the **Search** button click. The app looks up cities that match the name entered and populates the ComboBox dropdown.
2. Handling a selection from the dropdown list. The app downloads and displays the forecast data for the selected city.

The following listing shows an excerpt of the **Search** button click code.

```csharp
 public partial class FormMain : Form
 {
   readonly WebApi webApi = new();

   // ...

   async void ButtonSearch_Click(object sender, EventArgs e)
   {
     if (comboBoxCity.SelectedItem is City) return;  // the result of a previous search

     Properties.Settings.Default.City = comboBoxCity.Text;
     Properties.Settings.Default.Save();

     await PerformCityLookupAsync();
   }

   async Task PerformCityLookupAsync()
   {
       List<City> cities = await webApi.LookupCities(query);
       // add matching cities to dropdown
       foreach (var city in cities)
         comboBoxCity.Items.Add(city);

       SelectFirstCityFound();
   }

    void SelectFirstCityFound()
    {
      //...
      // select the first match and open dropdown
      comboBoxCity.SelectedIndex = 0;
      comboBoxCity.DroppedDown = true;
    }
}

internal class WebApi
{
  readonly HttpClient http = new HttpClient();

  public async Task<List<City>> LookupCities(string query)
  {
    string url = $"https://geocoding-api.open-meteo.com/v1/search?" +
                 $"name={Uri.EscapeDataString(query)}&count=10&language=en&format=json";

    GeocodingResponse? response = await http.GetFromJsonAsync<GeocodingResponse>(url);

    List<City> cities = response?.Cities ?? [];
    return cities;
  }
}
```

*Listing 1* - The code to lookup cities matching a given name.

When the user selects a specific city from the dropdown, the app downloads the weather data like this:

```csharp
public partial class FormMain : Form
{
  List<DailyConditions> dailyConditions = [];
  readonly WebApi webApi = new();

  public FormMain()
  {
    InitializeComponent();

    // the UserControls for each day in the 7-day forecast
    dailyConditions.AddRange(
      [
        dailyConditions1, dailyConditions2, dailyConditions3, dailyConditions4,
        dailyConditions5, dailyConditions6, dailyConditions7
      ]);
  }

  // user selected a city from the dropdown
  async void ComboBoxCity_SelectionChangeCommitted(object sender, EventArgs e)
  {
    if (comboBoxCity.SelectedItem is not City city) return;

    await LoadWeatherDataAsync(city);
  }

  async Task LoadWeatherDataAsync(City city)
  {
      // get the weather data and display it
      List<WeatherData> list = await webApi.GetWeatherData(city);
      ShowWeatherData(list);
  }

  void ShowWeatherData(List<WeatherData> weatherData)
  {
    lastResponse = weatherData;

    if (weatherData.Count == 0) return;

    bool isCelsius = radioButtonCelsius.Checked;

    // pass the weather data to the DailyConditions controls
    for (int i = 0; i < weatherData.Count; i++)
      dailyConditions[i].SetWeatherData(weatherData[i], isCelsius);

    panelMiddle.Visible = true; // to make results visible
  }
```
*Listing 2* - The code to download and display weather data.

The  ShowWeatherData method just takes the downloaded data and passes it along to each of the seven DailyConditions UserControls. The following listing shows the code for DailyConditions.

```csharp
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
```
*Listing 3* - The code for DailyConditions.

The icon at the top is contained in an ImageList initialized at runtime from a PNG file in the app's embedded resources. The PNG has a transparent background and contains all the weather icons. It looks like this:

<img width="705" height="100" alt="image" src="https://github.com/user-attachments/assets/e2a95d1e-05b6-4c58-af94-2d1408416c28" />

*Figure 5* - The embedded resource containing all the weather icons.

The DailyConditions constructor calls LoadIconsIntoImageList which loads the PNG file and splits it into 8 separate bitmaps. Those bitmaps are then saved in a static ImageList. By being static, the ImageList is shared by all DailyConditions instances (but initialized only once).

The last piece of the puzzle is how to paint the gradient-colored temperature bar. That's handled by the TemperatureBar UserControl, whose code is shown in the next listing.

```csharp
public partial class TemperatureBar : UserControl
{
  Color lightBlue = Color.FromArgb(70, 130, 180);
  Color lightRed = Color.FromArgb(255, 107, 107);

  double low, high, weeklyLow, weeklyHigh;

  // ...

  public void SetTemperatures(WeatherData weatherData)
  {
    low = weatherData.TemperatureLow;
    high = weatherData.TemperatureHigh;
    weeklyLow = weatherData.TemperatureWeeklyLow;
    weeklyHigh = weatherData.TemperatureWeeklyHigh;

    Invalidate();
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    base.OnPaint(e);

    if (ClientRectangle.Width <= 0 || ClientRectangle.Height <= 0) return;

    Graphics g = e.Graphics;
    g.SmoothingMode = SmoothingMode.AntiAlias;

    // paint the gray background
    using var backgroundBrush = new SolidBrush(BackColor);
    g.FillRectangle(backgroundBrush, ClientRectangle);

    // determine blue-to-red gradient area

    double totalSpan = weeklyHigh - weeklyLow;
    double highOffsetPct = (weeklyHigh - high) / totalSpan;
    double lowOffsetPct = (weeklyHigh - low) / totalSpan;

    int fillTop = (int)(highOffsetPct * Height);
    int fillBottom = (int)(lowOffsetPct * Height);
    int fillHeight = Math.Max(6, fillBottom - fillTop);

    // paint the blue-to-red gradient bar
    var topLeft = new Point(0, fillTop);
    var bottomRight = new Point(0, fillTop + fillHeight);
    using var gradientBrush = new LinearGradientBrush(topLeft, bottomRight, lightRed, lightBlue);
    g.FillRectangle(gradientBrush, 0, fillTop, Width, fillHeight);
  }
}

```
*Listing 4* - The main code for TemperatureBar.

Basically DailyConditions calls TemperatureBar.SetTemperatures, which saves the various temperatures and then calls Invalidate to force a repaint. In the OnPaint method, the bar's gray background is painted first. The the colored blue-to-red gradient is painted over a portion of the background.

## Closing Notes

Contrary to what you might have expected, there is little custom painting in the app despite the rich display. There is almost no JSON-handling code. By using JSON deserialization, the downloaded weather JSON in converted immediately into C# objects, which simplify data processing. That's it folks!

Many thanks to ChatGPT for the weather icons.



