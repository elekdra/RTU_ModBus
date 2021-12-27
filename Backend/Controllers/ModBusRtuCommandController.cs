using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO.Ports;
using NModbus;
using NModbus.Serial;
using Backend.Services;
using System.Threading.Tasks;

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
        TimerClass timerClass = new TimerClass();

        [HttpGet]
        [Route("timer")]

        public void timerAsync()
        {
            Console.WriteLine("timer is running");
            timerClass.TimerFunction();

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

            Console.WriteLine("master is at port:" + ports[0]);
            return ports.Length;
        }

        public bool checkReadParameters(string[] readValues)
        {

            Console.WriteLine(readValues[0]);
            if (readValues[0] == "" || readValues[1] == "" || readValues[2] == "")
            {
                return false;
            }

            return true;
        }

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
            bool ReadStatus = checkReadParameters(readParameters);
            if (ReadStatus)
            {
                Console.WriteLine(address);
                Console.WriteLine(readParameters[0]);
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
                master.Transport.ReadTimeout = 2000; //milliseconds
                var addresssOffset = 0;
                var addressVal = 0;
                ushort startAddress = 0;
                ushort[] holdingdata = { 0 };
                ushort[] inputdata = { 0 };
                bool[] coilstatus = { true };
                bool[] inputstatus = { true };
                string result = "";

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
                    try
                    {
                        Console.WriteLine("hold");
                        addresssOffset = 40000;
                        string[] addressValu = readParameters[2].Split(" ");
                        ushort[] hold = { };
                        foreach (var i in addressValu)
                        {
                            addressVal = addresssOffset + Convert.ToInt32(i);
                            startAddress = Convert.ToUInt16(addressVal);
                            Console.WriteLine(startAddress);
                            Console.WriteLine(slaveId);

                            holdingdata = master.ReadHoldingRegisters(slaveId, startAddress, 1);
                            var res1 = Convert.ToInt32(holdingdata[0]);
                            Decimal VALD = holdingdata[0];
                            if (VALD > 32768)
                            {
                                VALD = Convert.ToInt32(holdingdata[0]) - 65536;
                                result = result + " " + Convert.ToString(VALD);
                            }
                            else
                            {
                                result = result + " " + Convert.ToString(holdingdata[0]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error");
                        result = "Time Out Error";
                    }
                }
                else
                {
                    addresssOffset = 30000;
                    addressVal = addresssOffset + Convert.ToInt32(readParameters[2]);
                    startAddress = Convert.ToUInt16(addressVal);
                    Console.WriteLine(startAddress);
                    try
                    {
                        inputdata = master.ReadInputRegisters(slaveId, startAddress, 1);
                        result = Convert.ToString(inputdata[0]);
                    }
                    catch (Exception ex)
                    {
                        result = ex.ToString();
                    }
                }
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                return result;
            }
            else
            {
                return "Invalid Inputs";
            }
        }


        public bool checkWriteParameters(string[] writeValues)
        {
            if (writeValues[0] == "" || writeValues[1] == "" || writeValues[2] == "" || writeValues[3] == "")
            {
                return false;
            }
            return true;
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
            bool WriteStatus = checkWriteParameters(writeParameters);
            if (WriteStatus)
            {
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

                if (writeParameters[1] == "Coil Status")
                {
                    if (writeParameters[3] == "True" || writeParameters[3] == "False")
                    {
                        bool coilstatus = Convert.ToBoolean(writeParameters[3]);
                        addresssOffset = 10000;
                        addressVal = addresssOffset + Convert.ToInt32(writeParameters[2]);
                        startAddress = Convert.ToUInt16(addressVal);
                        master.WriteSingleCoil(slaveId, startAddress, coilstatus);
                    }
                    else
                    {
                        return "Invalid Data";
                    }
                }
                else if (writeParameters[1] == "Holding Registers")
                {

                    try
                    {
                        Console.WriteLine("hold");
                        addresssOffset = 40000;
                        string[] addressValu = writeParameters[2].Split(" ");
                        string[] dataValue = writeParameters[3].Split(" ");
                        ushort[] hold = { };
                        for (var i = 0; i < addressValu.Length; i++)
                        {
                            bool result;
                            int aout;
                            result = int.TryParse(dataValue[i], out aout);

                            addressVal = addresssOffset + Convert.ToInt32(addressValu[i]);
                            startAddress = Convert.ToUInt16(addressVal);
                            Console.WriteLine(startAddress);
                            Console.WriteLine(slaveId);
                            if (result)
                            {

                                holdingdata[0] = CastToUnsigned(Convert.ToInt16(dataValue[i]));

                                Console.WriteLine(holdingdata[0]);
                                master.WriteMultipleRegisters(slaveId, startAddress, holdingdata);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error");

                    }


                    // bool res;
                    // int a;
                    // res = int.TryParse(writeParameters[3], out a);
                    // if (res)
                    // {
                    //     Console.WriteLine(CastToUnsigned(Convert.ToInt16(writeParameters[3])));
                    //     holdingdata[0] = CastToUnsigned(Convert.ToInt16(writeParameters[3]));
                    //     addresssOffset = 40000;
                    //     addressVal = addresssOffset + Convert.ToInt32(writeParameters[2]);
                    //     startAddress = Convert.ToUInt16(addressVal);
                    //     Console.WriteLine(holdingdata[0]);
                    //     master.WriteMultipleRegisters(slaveId, startAddress, holdingdata);
                    // }
                    // else
                    // {
                    //     return "Invalid Data";
                    // }
                }
                else
                {
                    serialPort.Close();

                    return "Invalid Operation";
                }
                serialPort.Close();
                return "";
            }
            else
            {
                return "Invalid Inputs";
            }
        }
        private static ushort CastToUnsigned(object number)
        {
            Type type = number.GetType();
            unchecked
            {
                if (type == typeof(short)) return (ushort)(short)number;
                if (type == typeof(sbyte)) return (byte)(sbyte)number;
            }
            return 0;
        }
    }
}