using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceProgramTask
{
    public class WeatherData
    {
        private int _id;
        private int _temperature;
        private int _wind;
        private int _humidity;
        private int _precipitation;
        private string _lightning;
        private string _clouds;
        public WeatherData() { }

        public int Id { get { return _id; } set { _id = value; } }
        public int Temperature { get { return _temperature; } set { _temperature = value; } }
        public int Wind { get { return _wind; } set { _wind = value; } }
        public int Humidity { get { return _humidity; } set { _humidity = value; } }
        public int Precipitation { get { return _precipitation;} set { _precipitation = value; } }
        public string Lightning { get { return _lightning; } set { _lightning = value; } }
        public string Clouds { get { return _clouds; } set { _clouds = value; } }

    }
}
