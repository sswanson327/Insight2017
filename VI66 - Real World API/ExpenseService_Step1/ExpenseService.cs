﻿using System.ServiceProcess;
using System.Threading;

namespace ExpenseService_Step1
{
    public partial class ExpenseService : ServiceBase
    {
        private Timer timer;
        private TimerCallback timerDelegate;
        private CronJob job;

        public ExpenseService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //initialize the job class
            job = new CronJob();
            //set the timer based on the system settings value - call the run method
            timer = new Timer(job.Run, null, 0, Properties.Settings.Default.IntervalInSeconds * 1000);
        }

        protected override void OnStop()
        {
            //dispose the timer
            timer.Dispose();
        }
    }
}
