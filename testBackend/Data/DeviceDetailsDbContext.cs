using testBackend.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace testBackend.Data
{
    public class DbInitializer
    {
        public static void Initialize(DeviceDetailsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any DeviceDetailsModels.
            if (context.CPSDetails.Any())
            {
                return;   // DB has been seeded
            }

            var deviceDetailsModels = new DeviceDetailsModel[]
            {
            new DeviceDetailsModel{deviceId=1,cathodeCurrent=3.0,cathodeVolt=2.0,controlElectrodeVolt=1.0,refElectrodeVolt1=5.0,refElectrodeVolt2=5.0,refElectrodeVolt3=11.0,refElectrodeVolt4=2.9,refElectrodeVolt5=7.9,refElectrodeVolt6=4.8,refElectrodeVolt7=9.0},
            new DeviceDetailsModel{deviceId=2,cathodeCurrent=32.0,cathodeVolt=2.0,controlElectrodeVolt=1.0,refElectrodeVolt1=5.0,refElectrodeVolt2=5.0,refElectrodeVolt3=11.0,refElectrodeVolt4=2.9,refElectrodeVolt5=74.9,refElectrodeVolt6=4.8,refElectrodeVolt7=9.0},

            };
            foreach (DeviceDetailsModel s in deviceDetailsModels)
            {
                context.CPSDetails.Add(s);

            }
            context.SaveChanges();
        }
        public IList<DeviceDetailsModel> getCPSDetails(int id)
        {

            return null;
        }

    }
}