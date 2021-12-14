using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class ModBusRtuCommandController : ControllerBase
    {
        IWebHostEnvironment environment;
        public ModBusRtuCommandController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        // function to check whether the user exist in the database .it will return true if user authorized for access else returns false 
        [HttpGet]
        [Route("getreaddata")]
        public string GetDataFromAddress(string address)
        {
            Console.WriteLine(address);
            return "";
        }
        [HttpGet]
        [Route("setdata")]
        public string WriteDatatoAddress(string address)
        {
            String[] writeParameters = address.Split("|");

            Console.WriteLine(writeParameters[0]);
            Console.WriteLine(writeParameters[1]);
            return "";
        }
    }
}