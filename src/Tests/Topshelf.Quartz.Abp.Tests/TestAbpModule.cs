using System.Reflection;
using Abp.Modules;

namespace Topshelf.Quartz.Abp.Tests
{
    [DependsOn(typeof(TopshelfQuartzAbpModule))]
    public class TopshelfQuartzAbpTestModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}