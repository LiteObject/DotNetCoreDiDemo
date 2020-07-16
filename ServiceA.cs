namespace DotNetCoreDiDemo
{
    using System;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The service a.
    /// </summary>
    public class ServiceA : IService
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<ServiceA> logger;

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceA"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public ServiceA(ILogger<ServiceA> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            logger.LogInformation($"{this.GetType().Name} class has been instantiated.");
        }

        /// <summary>
        /// The do something.
        /// </summary>
        public void DoSomething()
        {
            this.logger.LogInformation($"{this.GetType().Name}: Doing something...");
        }
    }
}
