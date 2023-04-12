using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceProgramTask
{
    public class WeatherConverter
    {
        public WeatherConverter() { }
        int valueCounter = 0;
        public List <List<string>> UnpackWeatherData(List<string> weatherData)
        {
            List <List<string>> result = new List<List<string>>();

            foreach (string row in weatherData.Skip(1))
            {
                List<string> dataValues = new List<string>();
                List<string> values = row.Split(',').ToList();

                for (int i = 1; i < values.Count; i++)
                {
                    dataValues.Add(values[i]);
                }
                result.Add(dataValues);
                valueCounter = values.Count - 1;
            }
            return result;
        }
        public List<WeatherData> MapWeatherData(List<List<string>> result)
        {
            List<WeatherData> weatherDatasList = new List<WeatherData>();
            for (int i = 0; i < valueCounter; i++)
            {
                WeatherData weather = new WeatherData();
                weather.Id = i + 1;
                weather.Temperature = int.Parse(result[0][i]);
                weather.Wind = int.Parse(result[1][i]);
                weather.Humidity = int.Parse(result[2][i]);
                weather.Precipitation = int.Parse(result[3][i]);
                weather.Lightning = result[4][i];
                weather.Clouds = result[5][i];
                weatherDatasList.Add(weather);
            }
            return weatherDatasList;
        }
    }
}
