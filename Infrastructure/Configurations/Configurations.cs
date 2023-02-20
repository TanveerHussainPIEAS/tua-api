using AutoMapper;
using TUAApi.Infrastructure.AutoMapper;

namespace TUAApi.Infrastructure.Configurations
{
    public static class Configurations
    {
        public static void AddApplicationConfigurationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //var appSettingsSection = configuration.GetSection("AppSettings");
            //services.Configure<AppSettings>(appSettingsSection);

            //var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddCorsService();
            //services.ConfigureJwtToken(appSettings);
            services.AddDIContainerService();
            //services.AddAutoMapperService();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }


    }
}
