using System;
using System.Threading;


namespace Backend.Services
{
    public class TimerClass
    {
        public void TimerFunction()
        {

            Console.WriteLine("timer runs");
            var autoEvent = new AutoResetEvent(true);

            var statusChecker = new StatusChecker(10);
            Console.WriteLine("{0:h:mm:ss.fff} Creating timer.\n",
                              DateTime.Now);
            var stateTimer = new Timer(statusChecker.CheckStatus,
                                       autoEvent, 0, 2000);
            //  stateTimer.AutoReset =true;
        }

        class StatusChecker
        {
            private int invokeCount;
            private int maxCount;

            public StatusChecker(int count)
            {
                invokeCount = 0;
                maxCount = count;
            }

            public void CheckStatus(Object stateInfo)
            {
                AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
                Console.WriteLine("{0} Checking status {1,2}",
                    DateTime.Now.ToString("h:mm:ss.fff"),
                    (++invokeCount).ToString());

                if (invokeCount == maxCount)
                {
                    invokeCount = 0;
                    autoEvent.Set();
                }
            }
        }
    }
}