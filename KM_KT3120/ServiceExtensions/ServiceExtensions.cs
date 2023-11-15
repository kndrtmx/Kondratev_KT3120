using KM_KT3120.interfaces.StudentInterfaces;
using KM_KT3120.Models;

namespace KM_KT3120.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentFilterService>();
            return services;
        }
    }
}
