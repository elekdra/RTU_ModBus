// -----------------------------------------------------------------------
// <copyright file="Modbus.cs" company="Ametek">
// Copyright (c) 2012 Ametek. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Diagnostics;
using System.Threading.Tasks;

namespace WDGModbusLibrary
{
    using System;
    using System.IO.Ports;

    /// <summary>
    /// modbus class definition
    /// </summary>
    public class Modbus
    {
        #region Member Variables
      
        /// <summary>
        /// Gets or sets modbus operation status
        /// </summary>
        public string ModbusStatus { get; private set; }
        #endregion

        private const int RETRY_COUNT = 3; 
        private serialCom _serialPort;

        #region Open / Close Procedures

        /// <summary>
        /// Checks the status of COM port
        /// </summary>
        /// <returns>true = Open, false = Close</returns>
        public bool IsOpen()
        {
            if (_serialPort == null)
            {
                ModbusStatus = "Serial port not open.";
            }
            return _serialPort != null;
        }

        /// <summary>
        /// Opens the COM Port with supplied parameters
        /// </summary>
        /// <param name="portName"> COM Port name </param>
        /// <param name="baudRate"> COM Port baud rate </param>       
        /// <param name="parity"> COM Port parity </param>       
        /// <returns>true = Open success, false = Open failed</returns>
        public bool Open(string portName, int baudRate, Parity parity)
        {
            if (_serialPort != null)
            {
                _serialPort.Dispose();
            }           
            try
            {
                _serialPort = new serialCom(portName,baudRate,parity,StopBits.Two);
                                   
            }                
            catch (Exception err)
            {
                ModbusStatus = "Error opening " + portName + ": " + err.Message;
                Trace.Write(ModbusStatus + err.Message);
                return false;
            }

            ModbusStatus = portName + " opened successfully";
            return true;                      
        }

        /// <summary>
        /// Closes the COM Port
        /// </summary>
        /// <returns>true = Close successful, flase = Close failed</returns>
        public bool Close()
        {
            if (_serialPort != null)
            {             
                _serialPort.Dispose();
                _serialPort = null;
            }           
            return true;
        }
        #endregion

       
        /// <summary>
        /// function to send message and receive response byte array
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task<byte[]> DispatchToModbus(byte[] message)
        {
             for (var i = 0; i < RETRY_COUNT; i++)
             {
                var response = await _serialPort.SendAndGetResponseAsync(message);
                 if (response != null)
                 {
                     if (CheckResponse(response))
                     {
                         return response;
                     }
                     Trace.Write("\t CRC error.");
                 }
                 else
                 {
                     Trace.Write("\t No-resp ");
                 }
             }
            Trace.Write("\tretry-Over ");
            return null;
        }

        /// <summary>
        /// message packet for function code 7C.
        /// <sensor address> <0x7c> <CRC 1> <CRC 2>
        /// </summary>
        /// <param name="devAddr"></param>
        /// <param name="modbusRegAddr"></param>
        /// <param name="functioncode"></param>
        /// <returns></returns>
        public async Task<bool> CreatePayloadFunction124(int devAddr, int functioncode)
        {
            Trace.Write(string.Format("creating packet for command 7C"));
            var message = new byte[4];

            message[0] = (byte)devAddr;// Device_address
            message[1] = (byte)functioncode; // Function_code = 7C            
            
            var crc = GetCRC(message);
            message[message.Length - 2] = crc[0];
            message[message.Length - 1] = crc[1];
            
            Trace.Write(string.Format("Sending packet to port for command 7C"));
            if ((await DispatchToModbus(message)) != null)
            {
                Trace.Write("Write successful for command 7C.");
                ModbusStatus = "Write successful";
                return true;
            }
            Trace.Write("Write time out for command 7C.No response");
            ModbusStatus = "Error in write event for command 7C.";
            return false;
        }

        /// <summary>
        /// message packet for function code 7E.
        /// <sensor address> <0x7e> <bytes read msb> <bytes read lsb> <data (bytes read)> <CRC 1> <CRC 2>
        /// </summary>
        /// <param name="devAddr"></param>
        /// <param name="modbusRegAddr"></param>
        /// <param name="numRegs"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public async Task<bool> CreatePayloadFunction126(int devAddr, int byteCount, byte[] values)
        {
            if (!IsOpen())
                return false;
            
            Trace.Write(string.Format("creating packet for command 7E"));
            // Message is 1 addr + 1 fcn + 2 reg + 2 CRC
            var message = new byte[6 + byteCount];

            message[0] = (byte)devAddr;// Device_address
            message[1] = 126; // Function_code = 7E   
            message[2] = (byte)(byteCount >> 8);// Data[2]: quantity of registers HI
            message[3] = (byte)byteCount; // Data[3]: quantity of registers LO

            for (var i = 0; i < byteCount; i++)  // Put write values into message prior to sending:
            {
                message[4 + i] = (byte)values[i];
            }
            var crc = GetCRC(message);
            message[message.Length - 2] = crc[0];
            message[message.Length - 1] = crc[1];

            Trace.Write(string.Format("Sending packet to port for command 7E, message byte is {0}, byte count is {1}", message.Length,byteCount));
            if ((await DispatchToModbus(message)) != null)
            {
                Trace.Write("Write successful for command 7E.");
                ModbusStatus = "Write successful";
                return true;
            }

            Trace.Write("Write time out for command 7E.");
            ModbusStatus = "Error in write event ";
            return false;
        }

        /// <summary>
        /// CreatePayloadFunction16:
        /// Creates payload in modbus format using the 
        /// input parameters. 
        /// Format of payload:
        /// -----------------------------------------------
        /// | Device_address | Function_code | Data | CRC |
        /// -----------------------------------------------
        /// </summary>
        /// <param name="devAddr"> device address </param>
        /// <param name="modbusRegAddr"> start register address </param>
        /// <param name="numRegs"> number of registers to write </param>
        /// <param name="values"> values of registers </param>
        /// <returns>true= msg sent successfully, false = timeout error</returns>
        public async Task<bool> CreatePayloadFunction16(int devAddr,int modbusRegAddr,int numRegs,ushort[] values)
        {
            if (!IsOpen())
                return false;
           
            // Message is 1 addr + 1 fcn + 2 start + 2 reg + 1 count + 2 * reg vals + 2 CRC
            var message = new byte[9 + (2 * numRegs)];
           
            message[0] = (byte)devAddr;// Device_address
            message[1] = 16; // Function_code = 16            
            message[2] = (byte)(modbusRegAddr >> 8); // Data[0]: starting address HI
            message[3] = (byte)modbusRegAddr;// Data[1]: starting address LO
            message[4] = (byte)(numRegs >> 8);// Data[2]: quantity of registers HI
            message[5] = (byte)numRegs; // Data[3]: quantity of registers LO
            message[6] = (byte)(numRegs * 2);  // Data[4]: bytecount 
            for (var i = 0; i < numRegs; i++)  // Put write values into message prior to sending:
            {
                message[7 + (2 * i)] = (byte)(values[i] >> 8);
                message[8 + (2 * i)] = (byte)values[i];
            }
            var crc = GetCRC(message);
            message[message.Length - 2] = crc[0];
            message[message.Length - 1] = crc[1];

            Trace.Write(string.Format("\t  Write to Reg {0} count {1}", modbusRegAddr,numRegs));
            if ((await DispatchToModbus(message)) != null)
            { 
                ModbusStatus = "Write successful";
                return true;
            }
            
            Trace.Write("\t Write time out.");
            ModbusStatus = "Error in write event " ;
            return false;
                                       
        }

        /// <summary>
        /// CreatePayloadFunction03:
        /// Creates payload in modbus format using the 
        /// input parameters. 
        /// Format of payload:
        /// -----------------------------------------------
        /// | Device_address | Function_code | Data | CRC |
        /// -----------------------------------------------
        /// </summary>
        /// <param name="devAddr"> device address </param>
        /// <param name="modbusRegAddr"> start register address </param>
        /// <param name="numRegs"> number of registers to write </param>
        /// <param name="values"> values of registers </param>
        /// <returns>true= msg sent successfully, false = timeout error</returns>
         public async Task<bool> CreatePayloadFunction03(int devAddr,int modbusRegAddr,int numRegs,ushort[] values)
        {

            if (!IsOpen())
                return false;
                           
            var message = new byte[8];  // Function 3 request is always 8 bytes:                                                
            BuildMessage((byte)devAddr, 3, (ushort)modbusRegAddr, (ushort)numRegs, ref message); // Build outgoing modbus message:
            Trace.Write(string.Format("  Read Reg {0} count {1}", modbusRegAddr, numRegs));
            var response = await DispatchToModbus(message);             
            if (response == null)
            {
                ModbusStatus = "Error in read event: ";
                Trace.Write("\t Read time out");
                return false;
            }
                         
            // Evaluate message:
            if (CheckResponse(response))
            {
                // Return requested register values:
                for (var i = 0; i < numRegs; i++)
                {
                    values[i] = response[(2 * i) + 3];
                    values[i] <<= 8;
                    values[i] += response[(2 * i) + 4];
                }

                ModbusStatus = "Read successful";
                return true;
            }
            Trace.Write("\t Read CRC error");
            ModbusStatus = "CRC error";
            return false;
        }
       

   
        #region CRC Computation
        /// <summary>
        /// Calculates the Modbus packet CRC
        /// </summary>
        /// <param name="message"> message as byte array </param>
       
        private byte[] GetCRC(byte[] message)
        {
            // Function expects a modbus message of any length 
            ushort crcFull = 0xFFFF;
          
            for (var i = 0; i < (message.Length - 2); i++)
            {
                crcFull = (ushort)(crcFull ^ message[i]);
                for (var j = 0; j < 8; j++)
                {
                    var crcLsb = (char)(crcFull & 0x0001);
                    crcFull = (ushort)((crcFull >> 1) & 0x7FFF);

                    if (crcLsb == 1)
                    {
                        crcFull = (ushort)(crcFull ^ 0xA001);
                    }
                }
            }
            var outCrc = new byte[2];
            outCrc[1] = (byte)((crcFull >> 8) & 0xFF);
            outCrc[0] = (byte)(crcFull & 0xFF);
            return outCrc;
        }
        #endregion

        #region Build Message
        /// <summary>
        /// Builds the standard modbus packer using supplied parameters
        /// </summary>
        /// <param name="address">modbus address of the device </param>
        /// <param name="type"> function type </param>
        /// <param name="start"> start register address </param>
        /// <param name="registers"> number of registers </param>
        /// <param name="message"> message array containing the modbus msg data </param>
        private void BuildMessage(byte address, byte type, ushort start, ushort registers, ref byte[] message)
        {
            message[0] = address;
            message[1] = type;
            message[2] = (byte)(start >> 8);
            message[3] = (byte)start;
            message[4] = (byte)(registers >> 8);
            message[5] = (byte)registers;

            var crc = GetCRC(message);
            message[message.Length - 2] = crc[0];
            message[message.Length - 1] = crc[1];
        }
        #endregion

        #region Check Response
        /// <summary>
        /// Gets and verifies the CRC in the response
        /// packet
        /// </summary>
        /// <param name="response"> modbus repsonse as byte array </param>
        /// <returns>true= Checksum OK, false= checksum error</returns>
        private bool CheckResponse(byte[] response)
        {
            var crc = GetCRC(response);
            return crc[0] == response[response.Length - 2] && crc[1] == response[response.Length - 1];
        }
        #endregion              
    }
}
