using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using NModbus;
using NModbus.Serial;
using NModbus.Utility;

namespace Backend.Controllers
{
    using System.Linq;
    using System.Runtime.CompilerServices;
    using NModbus.Logging;

    [ApiController]
    [Route("api/[controller]")]


    public class ModBusRtuCommandController : ControllerBase
    {
        IWebHostEnvironment environment;
        public ModBusRtuCommandController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }
        [HttpGet]
        [Route("getports")]
        public int GetPorts()
        {
            string[] ports = SerialPort.GetPortNames();

            Console.WriteLine("The following serial ports were found:");

            // Display each port name to the console.
            foreach (string port in ports)
            {
                Console.WriteLine(port);
            }

            return ports.Length;
        }

        // function to check whether the user exist in the database .it will return true if user authorized for access else returns false 
        [HttpGet]
        [Route("getreaddata")]
        public string GetDataFromAddress(string address)
        {
            String[] readParameters = address.Split("|");
            SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
            serialPort.PortName = "COM5";
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }
            byte slaveId = 0;
            if (readParameters[0] == "Slave 1")
            {
                slaveId = 1;
            }
            else
            {
                slaveId = 2;

            }
            var factory = new ModbusFactory();
            IModbusMaster master = factory.CreateRtuMaster(serialPort);
            var addresssOffset = 0;
            var addressVal = 0;
            ushort startAddress = 0;
            ushort[] holdingdata = { 0 };
            ushort[] inputdata = { 0 };
            bool[] coilstatus = { true };
            bool[] inputstatus = { true };
            string result = "";
            Console.WriteLine(readParameters[1]);
            if (readParameters[1] == "Coil Status")
            {
                addresssOffset = 10000;
                addressVal = addresssOffset + Convert.ToInt32(readParameters[2]);
                startAddress = Convert.ToUInt16(addressVal);
                coilstatus = master.ReadCoils(slaveId, startAddress, 1);
                result = Convert.ToString(coilstatus[0]);
            }
            else if (readParameters[1] == "Input Status")
            {
                addresssOffset = 20000;
                addressVal = addresssOffset + Convert.ToInt32(readParameters[2]);
                startAddress = Convert.ToUInt16(addressVal);
                inputstatus = master.ReadInputs(slaveId, startAddress, 1);
                result = Convert.ToString(inputstatus[0]);
            }
            else if (readParameters[1] == "Holding Registers")
            {
                addresssOffset = 40000;
                addressVal = addresssOffset + Convert.ToInt32(readParameters[2]);
                startAddress = Convert.ToUInt16(addressVal);
                Console.WriteLine(readParameters[1]);

                holdingdata = master.ReadHoldingRegisters(slaveId, startAddress, 1);
                result = Convert.ToString(holdingdata[0]);
            }
            else
            {
                addresssOffset = 30000;
                addressVal = addresssOffset + Convert.ToInt32(readParameters[2]);
                startAddress = Convert.ToUInt16(addressVal);
                Console.WriteLine(startAddress);
                inputdata = master.ReadInputRegisters(slaveId, startAddress, 1);
                result = Convert.ToString(inputdata[0]);
            }
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            return result;
        }
        [HttpGet]
        [Route("setdata")]
        public string WriteDatatoAddress(string address)
        {
            String[] writeParameters = address.Split("|");

            SerialPort serialPort = new SerialPort(); //Create a new SerialPort object.
            serialPort.PortName = "COM5";
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }
            var factory = new ModbusFactory();
            IModbusMaster master = factory.CreateRtuMaster(serialPort);
            byte slaveId = 0;
            if (writeParameters[0] == "Slave 1")
            {
                slaveId = 1;
            }
            else
            {
                slaveId = 2;

            }



            var addresssOffset = 0;
            var addressVal = 0;
            ushort startAddress = 0;
            ushort[] holdingdata = { 0 };
            ushort[] inputdata = { 0 };

            string result = "";

            if (writeParameters[1] == "Coil Status")
            {
                bool coilstatus = Convert.ToBoolean(writeParameters[3]);
                addresssOffset = 10000;
                addressVal = addresssOffset + Convert.ToInt32(writeParameters[2]);
                startAddress = Convert.ToUInt16(addressVal);
                master.WriteSingleCoil(slaveId, startAddress, coilstatus);
            }
            else if (writeParameters[1] == "Holding Registers")
            {
                holdingdata[0] = Convert.ToUInt16(writeParameters[3]);
                addresssOffset = 40000;
                addressVal = addresssOffset + Convert.ToInt32(writeParameters[2]);
                startAddress = Convert.ToUInt16(addressVal);
                master.WriteMultipleRegisters(slaveId, startAddress, holdingdata);
            }
            else
            {
                serialPort.Close();

                return "Invalid Operation";
            }
            serialPort.Close();
            return "";
        }
    }
}