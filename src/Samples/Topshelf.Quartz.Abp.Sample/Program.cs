using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection;
using Quartz;

namespace Topshelf.Quartz.Abp.Sample
{
    class Program
    {
        static int Main(string[] args)
        {
            using (var bootstrapper = new AbpBootstrapper())
            {
                bootstrapper.Initialize();

                return (int)HostFactory.Run(x =>
                                            {
                                                x.SetServiceName("Topshelf.Quartz.Abp.SampleService");
                                                x.SetDescription("Topshelf.Quartz.Abp Sample Service");
                                                x.UseQuartzAbp(bootstrapper);
                                                x.ScheduleQuartzJobAsService(q =>
                                                              q.WithJob(() => JobBuilder.Create<SampleJob>().Build())
                                                              .AddTrigger(() => TriggerBuilder.Create()
                                                                                .WithSimpleSchedule(builder => builder
                                                                                       .WithIntervalInSeconds(30)
                                                                                       .RepeatForever())
                                                                                 .Build())
                                                 );
                                            });
            }
        }
    }

    [DependsOn(typeof(TopshelfQuartzAbpModule))]
    public class SampleAbpModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }

    public class SampleJob : IJob, ITransientDependency
    {
        private readonly SampleDependency _sampleDependency;
        public SampleJob(SampleDependency sampleDependency)
        {
            _sampleDependency = sampleDependency;
        }

        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Job executed");
            _sampleDependency.DoWork();
        }
    }

    public class SampleDependency : ITransientDependency
    {
        public void DoWork()
        {
            Console.WriteLine("Sample work");
        }
    }
}
