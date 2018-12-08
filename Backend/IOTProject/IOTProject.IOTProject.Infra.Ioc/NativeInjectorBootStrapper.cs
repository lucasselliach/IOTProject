using IOTProject.CoreProject.Core.Bus;
using IOTProject.CoreProject.Core.Notifications;
using IOTProject.IOTProject.Application.HeartRatesAppService;
using IOTProject.IOTProject.Application.PeopleAppService;
using IOTProject.IOTProject.Domain.HeartRates.HeartRateCommands;
using IOTProject.IOTProject.Domain.HeartRates.HeartRateCommandsHandlers;
using IOTProject.IOTProject.Domain.HeartRates.HeartRateInterfaces.Repositories;
using IOTProject.IOTProject.Domain.HeartRates.HeartRateInterfaces.Services;
using IOTProject.IOTProject.Domain.People.PersonCommands;
using IOTProject.IOTProject.Domain.People.PersonCommandsHandlers;
using IOTProject.IOTProject.Domain.People.PersonInterfaces.Repositories;
using IOTProject.IOTProject.Domain.People.PersonInterfaces.Services;
using IOTProject.IOTProject.Infra.Bus;
using IOTProject.IOTProject.Infra.Data.Repository.HeartRatesRepository;
using IOTProject.IOTProject.Infra.Data.Repository.PeopleRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IOTProject.IOTProject.Infra.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //=========================================
            //============= SYSTEM INJECT =============
            //=========================================

            //ASP.NET HttpContext dependency =====
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Domain Bus Mediator
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            //Domain Notification Handler
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();



            //=========================================
            //========== APPLICATION INJECT ===========
            //=========================================
            services.AddScoped<IPersonService, PersonAppService>();
            services.AddScoped<IHeartRateAppService, HeartRateAppService>();

            //=========================================
            //============= DOMAIN INJECT =============
            //=========================================
            services.AddScoped<INotificationHandler<PersonCreateCommand>, PersonCommandHandler>();
            services.AddScoped<INotificationHandler<PersonEditNameEmailBirthDateCommand>, PersonCommandHandler>();
            services.AddScoped<INotificationHandler<PersonEditHealthInformationCommand>, PersonCommandHandler>();
            services.AddScoped<INotificationHandler<PersonDeleteCommand>, PersonCommandHandler>();
            services.AddScoped<INotificationHandler<HeartRateCreateCommand>, HeartRateCommandHandler>();
            services.AddScoped<INotificationHandler<HeartRateDeleteCommand>, HeartRateCommandHandler>();

            //=========================================
            //============= INFRA INJECT ==============
            //=========================================
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IHeartRateRepository, HeartRateRepository>();
        }
    }
}
