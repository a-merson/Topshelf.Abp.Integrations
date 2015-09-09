using Abp;
using Topshelf.Abp;
using Topshelf.HostConfigurators;

namespace Topshelf.Quartz.Abp
{
    public static class AbpScheduleJobHostConfiguratorExtensions
    {
        public static HostConfigurator UseQuartzAbp(this HostConfigurator configurator, AbpBootstrapper abpBootstrapper)
        {
            configurator.UseAbp(abpBootstrapper);
            AbpScheduleJobServiceConfiguratorExtensions.SetupAbp();
            return configurator;
        }
    }
}