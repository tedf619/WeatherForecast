using System.Net.Http.Json;

namespace WeatherForecast;

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

  public async Task<List<WeatherData>> GetWeatherData(City city)
  {
    List<WeatherData> list = [];

    string url = $"https://api.open-meteo.com/v1/forecast?" +
           $"latitude={city.Latitude}&longitude={city.Longitude}&daily=weather_code," +
           $"temperature_2m_max,temperature_2m_min,precipitation_probability_max," +
           $"wind_speed_10m_max,cloud_cover_mean&timezone=auto";

    WeatherForecastResponse? response = await http.GetFromJsonAsync<WeatherForecastResponse>(url);
    if (response == null || response.Daily == null) return list;

    DailyWeather daily = response.Daily;

    List<string> times = daily.Time;                        // e.g. 2026-10-26
    List<int> codes = daily.WeatherCode;                    // 1..99
    List<double> temperatureHighs = daily.TemperatureHigh;   // celsius
    List<double> temperatureLows = daily.TemperatureLow;    // celsius
    List<int> precipitation = daily.PrecipitationChanceMax; // percentage
    List<double> windSpeeds = daily.WindSpeedMax;           // km/h
    List<double> cloudCovers = daily.CloudCover;            // percentage

    // copy data into more manageable WeatherData class

    for (int i = 0; i < times.Count; i++)
    {
      string dateStr = times[i] ?? "";
      DateTime date = DateTime.TryParse(dateStr, out var parsedDate) ? parsedDate : DateTime.Today.AddDays(i);

      var data = new WeatherData
      {
        Date = date,
        WeatherCode = codes[i],
        TemperatureHigh = temperatureHighs[i],
        TemperatureLow = temperatureLows[i],
        PrecipitationProbability = precipitation[i],
        WindSpeedMax = windSpeeds[i],
        CloudCoverMean = cloudCovers[i]
      };

      list.Add(data);
    }

    AddWeeklyLowHigh(list);

    return list;
  }

  void AddWeeklyLowHigh(List<WeatherData> weatherData)
  {
    double weeklyTempLow = 30, weeklyTempHigh = -30;
    for (int i = 0; i < weatherData.Count; i++)
    {
      if (weatherData[i].TemperatureLow < weeklyTempLow) weeklyTempLow = weatherData[i].TemperatureLow;
      if (weatherData[i].TemperatureHigh > weeklyTempHigh) weeklyTempHigh = weatherData[i].TemperatureHigh;
    }

    foreach (var item in weatherData)
    {
      item.TemperatureWeeklyLow = weeklyTempLow;
      item.TemperatureWeeklyHigh = weeklyTempHigh;
    }
  }
}
