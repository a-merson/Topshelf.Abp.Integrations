using System.Collections.Generic;
using Abp;
using Topshelf.Builders;
using Topshelf.Configurators;
using Topshelf.HostConfigurators;

namespace Topshelf.Abp
{
    public class AbpBuilderConfigurator : HostBuilderConfigurator
    {
        private readonly AbpBootstrapper _abpBootstrapper;

        public AbpBuilderConfigurator(AbpBootstrapper abpBootstrapper)
        {
            _abpBootstrapper = abpBootstrapper;
        }

        public IEnumerable<ValidateResult> Validate()
        {
            yield break;
        }

        public HostBuilder Configure(HostBuilder builder)
        {
            return builder;
        }
    }
}