using System.Reflection;
using Abp.Modules;

namespace TopShelf.Abp.Tests
{
    public class TopshelfAbpTestModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}