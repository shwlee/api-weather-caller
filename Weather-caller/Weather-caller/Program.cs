// See https://aka.ms/new-console-template for more information

const string baseUrl = "https://localhost:5001";
var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri(baseUrl);
var apiClient = new WeatherApiClient.Generation.WeatherApiClient(baseUrl, httpClient);
var weathers = await apiClient.GetWeatherForecastAsync();

foreach (var weather in weathers)
{
    Console.WriteLine($"{weather.Date}, {weather.Summary}, {weather.TemperatureC}, {weather.TemperatureF}");
}

Console.WriteLine();
Console.WriteLine("DONE!");