using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestApp.Console.Interface.Service;
using TestApp.Console.Model;
using TestApp.Console.Service;

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var appSettings = config.GetSection("AppSettings").Get<AppSettings>();

var serviceProvider = new ServiceCollection()
    .AddSingleton(appSettings!)
    .AddSingleton<ITextService, TextService>()
    .BuildServiceProvider();

var textService = serviceProvider.GetRequiredService<ITextService>();

try
{
    throw new Exception("User John Doe had an issue processing their phone number 082 123 4567.");
}
catch (Exception ex)
{
    var text = await textService.RedactPii(ex);

    Console.WriteLine("====================================");
    Console.WriteLine("Original Error Message:");
    Console.WriteLine(ex);
    Console.WriteLine("====================================");
    Console.WriteLine("Message with PII redacted:");
    Console.WriteLine(text);
    Console.WriteLine("====================================");
}

