using Microsoft.Extensions.Logging;

namespace Analogy.DataTypes;

public class AnalogyLoggerProvider : ILoggerProvider
{
    private AnalogyLogger? logger;
    public void Dispose()
    {

    }

    public ILogger CreateLogger(string categoryName)
    {
        return logger ??= new AnalogyLogger();
    }
}