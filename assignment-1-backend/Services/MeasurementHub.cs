using assignment_1_backend.Models.DTOs;
using assignment_1_backend.Repositories;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace assignment_1_backend.Services
{
    public class MeasurementHub : Hub
    {
        private readonly Context context;

        public MeasurementHub(Context context)
        {
            this.context = context;
        }


        public async Task SendNotification(NotificationDTO notification)
        {
            await Clients.All.SendAsync("maximumValueExcedeed", notification);
        }

        public async Task GetConsumptionOverDays(Guid deviceId, int numberOfDays)
        {
            var dateStart = DateTimeOffset.Now.Date;
            var dateEnd = DateTimeOffset.Now.AddDays(numberOfDays).Date;


            var measurements = context.Measurments.Where(m => m.DeviceID == deviceId &&
                                                              m.TimeStamp >= dateStart &&
                                                              m.TimeStamp <= dateEnd)
                                                  .ToList()
                                                  .Select(m => new MeasurementDTO
                                                  {
                                                      KWH = m.KWH,
                                                      TimeStamp = m.TimeStamp.ToLocalTime()
                                                  })
                                                  .OrderBy(m => m.TimeStamp);
           
            await Clients.All.SendAsync("consumptionOverDays", measurements);

        }


        public async Task GetBaselineConsumption(Guid deviceId, int numberOfDays)
        {
            var dateStart = DateTimeOffset.Now.Date;
            var dateEnd = DateTimeOffset.Now.AddDays(numberOfDays).Date;


            var dbMeasurements = context.Measurments.Where(m => m.DeviceID == deviceId &&
                                                              m.TimeStamp >= dateStart &&
                                                              m.TimeStamp <= dateEnd)
                                                  .ToList()
                                                  .Select(m => new MeasurementDTO
                                                  {
                                                      KWH = m.KWH,
                                                      TimeStamp = m.TimeStamp.ToLocalTime()
                                                  })
                                                  .OrderBy(m => m.TimeStamp);



            var measurementBaseLine = new List<BaselineDTO>();


            for (int i = 0; i < 24; i++)
            {
                var measurementsPerHour = dbMeasurements.Where(m => m.TimeStamp.Hour == i)
                                                        .Select(m => m.KWH);

                if (measurementsPerHour.Any())
                {
                    measurementBaseLine.Add(new BaselineDTO
                    {
                        KWH = measurementsPerHour.Sum() / measurementsPerHour.Count(),
                        Hour = i
                    });
                }
              
            }

            await Clients.All.SendAsync("baseLineConsumption", measurementBaseLine.OrderBy(mbl=>mbl.Hour));

        }

    }
}
