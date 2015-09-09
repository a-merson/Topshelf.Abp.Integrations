using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Dependency;
using Abp.Modules;

namespace Topshelf.Abp.Sample
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
                    x.SetServiceName("Topshelf.Abp.SampleService");
                    x.SetDescription("Topshelf.Abp Sample Service");
                    x.UseAbp(bootstrapper);
                    x.Service<SampleService>(svc =>
                                             {
                                                 svc.ConstructUsingAbp();
                                                 svc.WhenStarted(s => s.Start());
                                                 svc.WhenStopped(s => s.Stop());
                                             });
                });
            }
        }
    }

    public class SampleAbpModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }

    public class SampleService : ITransientDependency
    {
        private readonly SampleDependency _sampleDependency;
        public SampleService(SampleDependency sampleDependency)
        {
            _sampleDependency = sampleDependency;
        }

        public bool Start()
        {
            Console.WriteLine("service is started");
            return true;
        }

        public bool Stop()
        {
            Console.WriteLine("service is stopped");
            return true;
        }
    }

    public class SampleDependency : ITransientDependency
    {
        public void DoWork() { }
    }

    public class TestModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
