using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IPOC.Authorization;

namespace IPOC
{
    [DependsOn(
        typeof(IPOCCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class IPOCApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<IPOCAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(IPOCApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
