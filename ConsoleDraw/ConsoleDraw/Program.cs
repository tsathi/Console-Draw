using System.Collections.Generic;
using ConsoleDraw.Commands;
using ConsoleDraw.Drawers;
using ConsoleDraw.Helpers;
using ConsoleDraw.Interfaces;
using ConsoleDraw.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleDraw
{
    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            var app = host.Services.GetService<App>();
            var reader = host.Services.GetService<IConsoleReader>();
            var writer = host.Services.GetService<IConsoleWriter>();
            var commandHandler = host.Services.GetService<ICommandHandler>();
            var commands = host.Services.GetService<IEnumerable<ICommand>>();

            app.Init(writer,reader, commands, commandHandler);

            host.Run();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureServices((_, services) =>
                   services.AddSingleton<App>()
                           .AddSingleton<ICanvas, Canvas>()
                           .AddSingleton<IValidator<UserCommand>, UserCommandValidator>()
                           .AddSingleton<ICommandHandler, CommandHandler>()
                           .AddSingleton<ILineDrawerHandler, LineDrawerHandler>()
                           .AddSingleton<ICommand, CanvasCommand>()
                           .AddSingleton<ICommand, LineCommand>()
                           .AddSingleton<ICommand, RectangleCommand>()
                           .AddSingleton<ICommand, BucketFillCommand>()
                           .AddSingleton<ICommand, InvalidCommand>()
                           .AddSingleton<IConsoleWriter, ConsoleWriter>()
                           .AddSingleton<IConsoleReader, ConsoleReader>()
                           .AddSingleton<IRectangleDrawer, RectangleDrawer>()
                           .AddSingleton<LineDrawerHandler>()
                           .AddSingleton<ILineDrawer, HorizontalLineDrawer>()
                           .AddSingleton<ILineDrawer, VerticalLineDrawer>());
    }
}
