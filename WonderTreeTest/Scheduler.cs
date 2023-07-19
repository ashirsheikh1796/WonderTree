using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WonderTreeTest.Models;

namespace WonderTreeTest
{
    public class Scheduler : IDisposable
    {
        private Timer timer;
        private WonderTreeContext dbContext = new WonderTreeContext();

        public Scheduler()
        {
            
            timer = new Timer(PerformTask, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));
        }

        private void PerformTask(object state)
        {
            string timestamp = DateTime.Now.ToString("dd MMMM yyyy: HH.mm tt");

            dbContext.Logs.Add(new Log { Message = timestamp });
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.timer.Dispose();
            this.Dispose();
        }
    }
}