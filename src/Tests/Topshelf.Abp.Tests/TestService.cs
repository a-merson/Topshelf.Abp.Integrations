using Abp.Dependency;

namespace TopShelf.Abp.Tests
{
    public class TestService : ITransientDependency
    {
        private readonly TestDependency _testDependency;
        public TestService(TestDependency testDependency)
        {
            _testDependency = testDependency;
        }

        public bool Start()
        {
            return true;
        }

        public bool Stop()
        {
            return true;
        }
    }
}