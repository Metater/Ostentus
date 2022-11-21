// Runner game, like chrome game
// Arena shooter game

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

Processor processor = new();
var processorTask = processor.RunAsync();

#region Endpoints
app.MapGet("/api/on", () =>
{
    processor.Process("/api/on", (ctx) =>
    {
        Console.WriteLine("on");
        ctx.On();
    });
});
app.MapGet("/api/off", () =>
{
    processor.Process("/api/off", (ctx) =>
    {
        Console.WriteLine("off");
        ctx.Off();
    });
});
#endregion Endpoints

app.MapFallbackToFile("index.html");

var serverTask = app.RunAsync();
await processorTask;