// -----------------------------------------------------------------------
// <copyright file="ModbusExecutor.cs" company="Ametek">
// Copyright (c) 2012 Ametek. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WDGModbusLibrary
{
    /// <summary>
    ///     Class definition for Modbus Protocol Wrapper
    /// </summary>
    public class ModbusExecutor
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ModbusExecutor" /> class.
        /// </summary>
        public ModbusExecutor()
        {
            errorCodes = new ErrorCodes();

            PrefillErrorCodes();

            deviceExists = new List<Boolean>();
            for (int idx = 0; idx < 10; idx++)
            {
                deviceExists.Add(new Boolean());
                deviceExists[idx] = false;
            }
        }

        #endregion

        #region Modbus Port Properties

        /// <summary>
        ///     Sets the Modbus Port name and baudrate
        /// </summary>
        /// <param name="portName">Port Name</param>
        /// <param name="baudRate">Port Baud Rate</param>
        public void SetPort(string portName, string baudRate)
        {
            portUsed = portName;
            baudRateUsed = baudRate;
        }

        /// <summary>
        ///     Checks whether the Modbus Port is Open
        /// </summary>
        /// <returns>true= Open, false = Closed</returns>
        public bool IsOpen()
        {
            return modbusPort.IsOpen();
        }

        /// <summary>
        ///     Opens the Modbus Port for Read/Write
        /// </summary>
        /// <returns>true= Success, false= Failed</returns>
        public bool OpenPort()
        {
            var stat = modbusPort.Open(portUsed, Convert.ToInt32(baudRateUsed), Parity.None);
            modbusErrorStatus = modbusPort.ModbusStatus;
            return stat;
        }

        /// <summary>
        ///     Closes the Modbus Port
        /// </summary>
        /// <returns>true = Success, false= Failed</returns>
        public bool ClosePort()
        {
            bool stat = modbusPort.Close();
            modbusErrorStatus = modbusPort.ModbusStatus;
            return stat;
        }

        #endregion

        #region Detect Sensor Method

        /// <summary>
        ///     Checks whether sensor was found at
        ///     address passed in input to this
        ///     function
        /// </summary>
        /// <param name="address">Modbus sensor address</param>
        /// <returns>true= Sensor found, false= Sensor not found</returns>
        public Int32 IsSensorAt(Int32 address)
        {
            if (deviceExists[address])
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        ///     Force an address to exist irrespective of detect sensor
        /// </summary>
        /// <param name="address"></param>
        public void ForceSensorAt(Int32 address)
        {
            if ((address < 9) && (address > 0))
            {
                deviceExists[address] = true;
            }
        }

        /// <summary>
        ///     Detects all sensors
        ///     present between modbus address 1 and 8
        /// </summary>
        /// <returns>number of sensors detected</returns>
        public async Task<Int32> DetectSensors()
        {
            // query sensor for a few parameters
            // if the sensor responds, mark it as 
            // device exists.
            // otherwise mark it as device does 
            // not exist
            Int32 sensor_found_count = 0;
            for (byte i = 1; i < 9; i++)
            {
                float oxygen_value;
                try
                {
                    oxygen_value = await ReadFloat(i, ParamIDDefs.PARID_OXYGEN);
                }
                catch (TimeoutException)
                {
                    deviceExists[i] = false;
                    continue;
                }

                deviceExists[i] = true;
                sensor_found_count++;
            }

            return sensor_found_count;
        }

        #endregion

        #region Modbus Read Wrapper Functions

        /// <summary>
        ///     Wrapper function to get the
        ///     status of Modbus Operation
        /// </summary>
        /// <returns>status string</returns>
        public string GetStatus()
        {
            return modbusErrorStatus;
        }

        /// <summary>
        ///     Wrapper Function to read modbus registers
        /// </summary>
        /// <param name="addr">modbus address of sensor</param>
        /// <param name="pid">parameter ID to be read</param>
        /// <returns>2-byte integer value</returns>
        public async Task<UInt16> ReadInt16(byte addr, ParamIDDefs pid)
        {
            if (pid < ParamIDDefs.PARID_SENS_MAX)
            {
                ushort startreg = paramid2modbusaddrmap[(int) pid];
                var values = new ushort[1];
               
                var status = await modbusPort.CreatePayloadFunction03(addr, startreg, 1, values);
                modbusErrorStatus = modbusPort.ModbusStatus;
                if (!status)
                {
                    throw new TimeoutException("Sensor communication error!");
                }
                
                var bArray = new byte[2];
                bArray[0] = (byte) values[0];
                bArray[1] = (byte) (values[0] >> 8);
                return BitConverter.ToUInt16(bArray, 0);
                
            }
            throw new ArgumentException("ParamIDDefs");
        }


        /// <summary>
        ///     Wrapper function to read modbus register
        /// </summary>
        /// <param name="addr">modbus address of sensor</param>
        /// <param name="pid">parameter ID to be read</param>
        /// <returns>4-byte integer value</returns>
        public async Task<UInt32> ReadInt32(byte addr, ParamIDDefs pid)
        {
            if (pid < ParamIDDefs.PARID_SENS_MAX)
            {
                var startreg = paramid2modbusaddrmap[(int) pid];
                var values = new ushort[sizeof (Int32)/2];

                var status = await modbusPort.CreatePayloadFunction03(addr, startreg, sizeof(UInt32) / 2, values);
                modbusErrorStatus = modbusPort.ModbusStatus;  
                if (!status)
                {
                    throw new TimeoutException("Sensor communication error!");                              
                }
               
                modbusErrorStatus = modbusPort.ModbusStatus;
                var bArray = new byte[4];
                
                bArray[0] = (byte) values[0];
                bArray[1] = (byte) (values[0] >> 8);
                bArray[2] = (byte) values[1];
                bArray[3] = (byte) (values[1] >> 8);
                
               return BitConverter.ToUInt32(bArray, 0);               
            }           
           throw new ArgumentException("ParamIDDefs");
        }

        /// <summary>
        ///     Wrapper function to read modbus register
        /// </summary>
        /// <param name="addr">modbus address of sensor</param>
        /// <param name="pid">parameter ID to be read</param>
        /// <returns>float value</returns>
        public async Task<float> ReadFloat(byte addr, ParamIDDefs pid)
        {
            if (pid < ParamIDDefs.PARID_SENS_MAX)
            {
                var startreg = paramid2modbusaddrmap[(int) pid];
                var values = new ushort[2];
               
                var status = await modbusPort.CreatePayloadFunction03(addr, startreg, 2, values);
                modbusErrorStatus = modbusPort.ModbusStatus;
                if (!status)
                {
                    throw  new TimeoutException("Sensor communication error!");                  
                }           
                
                var bArray = new byte[4];
                {
                    bArray[0] = (byte) values[0];
                    bArray[1] = (byte) (values[0] >> 8);
                    bArray[2] = (byte) values[1];
                    bArray[3] = (byte) (values[1] >> 8);
                }
                return BitConverter.ToSingle(bArray, 0);                           
            }
            throw new ArgumentException("ParamIDDefs");
        }


        /// <summary>
        ///     Wrapper function to read modbus register
        /// </summary>
        /// <param name="addr">modbus address of sensor</param>
        /// <param name="pid">parameter ID to be read</param>
        /// <returns>float value</returns>
        public async Task<bool> CheckConnection(byte addr, ParamIDDefs pid)
        {
            if (pid < ParamIDDefs.PARID_SENS_MAX)
            {
                ushort startreg = paramid2modbusaddrmap[(int) pid];

                var values = new ushort[2];
                return await modbusPort.CreatePayloadFunction03(addr, startreg, 2, values);
            }
            return false;
        }

       

        #endregion

        #region Modbus Write Wrapper Functions

       

        /// <summary>
        ///     Write 2-byte integer value to modbus register
        /// </summary>
        /// <param name="addr">modbus address of sensor</param>
        /// <param name="pid">modbus parameter</param>
        /// <param name="data">data to write</param>
        /// <returns>true = success, false = failed</returns>
        public async Task<bool> WriteInt16(byte addr, ParamIDDefs pid, UInt16 data)
        {
            ushort startreg = paramid2modbusaddrmap[(int) pid];
            //var value = new ushort[2];
            //byte[] b_array = BitConverter.GetBytes(data);
            //value[0] = BitConverter.ToUInt16(b_array, 0);

           var status = await modbusPort.CreatePayloadFunction16(addr, startreg, 1, new[] { data });
           modbusErrorStatus = modbusPort.ModbusStatus;
           if (!status)
           {
               throw new TimeoutException("Sensor communication error!");
           }
           return true;          
        }

        /// <summary>
        ///     Write 4-byte integer value to modbus register
        /// </summary>
        /// <param name="addr">modbus address of sensor</param>
        /// <param name="pid">modbus parameter</param>
        /// <param name="data">data to write</param>
        /// <returns>true = success, false = failed</returns>
        public async Task<bool> WriteInt32(byte addr, ParamIDDefs pid, UInt32 data)
        {
            ushort startreg = paramid2modbusaddrmap[(int) pid];
            var value = new ushort[2];
            byte[] b_array = BitConverter.GetBytes(data);


            
            ushort high_byte = Convert.ToUInt16(b_array[1] << 8);
            ushort lo_byte = Convert.ToUInt16(b_array[0]);
            value[0] = Convert.ToUInt16(high_byte | lo_byte);
            high_byte = Convert.ToUInt16(b_array[3] << 8);
            lo_byte = Convert.ToUInt16(b_array[2]);
            value[1] = Convert.ToUInt16(high_byte | lo_byte);
            


            var status = await modbusPort.CreatePayloadFunction16(addr, startreg, 2, value);
            if (!status)
            {
                throw new TimeoutException("Sensor communication error!");
            }
            return true;                     
        }

        /// <summary>
        ///     Write float value to modbus register
        /// </summary>
        /// <param name="addr">modbus address of sensor</param>
        /// <param name="pid">modbus parameter</param>
        /// <param name="data">data to write</param>
        /// <returns>true = success, false = failed</returns>
        public async Task<bool> WriteFloat(byte addr, ParamIDDefs pid, float data)
        {
            ushort startreg = paramid2modbusaddrmap[(int) pid];
            var value = new ushort[2];
            byte[] b_array = BitConverter.GetBytes(data);


            {
                ushort high_byte = Convert.ToUInt16(b_array[1] << 8);
                ushort lo_byte = Convert.ToUInt16(b_array[0]);
                value[0] = Convert.ToUInt16(high_byte | lo_byte);
                high_byte = Convert.ToUInt16(b_array[3] << 8);
                lo_byte = Convert.ToUInt16(b_array[2]);
                value[1] = Convert.ToUInt16(high_byte | lo_byte);
            }

             var status = await modbusPort.CreatePayloadFunction16(addr, startreg, 2, value);
             if (!status)
             {
                 throw new TimeoutException("Sensor communication error!");
             }
             return true;          
        }

        /// <summary>
        /// function called to upgrade the firmware.
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="regAdd"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> UpgradeFirmware(byte addr, byte[] data)
        {
            var status = await modbusPort.CreatePayloadFunction126(addr, data.Length, data);
            if (!status)
            {
                Trace.Write(string.Format("download of file failed for command 7E in ModExceutor"));
                throw new TimeoutException("Sensor communication error!");
            }
            return true;
        }

        #endregion

        #region GUI Delegate Declarations

        /// <summary>
        ///     Delegate to update modbus status msg
        /// </summary>
        /// <param name="paramString">status string</param>
        public delegate void GUIStatus(string paramString);

        #endregion

        #region Error Codes Initializer

        /// <summary>
        ///     Fills error codes into the error list
        ///     and assigns error description texts
        /// </summary>
        private void PrefillErrorCodes()
        {
            errorCodes.ErrList = new CloneableList<ErrorValue>();

            errorCodes.ErrList.Add(new ErrorValue("E1000", "No Serial Port Found!"));
            errorCodes.ErrList.Add(new ErrorValue("E1001", "Serial Port Null!"));
            errorCodes.ErrList.Add(new ErrorValue("E1002", "Couldn't open Serial Port!"));
            errorCodes.ErrList.Add(new ErrorValue("E1003", "Couldn't close Serial Port!"));
            errorCodes.ErrList.Add(new ErrorValue("E1004", "Couldn't read from Serial Port!"));
            errorCodes.ErrList.Add(new ErrorValue("E1005", "Couldn't write to Serial Port!"));
            errorCodes.ErrList.Add(new ErrorValue("E1006", "Serial Port Read Timeout!"));
            errorCodes.ErrList.Add(new ErrorValue("E1007", "Serial Port Write Timeout!"));

            errorCodes.ErrList.Add(new ErrorValue("E2000", "Undefined"));
            errorCodes.ErrList.Add(new ErrorValue("E2001", "Couldn't read from Mobdus!"));
            errorCodes.ErrList.Add(new ErrorValue("E2002", "Couldn't write to Mobdus!"));
            errorCodes.ErrList.Add(new ErrorValue("E2003", "Invalid Modbus Checksum!"));

            errorCodes.ErrList.Add(new ErrorValue("E3000", "Sensor Not Found!"));
            errorCodes.ErrList.Add(new ErrorValue("E3001", "Sensor Communication Error!"));
        }

        #endregion

        #region Delegate Functions

        /// <summary>
        ///     Updates the error status string
        ///     This function is Thread safe
        /// </summary>
        /// <param name="paramString">status string</param>
        private void DoGUIStatus(string paramString)
        {
            modbusErrorStatus = paramString;
        }

        #endregion

        #region Member Variables

        /// <summary>
        ///     Modbus Hardware Port
        ///     used for communication
        ///     with physical device
        /// </summary>
        private readonly Modbus modbusPort = new Modbus();

        /// <summary>
        ///     String to hold modbus error status
        /// </summary>
        private string modbusErrorStatus = string.Empty;

        /// <summary>
        ///     Stores the Modbus Port name
        /// </summary>
        private string portUsed = string.Empty;

        /// <summary>
        ///     Stores the Modbus Port baud rate
        /// </summary>
        private string baudRateUsed = string.Empty;

        #region paramid to modbus address map

        /// <summary>
        ///     This array is a direct map of
        ///     modbus paramter IDs (used as array indices)
        ///     with modbus register address
        /// </summary>
        private readonly ushort[] paramid2modbusaddrmap =
        {
            0, 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60, 62, 64, 66, 68, 70,
            72, 74, 75, 76, 77, 78, 79, 80, 82, 84, 86, 88, 89, 90, 91, 92, 94, 96, 98, 99, 100, 101, 103, 105, 107, 108, 109, 110, 112, 114, 116, 117,
            119, 121, 123, 125, 127, 129, 131, 133, 135, 137, 139, 141, 143, 145, 147, 149, 151, 153, 155, 157, 159, 161, 163, 165, 167, 169, 171, 173,
            175, 177, 179, 181, 183, 185, 187, 189, 191, 193, 195, 197, 198, 199, 201, 203, 205, 207, 209, 211, 213, 215, 216, 217, 219, 221, 223, 225,
            226, 227, 229, 231, 233, 235, 237, 239, 241, 243, 245, 246, 247, 248, 250, 251, 253, 255, 257, 259, 261, 263, 265, 267, 269, 270, 271, 273,
            275, 276, 277, 279, 281, 282, 283, 285, 287, 288, 289, 291, 293, 295, 297, 298, 300, 302, 304, 306, 308, 310, 312, 314, 316, 318, 320, 321,
            323, 325, 327, 329, 331, 333, 334, 335, 336, 337, 338, 340, 342, 344, 346, 348, 350, 352, 354, 356, 358, 360, 362, 364, 366, 368, 370, 372,
            374, 376, 378, 380, 382, 384, 385, 387, 389,390,392,394,396,398,400,402
        };

        #endregion

        #region Poll min parameter List

        /// <summary>
        ///     This is a modbus register address list
        ///     used to map modbus parameter id
        ///     to register address
        /// </summary>
        private int[] polparamlist =
        {
            1, 2, 3, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15, 16, 17, 18, 29, 33, 36, 38, 39, 40, 41, 42, 44, 45, 46, 47, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62,
            63, 64, 65, 66, 67, 108, 129, 130, 131, 132, 133, 134, 135, 136, 137, 139, 145, 146, 147, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163,
            164, 168, 171, 173, 175, 177, 178, 180, 181, 184, 185, 217
        };

        #endregion

        /// <summary>
        ///     Stores a list of Error codes
        ///     used in the system
        /// </summary>
        private readonly ErrorCodes errorCodes;

        /// <summary>
        ///     Stores a flag for
        ///     each sensor which is detected
        /// </summary>
        private readonly List<Boolean> deviceExists;

        #endregion

        /// <summary>
        /// function called on start of firmware upgrde.
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="regAdd"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> WriteValueOnFirmwareUpgrade(byte addr, int functionCode)
        {
            var status = await modbusPort.CreatePayloadFunction124(addr, functionCode);
            if (!status)
            {
                Trace.Write(string.Format("\t Error for command 7C because of no response on ModExecutor"));
                throw new TimeoutException("Sensor communication error!");
            }
            return true;         
        }
    }
}