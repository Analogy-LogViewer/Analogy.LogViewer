using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Analogy.DataTypes;

public class ServicesProvider
{
    private IServiceProvider ServiceProvider { get; set; }
    private static Lazy<ServicesProvider> _instance = new Lazy<ServicesProvider>(() => new ServicesProvider());
    public static ServicesProvider Instance => _instance.Value;
    private IServiceCollection ServiceCollection { get; set; }
    private ILoggerFactory LoggerFactory { get; set; }

    private ILogger? _generic;

    public ILogger? GenericLogger => _generic ??= CreateLogger("Generic");

    /// <summary>
    /// The Root URL at the server (example: https://dev2.medicvod.com/MedicastUnitsConfig/OrpheusCAST-Lior)
    /// </summary>
    public string RemoteBase { get; set; }

    private ServicesProvider()
    {
        Initialize();
    }

    internal void Initialize()
    {
        ServiceCollection = new ServiceCollection();
        LoggerFactory = new LoggerFactory();
        ServiceProvider = ServiceCollection.BuildServiceProvider();
        RemoteBase = "";
    }

    public IServiceCollection GetServiceCollection() => ServiceCollection;
    public void AddLoggerProvider(ILoggerProvider loggerProvider) => LoggerFactory.AddProvider(loggerProvider);

    public void BuildServiceProvider(string appName)
    {
        var logger = CreateLogger(appName);
        ServiceCollection.AddSingleton<Microsoft.Extensions.Logging.ILogger>(logger);
        ServiceProvider = ServiceCollection.BuildServiceProvider();
    }

    public ILogger? CreateLogger<T>()
    {
        try
        {
            return LoggerFactory.CreateLogger<T>();
        }
        catch
        {
            //logger is disposed. ignore
            return null;
        }
    }

    public ILogger? CreateLogger(string category)
    {
        try
        {
            return LoggerFactory.CreateLogger(category);
        }
        catch
        {
            //logger is disposed. ignore
            return null;
        }
    }
    public T GetService<T>()
    {
        var service = ServiceProvider.GetService<T>();
        if (service == null)
        {
            throw new Exception($"Service for type {typeof(T)} is not registered");
        }

        return service;
    }

    public void DisposeLoggers() => LoggerFactory.Dispose();
}