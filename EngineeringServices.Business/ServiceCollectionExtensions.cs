using EngineeringServices.Business.Implementations;
using EngineeringServices.Business.Interfaces;
using EngineeringServices.Business.Profiles;
using EngineeringServices.DataAccess.EntityFramework.Repositories;
using EngineeringServices.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EngineeringServices.Business
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AdminProfile));

            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdminBs, AdminBs>();

            services.AddScoped<IEngineeringRepository, EngineeringRepository>();
            services.AddScoped<IEngineeringBs, EngineeringBs>();

            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageBs, MessageBs>();

            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<INoteBs, NoteBs>();

            services.AddScoped<IPersonalInformationRepository, PersonalInformationRepository>();
            services.AddScoped<IPersonalInformationBs, PersonalInformationBs>();

            services.AddScoped<IWorkInformationRepository, WorkInformationRepository>();
            services.AddScoped<IWorkInformationBs, WorkInformationBs>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonBs, PersonBs>();
        }
    }
}
