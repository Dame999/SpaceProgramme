using CsvHelper;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceProgramTask
{
    public class CSVFileCreator
    {
        private const string NON_NUMBER_PARAMETER_VALUE = "-";
        private List<List<string>> data { get; set; }
        public CSVFileCreator(List<List<string>> data) 
        {
            this.data = data;
        }
        
        public void GenerateWatherReport(WeatherData mostAppropriateDay)
        {
            var temperatureValues = new List<double>();
            var windValues = new List<double>();
            var humidityValues = new List<double>();
            var precipitationValues = new List<double>();

            for (int i = 0; i < data[0].Count; i++)
            {
                temperatureValues.Add(int.Parse(data[0][i]));
                windValues.Add(int.Parse(data[1][i]));
                humidityValues.Add(int.Parse(data[2][i]));
                precipitationValues.Add(int.Parse(data[3][i]));
            }

            var weatherReportRows = new List<List<string>>();
            weatherReportRows.Add(new List<string> { "Parameter", "Average", "Max", "Min", "Median", "Most appropriate launch day parameter value" });

            weatherReportRows.Add(GetParameters("Temperature (C)", temperatureValues, mostAppropriateDay));
            weatherReportRows.Add(GetParameters("Wind (m/s)", windValues, mostAppropriateDay));
            weatherReportRows.Add(GetParameters("Humidity (%)", humidityValues, mostAppropriateDay));
            weatherReportRows.Add(GetParameters("Precipitation (%)", precipitationValues, mostAppropriateDay));

            weatherReportRows.Add(GetNonNumberParameters("Lightning", NON_NUMBER_PARAMETER_VALUE, mostAppropriateDay));
            weatherReportRows.Add(GetNonNumberParameters("Clouds", NON_NUMBER_PARAMETER_VALUE, mostAppropriateDay));


            using (var streamWriter = new StreamWriter("WeatherReport.csv"))
            using (var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                foreach (var row in weatherReportRows)
                {
                    streamWriter.WriteLine(string.Join(",", row));
                }
            }

        }
        private static List<string> GetNonNumberParameters(string parameterType, string parameterValue, WeatherData mostAppropriateDay)
        {
            return new List<string>
            {
                parameterType,
                parameterValue,
                parameterValue,
                parameterValue,
                parameterValue,
                GetMostAppropriateDayParameterValue(mostAppropriateDay, parameterType)
            };
        }

        private static List<string> GetParameters(string parameterType, List<double> parameterValues, WeatherData mostAppropriateDay)
        {
            return new List<string> {
                parameterType,
                parameterValues.Average().ToString(),
                parameterValues.Max().ToString(),
                parameterValues.Min().ToString(),
                GetMedian(parameterValues).ToString(),
                GetMostAppropriateDayParameterValue(mostAppropriateDay, parameterType)
            };
        }

        private static string GetMostAppropriateDayParameterValue(WeatherData mostApproprieteDay, string parameterType)
        {
            string parameterValue;
            switch (parameterType)
            {
                case "Temperature (C)":
                    parameterValue = mostApproprieteDay.Temperature.ToString();
                    break;
                case "Wind (m/s)":
                    parameterValue =  mostApproprieteDay.Wind.ToString();
                    break;
                case "Humidity (%)":
                    parameterValue = mostApproprieteDay.Humidity.ToString();
                    break;
                case "Precipitation (%)":
                    parameterValue = mostApproprieteDay.Precipitation.ToString();
                    break;
                case "Lightning":
                    parameterValue = mostApproprieteDay.Lightning;
                    break;
                case "Clouds":
                    parameterValue = mostApproprieteDay.Clouds;
                    break;
                default:
                    parameterValue = NON_NUMBER_PARAMETER_VALUE;
                    break;
            }
            return parameterValue;
        }
        

        private static double GetMedian(List<double> data)
        {
            var sortedData = data.OrderBy(value => value).ToList();
            var count = sortedData.Count;

            if (count % 2 == 0)
            {
                var middleIndex = count / 2;
                return (sortedData[middleIndex - 1] + sortedData[middleIndex]) / 2;
            }
            else
            {
                var middleIndex = (count - 1) / 2;
                return sortedData[middleIndex];
            }
        }

    }
}
