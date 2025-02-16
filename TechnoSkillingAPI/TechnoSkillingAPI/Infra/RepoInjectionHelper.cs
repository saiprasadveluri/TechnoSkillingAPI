using System.Diagnostics;
using System.Reflection;
using TechnoSkillingAPI.Data;
using TechnoSkillingAPI.Repo;

namespace TechnoSkillingAPI.Infra
{
    public static class RepoInjectionHelper
    {
        public static void Inject<T,K>(this IServiceCollection service,Type repoType)
        {
            
            service.AddScoped<IRepoBase<T,K>>((srvProvider) =>
            {
                var obj= InstenceFactoryFunc<T, K>(srvProvider, repoType);
                return obj;
            });
            
        }

        public static IRepoBase<T, K>  InstenceFactoryFunc<T,K>(IServiceProvider serviceProvide, Type repoType)
        {
            var assm = Assembly.GetExecutingAssembly();
            var ctx = serviceProvide.GetService<TechnoSkillingDbContext>();
            var obj = Activator.CreateInstance(repoType,ctx);
            
            return (IRepoBase<T, K>)obj;
        }
    }
}
