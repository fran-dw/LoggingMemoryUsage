# LoggingMemoryUsage
This is relating to the default logger used by .NET applications when starting a new C# project.

Api Project shows a "real-world" usage of logging.

Benchmark project shows how calls to log methods with parameters still allocate memory even though log levels are set to not printed the messages.
The benchmark also includes samples using he LogLevel checks to not call LogInformation in the first place.
Included, is also a custom logging adapter you might implement yourself in a project using the default logger.

This off course does not only apply to LogInformation but any call to any Log method.
