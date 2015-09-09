using System.Collections.Specialized;
using Abp.Dependency;
using Quartz;
using Quartz.Core;
using Quartz.Impl;

namespace Topshelf.Quartz.Abp
{
    public class AbpSchedulerFactory : StdSchedulerFactory, ISingletonDependency
    {
        private readonly AbpJobFactory _abpJobFactory;

        public AbpSchedulerFactory(AbpJobFactory abpJobFactory)
        {
            _abpJobFactory = abpJobFactory;
        }

        public AbpSchedulerFactory(NameValueCollection props, AbpJobFactory abpJobFactory) : base(props)
        {
            _abpJobFactory = abpJobFactory;
        }

        protected override IScheduler Instantiate(QuartzSchedulerResources rsrcs, QuartzScheduler qs)
        {
            var scheduler = base.Instantiate(rsrcs, qs);
            scheduler.JobFactory = _abpJobFactory;
            return scheduler;
        }
    }
}