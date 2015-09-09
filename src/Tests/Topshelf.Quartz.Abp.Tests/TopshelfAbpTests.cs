using System;
using System.Threading;
using Abp;
using Abp.Dependency;
using NUnit.Framework;
using Quartz;
using Topshelf.Quartz;
using TopShelf.Abp.Tests;

namespace Topshelf.Quartz.Abp.Tests
{
    [TestFixture]
    public class TopshelfQuartzAbpTests
    {
        [Test]
        public void Quartz_Job_Created_With_Abp_IocManager()
        {
            using (var bootstrapper = new AbpBootstrapper())
            {
                bootstrapper.Initialize();

                bool hasStarted = false;

                var host = HostFactory.New(cfg =>
                                           {
                                               cfg.UseTestHost();
                                               cfg.UseQuartzAbp(bootstrapper);
                                               cfg.ScheduleQuartzJobAsService(q => q.WithJob(() => JobBuilder.Create<TestJob>().Build())
                                                   .AddTrigger(() => TriggerBuilder.Create()
                                                       .WithSimpleSchedule(builder => builder.WithRepeatCount(0).Build()).Build()));
                                           });

                var exitCode = host.Run();
                Thread.Sleep(TimeSpan.FromSeconds(2.0));
                Assert.AreEqual(TopshelfExitCode.Ok, exitCode);
                Assert.IsTrue(TestJob.Executed);
            }
        }
    }

    public class TestJob : IJob, ITransientDependency
    {
        public static bool Executed = false;
        private readonly TestDependency _testDependency;
        public TestJob(TestDependency testDependency)
        {
            _testDependency = testDependency;
        }

        public void Execute(IJobExecutionContext context)
        {
            Executed = true;
        }
    }
}
