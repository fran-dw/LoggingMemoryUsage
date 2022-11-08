using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
});

ILogger logger = new Logger<Program>(loggerFactory);

// for (var i = 0; i < 100_000_000; i++)
// {
//     logger.LogInformation($"Logging random number: {Random.Shared.Next()}");
// }

for (var i = 0; i < 100_000_000; i++)
{
    logger.LogInformation("Logging random number: {0}", Random.Shared.Next());
}

// for (var i = 0; i < 100_000_000; i++)
// {
//     if (logger.IsEnabled(LogLevel.Information))
//     {
//         logger.LogInformation("Logging random number: {0}", Random.Shared.Next());        
//     }
// }
