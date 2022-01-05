using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_1_backend.Config.Models
{
    public class MeasurementMessage
    {
        public Guid SensorID { get; set; }
        public float Value { get; set; }
        public long TimeStamp { get; set; }
    }
}
