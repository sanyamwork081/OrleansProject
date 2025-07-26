using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder()
    .UseOrleans(silo =>
    {
        silo.UseLocalhostClustering();
        silo.AddMemoryGrainStorage("todoStore");
    })
    .RunConsoleAsync();
