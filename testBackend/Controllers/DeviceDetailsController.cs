using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using testBackend.Models;
using Microsoft.AspNetCore.Hosting;
using testBackend.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace testBackend.Controllers
{


    [Route("api/[controller]")]
    public class DeviceDetailsController : ControllerBase
    {

        IWebHostEnvironment environment;
        private readonly DeviceDetailsContext deviceDetailsContext;

        public DeviceDetailsController(DeviceDetailsContext context, IWebHostEnvironment environment)
        {
            deviceDetailsContext = context;
            this.environment = environment;
        }

        [HttpGet]
        [Route("devicetype")]
        public string getCPSTypeInfo(String ID)
        {
            try
            {
                int deviceId;
                bool success = int.TryParse(ID, out deviceId);
                if (success)
                {

                }
                return "null";
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                return null;
            }
        }

        [HttpGet]
        [Route("devicedetails")]
        public async Task<IList<DeviceDetailsModel>> getCPSDetails(String ID)
        {
            try
            {
                int deviceId;
                bool success = int.TryParse(ID, out deviceId);
                IList<DeviceDetailsModel> details = null;
                if (success)
                {
                    Console.WriteLine(ID);
                    Console.WriteLine("start");
                    details = await deviceDetailsContext.CPSDetails.Where(p => p.deviceId == deviceId).ToListAsync(); ;
                    return details;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                return null;
            }
        }


    }
}
