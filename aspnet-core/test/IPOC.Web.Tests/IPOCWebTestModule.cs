using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IPOC.EntityFrameworkCore;
using IPOC.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace IPOC.Web.Tests
{
    [DependsOn(
        typeof(IPOCWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class IPOCWebTestModule : AbpModule
    {
        public IPOCWebTestModule(IPOCEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IPOCWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(IPOCWebMvcModule).Assembly);
        }
    }
}