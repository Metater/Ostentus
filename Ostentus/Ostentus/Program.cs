// Runner game, like chrome game
// Arena shooter game

static Process? PlayPippyLunchtime() => Process.Start(new ProcessStartInfo
{
    FileName = @"C:\Utils\ffplay",
    Arguments = "-nodisp -autoexit \"C:\\Utils\\pippy-lunchtime.mp3\"",
    RedirectStandardOutput = true,
    UseShellExecute = false
});

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
app.MapGet("/api/play-pippy-lunchtime", () =>
{
    // ffplay.exe -nodisp -autoexit pippy-lunchtime.m4a
    //Console.Beep();
    //https://stackoverflow.com/questions/46835811/ffplay-wasapi-cant-initialize-audio-client-ffmpeg-3-4-binaries
    PlayPippyLunchtime()?.WaitForExit();
});
app.MapGet("/api/lunchtime/update-alarm-time", (string time) =>
{
    Console.WriteLine(time);
});
#endregion Endpoints

app.MapFallbackToFile("index.html");

var serverTask = app.RunAsync();
await processorTask;