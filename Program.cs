
namespace DotNetCoreDiDemo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    class Program
    {
        /// <summary>
        /// The services.
        /// </summary>
        private static readonly ServiceProvider Provider;
        
        /// <summary>
        /// The Program logger.
        /// </summary>
        private static readonly ILogger<Program> Logger;
        
        /// <summary>
        /// The configuration.
        /// </summary>
        private static IConfiguration configuration;

        /// <summary>
        /// Initializes static members of the <see cref="Program"/> class.
        /// </summary>
        static Program()
        {
            var serviceCollection = new ServiceCollection();
            string[] arguments = Environment.GetCommandLineArgs();
            Configure(serviceCollection, arguments);

            Provider = serviceCollection.BuildServiceProvider();
            Logger = Provider.GetRequiredService<ILogger<Program>>();
            Logger.LogInformation($"{nameof(Program)} class has been instantiated.");
        }

        /// <summary>
        /// The service resolver.
        /// </summary>
        /// <param name="key">
        /// The key - Service Type.
        /// </param>
        private delegate IService ServiceResolver(ServiceType key);

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <exception cref="KeyNotFoundException">
        /// </exception>
        private static void Configure(IServiceCollection services, string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                /*.AddJsonFile($"appsettings.{environmentName}.json", true, true) */
                .AddEnvironmentVariables();

            services.AddLogging(
                builder =>
                    {
                        builder.ClearProviders();
                        builder.SetMinimumLevel(LogLevel.Trace);
                        builder.AddConsole();

                        configuration = configBuilder.Build();
                    });

            configuration = configBuilder.Build();

            services.AddScoped<IConfiguration>(c => configuration);

            services.AddScoped<ServiceA>();
            services.AddScoped<ServiceB>();
            services.AddScoped<ServiceC>();

            // Option #1
            services.AddTransient<Func<ServiceType, IService>>(
                p => key =>
                    {
                        Console.WriteLine($"Key: {key}");
                        Console.WriteLine(key);
                        Console.WriteLine(key.ToString());

                        if (!Enum.IsDefined(typeof(ServiceType), key))
                        {
                            throw new InvalidEnumArgumentException(nameof(key), (int)key, typeof(ServiceType));
                        }

                        switch (key)
                        {
                            case ServiceType.ServiceA:
                                return p.GetService<ServiceA>();
                            case ServiceType.ServiceB:
                                return p.GetService<ServiceB>();
                            case ServiceType.ServiceC:
                                return p.GetService<ServiceC>();
                            default:
                                // return null;
                                throw new KeyNotFoundException(key.ToString());
                        }
                    });

            // Option #2
            services.AddTransient<ServiceResolver>(p => key =>
                {
                    switch (key)
                    {
                        case ServiceType.ServiceA:
                            return p.GetService<ServiceA>();
                        case ServiceType.ServiceB:
                            return p.GetService<ServiceB>();
                        case ServiceType.ServiceC:
                            return p.GetService<ServiceC>();
                        default:
                            // return null;
                            throw new KeyNotFoundException(key.ToString());
                    }
                });

            // Option #3
            services.AddSingleton<IService, ServiceA>();
            services.AddSingleton<IService, ServiceB>();
            services.AddSingleton<IService, ServiceC>();
        }

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        static void Main(string[] args)
        {
            // Option #1
            IService serviceA = Provider.GetRequiredService<Func<ServiceType, IService>>()((ServiceType)1);
            serviceA.DoSomething();

            // Option #2
            IService serviceB = Provider.GetRequiredService<ServiceResolver>()((ServiceType)2);
            serviceB.DoSomething();

            // Option #3
            IEnumerable<IService> services = Provider.GetServices<IService>();
            IService serviceC = services.First(s => s.GetType() == typeof(ServiceC));
            serviceC.DoSomething();
        }
    }
}
