namespace DotNetCoreDiDemo
{
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The service a.
    /// </summary>
    public class ServiceB : IService
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<ServiceB> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceB"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public ServiceB(ILogger<ServiceB> logger)
        {
            this.logger = logger;
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
