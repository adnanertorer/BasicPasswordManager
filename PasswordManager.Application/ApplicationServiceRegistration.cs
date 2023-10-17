using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PasswordManager.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), type: typeof(BaseBusinessRoles));
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
                configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
            });
            return services;
        }

        public static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly, Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var items in types)
            {
                if(addWithLifeCycle == null)
                {
                    services.AddScoped(items);
                }
                else
                {
                    addWithLifeCycle(services, type);
                }
            }
            return services;
        }
    }
}
