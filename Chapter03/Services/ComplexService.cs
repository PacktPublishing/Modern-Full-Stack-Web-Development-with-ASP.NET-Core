using Microsoft.Extensions.Options;

namespace Chapter03.Services
{
    public class ComplexService : IComplexService
    {

        private readonly IAnotherService _anotherService;
        private readonly ServiceConfig _config;

        public ComplexService(IAnotherService anotherService, IOptions<ServiceConfig> options)

        {

            _anotherService = anotherService;

            _config = options.Value;

        }

        public void PerformAction()
        {

            // Use _anotherService and _config to perform actions 

        }

    }

    public class AnotherService : IAnotherService
    {
        public void AnotherAction()
        {

            // Implementation 

        }

    }


    public interface IAnotherService
    {

        void AnotherAction();

    }


    public class ServiceConfig
    {

        public string Url { get; set; }

        public int Timeout { get; set; }

    }
}
