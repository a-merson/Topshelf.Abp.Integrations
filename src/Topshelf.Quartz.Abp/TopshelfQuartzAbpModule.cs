using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp.Modules;
using Quartz;
using Quartz.Spi;

namespace Topshelf.Quartz.Abp
{
    public class TopshelfQuartzAbpModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.Register<ISchedulerFactory, AbpSchedulerFactory>();
            IocManager.Register<IJobFactory, AbpJobFactory>();

            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
