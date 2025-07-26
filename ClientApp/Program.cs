using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(client =>
    {
        client.UseLocalhostClustering();
    })
    .UseConsoleLifetime()
    .Build();

await host.StartAsync();

Console.WriteLine("Client connected to silo!");

var client = host.Services.GetRequiredService<IClusterClient>();

//var todograin = client.GetGrain<IToDoGrain>("task1");
//await todograin.SetTitle("Learning Orleans");
//var title = await todograin.GetTitle();

//var grain = client.GetGrain<IPersistedToDoGrain>("persisted-task1");
//await grain.SetTitle("Persisted ToDo Item");
//var title = await grain.GetTitle();

var grain = client.GetGrain<ITimerGrain>("timer-grain");

Console.WriteLine("Starting timer...");
await grain.StartTimer(TimeSpan.FromSeconds(2)); // Triggers every 5 seconds

// Wait and observe the timer
await Task.Delay(TimeSpan.FromSeconds(20)); // Give time to trigger 3-4 times

// Stop the timer
Console.WriteLine("Stopping timer...");
await grain.StopTimer();

Console.ReadLine();
await host.StopAsync();
