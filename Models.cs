using System.Text.Json.Serialization;

namespace WeatherForecast;

public class WeatherData
{
  public DateTime Date { get; set; }
  public int WeatherCode { get; set; }                    // 1..99, indicating sunny, cloudy, etc.
  public WeatherIconType WeatherType => GetWeatherType(); // e.g. WeatherIconType.Sun
  public double TemperatureHigh { get; set; }             // celsius
  public double TemperatureLow { get; set; }              // celsius
  public double PrecipitationProbability { get; set; }    // percentage
  public double WindSpeedMax { get; set; }                // km/h
  public double CloudCoverMean { get; set; }              // percentage
  public Image? Icon { get; set; }                        // e.g. icon with Sun or Cloud
  public double TemperatureWeeklyHigh { get; set; }       // celsius
  public double TemperatureWeeklyLow { get; set; }        // celsius

  WeatherIconType GetWeatherType() => WeatherCode switch
  {
    0 => WeatherIconType.Sun,
    1 or 2 => WeatherIconType.PartialSun,
    3 or 51 => WeatherIconType.Clouds,
    45 or 48 => WeatherIconType.Fog,
    53 or 55 or 61 or 80 => WeatherIconType.LightRain,
    63 or 65 or 66 or 67 or 81 or 82 => WeatherIconType.HeavyRain,
    71 or 73 or 75 or 77 => WeatherIconType.Snow,
    95 or 96 or 99 => WeatherIconType.Thunderstorm,
    _ => WeatherIconType.Clouds
  };
}

public enum WeatherIconType
{
  Sun, PartialSun, Clouds, Fog, LightRain, HeavyRain, Thunderstorm, Snow
}

/// <summary>
///  Responses from https://geocoding-api.open-meteo.com/v1/search.
/// </summary>

public class GeocodingResponse
{
  [JsonPropertyName("results")]
  public List<City>? Cities { get; set; } = [];
}

public class City
{
  [JsonPropertyName("name")]
  public string Name { get; set; } = string.Empty;  // e.g. San Francisco

  [JsonPropertyName("latitude")]
  public double Latitude { get; set; }

  [JsonPropertyName("longitude")]
  public double Longitude { get; set; }

  [JsonPropertyName("admin1")]
  public string? Admin { get; set; }   // e.g. California

  [JsonPropertyName("country")]
  public string? Country { get; set; }  // e.g. United States

  [JsonIgnore]
  public string DisplayName => string.IsNullOrEmpty(Admin)
      ? $"{Name}, {Country}"
      : $"{Name}, {Admin} ({Country})";
}

/// <summary>
///  Responses from https://api.open-meteo.com/v1/forecast.
/// </summary>

public class WeatherForecastResponse
{
  [JsonPropertyName("latitude")]
  public double Latitude { get; set; }

  [JsonPropertyName("longitude")]
  public double Longitude { get; set; }

  [JsonPropertyName("daily")]
  public DailyWeather? Daily { get; set; }
}

public class DailyWeather
{
  [JsonPropertyName("time")]
  public List<string> Time { get; set; } = new();                // e.g. "2026-10-21"

  [JsonPropertyName("weather_code")]
  public List<int> WeatherCode { get; set; } = new();            // 1..99, indicating sunny, cloudy, etc.

  [JsonPropertyName("temperature_2m_max")]
  public List<double> TemperatureHigh { get; set; } = new();     // celsius

  [JsonPropertyName("temperature_2m_min")]
  public List<double> TemperatureLow { get; set; } = new();      // celsius

  [JsonPropertyName("precipitation_probability_max")]
  public List<int> PrecipitationChanceMax { get; set; } = new(); // percentage

  [JsonPropertyName("wind_speed_10m_max")]
  public List<double> WindSpeedMax { get; set; } = new();        // km/h

  [JsonPropertyName("cloud_cover_mean")]
  public List<double> CloudCover { get; set; } = new();          // percentage
}
