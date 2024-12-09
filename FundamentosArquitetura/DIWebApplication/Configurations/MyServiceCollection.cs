using DIWebApplication.Cases;

public static class MyServiceCollection
{
    public static IServiceCollection AddLifecycle(this IServiceCollection services)
    {
        services.AddTransient<IOperacaoTransient, Operacao>();
        services.AddScoped<IOperacaoScoped, Operacao>();
        services.AddSingleton<IOperacaoSingleton, Operacao>();
        services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));
        services.AddTransient<OperacaoService>();

        return services;
    }

    public static IServiceCollection AddVidaReal(this IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IClienteServices, ClienteServices>();

        return services;
    }

    public static IServiceCollection AddGenerics(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        return services;
    }

    public static IServiceCollection AddMultiplasClasses(this IServiceCollection services)
    {
        services.AddTransient<ServiceA>();
        services.AddTransient<ServiceB>();
        services.AddTransient<ServiceC>();
        services.AddTransient<Func<string, IService>>(serviceProvider => key =>
        {
            switch (key)
            {
                case "A":
                    return serviceProvider.GetService<ServiceA>();

                case "B":
                    return serviceProvider.GetService<ServiceB>();

                case "C":
                    return serviceProvider.GetService<ServiceC>();

                default:
                    return null;
            }
        });
        return services;
    }
}