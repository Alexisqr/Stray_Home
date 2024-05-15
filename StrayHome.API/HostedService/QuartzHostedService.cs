using Microsoft.Extensions.Hosting;
using Quartz;
using StrayHome.Infrastructure.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.API.HostedService
{
    public class QuartzHostedService : IHostedService
    {
        private readonly IScheduler _scheduler;

        public QuartzHostedService(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _scheduler.Start();

            var job = JobBuilder.Create<UpdateListOfMissingAnimals>().Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("UpdateListOfMissingAnimals-trigger")
                .StartNow()
                .WithDailyTimeIntervalSchedule(x =>
                   x.WithIntervalInHours(24)
                   .OnEveryDay()
                   .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(14, 38))
                   .InTimeZone(TimeZoneInfo.Local)
                   )
                .Build();

            await _scheduler.ScheduleJob(job, trigger);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _scheduler.Shutdown();
        }
    }
}

