using Abp.Dependency;
using Topshelf.Logging;
using Topshelf.ServiceConfigurators;

namespace Topshelf.Abp
{
    public static class AbpServiceConfiguratorExtensions
    {
        public static ServiceConfigurator<T> ConstructUsingAbp<T>(this ServiceConfigurator<T> configurator) where T : class
        {
            var log = HostLogger.Get(typeof(HostConfiguratorExtensions));

            log.Info("[Topshelf.Abp] Service configured to construct using Abp.");

            configurator.ConstructUsing(serviceFactory => IocManager.Instance.Resolve<T>());

            return configurator;
        }
    }
}