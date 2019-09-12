using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetelStockPrepareK.manager
{
    class RequestTrManager
    {
        private static RequestTrManager requestTrManager;

        Queue<Task> requestTaskQueue = new Queue<Task>();

        Thread taskWorker;      // 하루종일 요청하는 경우 3700으로 바꾸어 져야 한다.

        //public int REQUEST_DELAY = 610;
        public int REQUEST_DELAY = 3600;

        private RequestTrManager()
        {
            taskWorker = new Thread(delegate ()
            {
                while (true)
                {
                    try
                    {
                        while (requestTaskQueue.Count > 0)
                        {
                            requestTaskQueue.Dequeue().RunSynchronously();
                            Thread.Sleep(REQUEST_DELAY);
                        }
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            });
        }

        public static RequestTrManager GetInstance()
        {
            if(requestTrManager == null)
            {
                requestTrManager = new RequestTrManager();
            }
            return requestTrManager;
        }

        public void Run()
        {
            taskWorker.Start();
        }

        public void RequestTrData(Task task)
        {
            requestTaskQueue.Enqueue(task);
        }
    }
}
