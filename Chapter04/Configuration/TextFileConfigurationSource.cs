using Microsoft.Extensions.Configuration;

namespace Chapter4;

public class TextFileConfigurationSource : IConfigurationSource

{
    public string FilePath { get; set; } = default!;

    public IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new TextFileConfigurationProvider(FilePath);
}
