using Microsoft.Extensions.Configuration;

namespace Chapter4
{
    public class TextFileConfigurationSource : IConfigurationSource

    {

        public string FilePath { get; set; }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {

            return new TextFileConfigurationProvider(FilePath);

        }

    }
}
