# LoggingMemoryUsage
This is relating to the default logger used by .NET applications when starting a new C# project.

## Logging.Api
This project shows a "real-world" usage of logging.

## Logging.Benchmark
This project shows how calls to log methods with parameters still allocate memory even though log levels are set to not printed the messages.
The benchmark also includes samples using he LogLevel checks to not call LogInformation in the first place.
Included, is also a custom logging adapter you might implement yourself in a project using the default logger.

## Logging.Default
This application can be used by dotMemory orsimilar applications to showcase the memory usage and GC.
Severall code segments can be uncommented/commented out as needed when trying to measure different usages.
