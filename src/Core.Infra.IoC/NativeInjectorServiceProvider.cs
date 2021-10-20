using Microsoft.Extensions.DependencyInjection;

namespace Core.Infra.IoC
{
    public static class NativeInjectorServiceProvider
    {
        public static ServiceProvider ServiceProvider()
        {
            var service = new ServiceCollection();
            NativeInjectorBootStrapper.RegisterServices(service);

            return service.BuildServiceProvider();
        }
    }
}
