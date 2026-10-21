namespace WeatherForecast
{
  public partial class FormMain : Form
  {
    List<DailyConditions> dailyConditions = [];
    List<WeatherData> lastResponse = [];
    readonly WebApi webApi = new();

    public FormMain()
    {
      InitializeComponent();

      comboBoxCity.Text = Properties.Settings.Default.City;

      // the UserControls for each day in the 7-day forecast
      dailyConditions.AddRange(
        [
          dailyConditions1, dailyConditions2, dailyConditions3, dailyConditions4,
          dailyConditions5, dailyConditions6, dailyConditions7
        ]);
    }

    async void ButtonSearch_Click(object sender, EventArgs e)
    {
      if (comboBoxCity.SelectedItem is City) return;  // the result of a previous search

      Properties.Settings.Default.City = comboBoxCity.Text;
      Properties.Settings.Default.Save();

      await PerformCityLookupAsync();
    }

    async void ComboBoxCity_SelectionChangeCommitted(object sender, EventArgs e)
    {
      if (comboBoxCity.SelectedItem is not City city) return;

      await LoadWeatherDataAsync(city);
    }

    void RadioButtonCelsius_CheckedChanged(object sender, EventArgs e)
    {
      if (lastResponse == null) return;

      ShowWeatherData(lastResponse);
    }

    async Task PerformCityLookupAsync()
    {
      if (comboBoxCity.SelectedItem is City selectedCity)
      {
        // lookup already performed. Show weather for selected city
        await LoadWeatherDataAsync(selectedCity);
        return;
      }

      string query = comboBoxCity.Text.Trim();
      if (string.IsNullOrEmpty(query))
      {
        MessageBox.Show("Enter a city name.", "No City Entered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      labelStatusMessage.Text = $"Finding matching cities...";
      comboBoxCity.Items.Clear();

      try
      {
        buttonSearch.Enabled = false;
        UseWaitCursor = true;

        List<City> cities = await webApi.LookupCities(query);

        UseWaitCursor = false;
        buttonSearch.Enabled = true;

        if (cities.Count == 0)
        {
          labelStatusMessage.Text = "No matching cities found";
          return;
        }

        // add matching cities to dropdown
        foreach (var city in cities)
          comboBoxCity.Items.Add(city);

        SelectFirstCityFound();

        labelStatusMessage.Text = $"Matching cities found: {cities.Count}";
      }
      catch (Exception ex)
      {
        labelStatusMessage.Text = $"City lookup failed ({ex.Message}).";
      }
      finally
      {
        UseWaitCursor = false;
        buttonSearch.Enabled = true;
      }
    }

    // updates the combobox after a brief delay, to allow pending message-loop operations to complete
    void SelectFirstCityFound()
    {
      System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
      timer.Interval = 5; // 5 ms

      timer.Tick += (s, e) =>
      {
        timer.Stop();
        timer.Dispose();

        // select the first match and open dropdown
        comboBoxCity.SelectedIndex = 0;
        comboBoxCity.DroppedDown = true;
      };

      timer.Start();
    }

    async Task LoadWeatherDataAsync(City city)
    {
      UseWaitCursor = true;
      buttonSearch.Enabled = false;

      labelStatusMessage.Text = $"Fetching weather data for {city.Name}, {city.Admin} ({city.Country})..";

      try
      {
        // get the weather data and display it
        List<WeatherData> list = await webApi.GetWeatherData(city);
        ShowWeatherData(list);

        labelWeatherForCity.Text = $"Weather for {city.Name}, {city.Admin} ({city.Country})";
        labelStatusMessage.Text = $"Forecast updated at {DateTime.Now:T}";
      }
      catch (Exception ex)
      {
        labelStatusMessage.Text = $"Failed to load weather data ({ex.Message})";
      }
      finally
      {
        UseWaitCursor = false;
        buttonSearch.Enabled = true;
      }
    }

    void ShowWeatherData(List<WeatherData> weatherData)
    {
      lastResponse = weatherData;

      if (weatherData.Count == 0) return;

      bool isCelsius = radioButtonCelsius.Checked;

      for (int i = 0; i < weatherData.Count; i++)
        dailyConditions[i].SetWeatherData(weatherData[i], isCelsius);

      panelMiddle.Visible = true; // to make results visible
    }

    new bool UseWaitCursor
    {
      get { return base.UseWaitCursor; }
      set
      {
        base.UseWaitCursor = value;
        Cursor.Position = Cursor.Position;  // to update occasional "stuck" busy cursors
      }
    }
  }
}
