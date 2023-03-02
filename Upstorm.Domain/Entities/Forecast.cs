using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upstorm.Domain.Enums;

namespace Upstorm.Domain.Entities
{
    public class Forecast
    {
        public string Main { get; set; }
        public int Humidity { get; set; }
        public float Temperature { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public float WindSpeed { get; set; }
    }
}
