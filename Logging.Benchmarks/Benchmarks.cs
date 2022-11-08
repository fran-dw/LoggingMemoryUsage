using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

namespace Logging.Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    private const string LogMessageWithParameters = "Log message with paramters {0}, {1} and {2}";
    private const string LogMessage = "Log mesage";

    private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
    });

    private readonly ILogger<Benchmarks> _logger;
    private readonly ILoggerAdapter<Benchmarks> _loggerAdapter;

    public Benchmarks()
    {
        _logger = new Logger<Benchmarks>(_loggerFactory);
        _loggerAdapter = new LoggerAdapter<Benchmarks>(_logger);
    }

    [Benchmark]
    public void Log_WithoutIf()
    {
        _logger.LogInformation(LogMessage);
    }
    
    [Benchmark]
    public void Log_WithIf()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(LogMessage);
        }
    }
    
    [Benchmark]
    public void Log_WithParams_WithoutIf()
    {
        _logger.LogInformation(LogMessageWithParameters, 46, 498, 698);
    }
    
    [Benchmark]
    public void Log_WithParams_WithIf()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(LogMessageWithParameters, 46, 498, 698);
        }
    }
    
    [Benchmark]
    public void Log_WithParams_UsingAdapter()
    {
        _loggerAdapter.LogInformation(LogMessageWithParameters, 46, 498, 698);
    }
    
    [Benchmark]
    public void Log_WarningWithParams_UsingDefault()
    {
        _logger.LogWarning(LogMessageWithParameters, 46, 498, 698);
    }
    
    [Benchmark]
    public void Log_WarningWithParams_UsingAdapter()
    {
        _loggerAdapter.LogWarning(LogMessageWithParameters, 46, 498, 698);
    }
}