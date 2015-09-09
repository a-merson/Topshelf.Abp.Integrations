using Abp.Dependency;
using Quartz;
using Topshelf.Logging;
using Topshelf.ServiceConfigurators;

namespace Topshelf.Quartz.Abp
{
    public static class AbpScheduleJobServiceConfiguratorExtensions
    {
        public static ServiceConfigurator<T> UseQuartzAbp<T>(this ServiceConfigurator<T> configurator)
            where T : class
        {
            SetupAbp();
            return configurator;
        }

        internal static void SetupAbp()
        {
            var log = HostLogger.Get(typeof(AbpScheduleJobServiceConfiguratorExtensions));

            ScheduleJobServiceConfiguratorExtensions.SchedulerFactory = () => IocManager.Instance.Resolve<ISchedulerFactory>().GetScheduler();

            log.Info("[Topshelf.Quartz.Abp] Quartz configured to construct jobs with Abp.");
        }
    }
}
