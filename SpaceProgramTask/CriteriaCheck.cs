using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceProgramTask
{
    public class CriteriaCheck
    {
        public CriteriaCheck() { }
        public static WeatherData MostAppropriateDateFinder(List<WeatherData> weatherObjects) 
        {
            List<WeatherData> positiveDaysForLaunch = FindAppropriateDays(weatherObjects);

            if (positiveDaysForLaunch.Count == 0)
            {
                throw new Exception("There is no day that matches the rocket lauch criteria.");
            }
            else if (positiveDaysForLaunch.Count == 1) 
            {
                return positiveDaysForLaunch[0];
            }
            WeatherData mostAppropriateDay = FindMostAppropriateDateForRocketLauch(positiveDaysForLaunch);
            return mostAppropriateDay;
        }

        private static List<WeatherData> FindAppropriateDays(List<WeatherData> weatherObjects)
        {
            List<WeatherData> positiveDaysForLaunch = new List<WeatherData>();
            positiveDaysForLaunch.ForEach(x =>
            {
                if (IsInsideCriteria(x))
                    positiveDaysForLaunch.Add(x);
            });


            foreach (WeatherData weather in weatherObjects)
            {
                if (IsInsideCriteria(weather))
                {
                    positiveDaysForLaunch.Add(weather);
                }
            }
            return positiveDaysForLaunch;
        }

        private static bool IsInsideCriteria(WeatherData weather)
        {
            if (weather.Temperature >= 2 && weather.Temperature <= 31
                    && weather.Wind <= 10
                    && weather.Humidity < 60
                    && weather.Precipitation == 0
                    && weather.Lightning.Equals("No")
                    && !weather.Clouds.Equals("Cumulus") && !weather.Clouds.Equals("Nimbus"))
            {
                return true;
            }
            return false;
        }

        private static WeatherData FindMostAppropriateDateForRocketLauch(List<WeatherData> weatherData)
        {
            WeatherData mostAppropriateDate = weatherData[0];
            foreach (WeatherData weather in weatherData.Skip(1))
            {
                if ((weather.Wind + weather.Humidity) <= (mostAppropriateDate.Wind + mostAppropriateDate.Humidity))
                {
                    mostAppropriateDate = weather;
                }
            }
            return mostAppropriateDate;
        }
    }
}
