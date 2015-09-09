using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp;
using NUnit.Framework;
using Topshelf;
using Topshelf.Abp;

namespace TopShelf.Abp.Tests
{
    [TestFixture]
    public class TopshelfAbpTests
    {
        [Test]
        public void Service_Created_With_Abp_IocManager()
        {
            using (var bootstrapper = new AbpBootstrapper())
            {
                bootstrapper.Initialize();

                bool hasStarted = false;

                var host = HostFactory.New(cfg =>
                                           {
                                               cfg.UseTestHost();
                                               cfg.UseAbp(bootstrapper);
                                               cfg.Service<TestService>(svc =>
                                                                        {
                                                                            svc.ConstructUsingAbp();
                                                                            svc.WhenStarted(s => hasStarted = s.Start());
                                                                            svc.WhenStopped(s => s.Stop());
                                                                        });
                                           });

                var exitCode = host.Run();
                Assert.AreEqual(TopshelfExitCode.Ok, exitCode);
                Assert.IsTrue(hasStarted);
            }
        }
    }
}
