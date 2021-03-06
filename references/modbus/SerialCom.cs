using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WDGModbusLibrary
{
    /// <summary>
    ///     Encapsulates SerialPort class.
    /// </summary>
    public class serialCom
    {
        private readonly SerialPort _port;       

        private readonly IObservable<byte[]> _recdBytes; // Continous stream of received modbus packets

        private const int POLL_TIME = 5; // milliseconds 
        private const int RESPONSE_TIMEOUT = 1000; // in milliseconds
        public serialCom(string comPort, int baud, Parity parity, StopBits stop)
        {
            _port = new SerialPort(comPort, baud, parity, 8, stop) {Handshake = Handshake.None, RtsEnable = true, DtrEnable = true, ReadTimeout = 800};
            _port.Open();         
            _recdBytes = Observable.Create<byte[]>(obs =>
             {
                var cancel = false;
                 Task.Factory.StartNew(async () =>
                    {
                        while (!cancel)
                        {
                            try
                            {                              
                                await TaskEx.Delay(POLL_TIME);                               
                                if (_port.BytesToRead > 0) // wait for reception to start...
                                {
                                    await TaskEx.Delay(POLL_TIME); // wait for full packet to be received - takes 2 ms                                     
                                    var b = new byte[_port.BytesToRead];
                                    _port.Read(b, 0, b.Length);
                                    Trace.Write(" Rx ");
                                    obs.OnNext(b);                                    
                                }
                            }
                            catch (Exception ex)
                            {
                                Trace.Write(ex.Message);
                                cancel = true;
                                obs.OnError(ex);
                                return;
                            }
                        }
                    });
                return (() => { cancel = true; });
            })
            ;
        }

       

        public void Dispose()
        {
            if (_port != null && _port.IsOpen)
            {
                _port.Close();
            }
        }              

        public async  Task<byte[]> SendAndGetResponseAsync(byte[] sendByteArray)
        {
            return await  await Task.Factory.StartNew( () => SendAndGetResponseAsync3(sendByteArray));                     
        }
        
        private readonly EventWaitHandle _wait = new EventWaitHandle(true, EventResetMode.AutoReset);

        private bool isRequestResponseMatched(byte[] request, byte[] response)
        {
            ///changed to 6 to 3 since the reponse for upgrade is of length 4
            if (response.Length <= 3) // response is at least 7 bytes
            {
                Trace.Write( "\t\t Recd length <= 3");
                Trace.Write(string.Format("\t\t Recd. length {0}", response.Length));
                return false;
            }
            if (request[0] != response[0]) // station addr
            {
                Trace.Write(string.Format("\t\t Recd. station address {0} Sent stn addr {1}", response[0], request[0]));
                return false;
            }
            if (request[1] != response[1]) // function code
            {
                Trace.Write(string.Format("\t\t Recd function code {0} Sent function code {1}", response[1], request[1]));
                return false;
            }

            switch (response[1])
            {
                case 0x03:
                    if (response[2] != request[5]*2)
                    {
                        Trace.Write(string.Format("\t\tRecd incorrect byte count requested for {0} regs and received {1} data bytes.", request[5], response[2]));
                        return false;
                    }
                    return true;
                case 0x10:
                    var b = request[2] == response[2] && request[3] == response[3] && request[4] == response[4]  && request[5] == response[5];
                    if (!b)
                    {
                        Trace.Write("\t\tRecd confirmation for write but start reg addr values / reg count is incorrect.");
                        return false;
                    }
                    return true;
                case 0x7E:
                    //for this command only the device address and function code is checked.
                    Trace.Write("\t\tRecd confirmation for 7E command , the sensor name and function code is same.");
                    return true;

            }
            Trace.Write(string.Format("\t\t Recd unexpeced function code {0}", response[1]));
            return false;
        }

        private async Task<byte[]> SendAndGetResponseAsync3(byte[] sendByteArray)
        {
            if (!_port.IsOpen)
                return null;
            if (_wait.WaitOne(15 * RESPONSE_TIMEOUT))
            {
                await TaskEx.Delay(5);
                _port.DiscardInBuffer();
                               
              var tcs = new TaskCompletionSource<byte[]>();
               _recdBytes.Where(x => isRequestResponseMatched(sendByteArray, x))
                   .Take(1)
                   .Timeout(TimeSpan.FromMilliseconds(RESPONSE_TIMEOUT))
                    .Subscribe(  tcs.SetResult,   // on next
                               err => {   tcs.SetResult(null); // on error                                  
                                            _wait.Set();  
                                     },
                                     () => _wait.Set()); // on completed
                                
             
                
                SendToSerialPort(sendByteArray);
                await TaskEx.Delay(5);
           
                return await tcs.Task;
            }
            return null;
        }

       
        private void SendToSerialPort(byte[] byteArray)
        {
            try
            {
                if (!_port.IsOpen)
                {
                    _port.Open();
                }
                if (_port.IsOpen)
                {                    
                    _port.Write(byteArray, 0, byteArray.Length);
                    Trace.Write(" Tx ");
                }
            }
            catch (Exception ex )
            {                
                _port.Close();
                Trace.Write(ex.Message);                
            }
        }
    }
}
