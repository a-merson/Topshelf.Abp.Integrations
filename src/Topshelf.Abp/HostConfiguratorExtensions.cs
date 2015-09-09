using Abp;
using Topshelf.HostConfigurators;
using Topshelf.Logging;

namespace Topshelf.Abp
{
    public static class HostConfiguratorExtensions
    {
        public static HostConfigurator UseAbp(this HostConfigurator configurator, AbpBootstrapper abpBootstrapper)
        {
            var log = HostLogger.Get(typeof(HostConfiguratorExtensions));

            log.Info("[Topshelf.Abp] Integration Started in host.");

            configurator.AddConfigurator(new AbpBuilderConfigurator(abpBootstrapper));
            return configurator;
        }
    }
}