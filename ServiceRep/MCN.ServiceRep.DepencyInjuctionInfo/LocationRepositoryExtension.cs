using System;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.UserRepositoryBL;
using Microsoft.Extensions.DependencyInjection; 

namespace MCN.ServiceRep.DepencyInjuctionInfo
{
    public class LocationRepositoryExtension
    {
        public LocationRepositoryExtension(IServiceCollection services)
        {
            try
            {
                //services.AddTransient<ILocalsRepositoryBL, LocalsRepositoryBL>();
                services.AddScoped<IUserRepositoryBL, UserRepositoryBL>();
               
              

                //services.AddTransient<IFormRepositoryBL, FormRepositoryBL>();
                //services.AddTransient<IAdminOfficeRepositoryBL, AdminOfficeRepositoryBL>();
                //services.AddTransient<IProductModuleRepositoryBL, ProductModuleRepositoryBL>();
                //services.AddTransient<IAOProductModuleRepositoryBL, AOProductModuleRepositoryBL>();
                //services.AddTransient<IUserRepositoryBL, UserRepositoryBL>();
                //services.AddTransient<IEmailLogRepositoryBL, EmailLogRepositoryBL>();
                //services.AddTransient<IAutoCodeNumberRepositoryBL, AutoCodeNumberRepositoryBL>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
