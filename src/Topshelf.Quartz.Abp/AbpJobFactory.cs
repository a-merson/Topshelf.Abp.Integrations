using System;
using Abp.Dependency;
using Quartz;
using Quartz.Spi;

namespace Topshelf.Quartz.Abp
{
    public class AbpJobFactory : IJobFactory, ISingletonDependency
    {
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            if (bundle == null) throw new ArgumentNullException("bundle");
            if (scheduler == null) throw new ArgumentNullException("scheduler");

            var job = (IJob)IocManager.Instance.Resolve(bundle.JobDetail.JobType);
            return job;
        }

        public void ReturnJob(IJob job)
        {
            IocManager.Instance.Release(job);
        }
    }
}