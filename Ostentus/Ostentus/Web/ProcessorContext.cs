namespace Ostentus.Web;

public class ProcessorContext
{
    private readonly UdpClient client = new("192.168.1.85", 5011);

    private readonly Display display;

    public ProcessorContext()
    {
        display = new((data) => client.SendAsync(data));
    }

    public void Start()
    {
        client.Connect();
    }
    public void Update(double deltaTime)
    {
        
    }
    public void Stop()
    {
        client.Disconnect();
    }

    public void On()
    {
        display.Set(255);
        display.CommandFlush();
    }

    public void Off()
    {
        display.Set();
        display.CommandFlush();
    }

    public string Serialize<TValue>(TValue value)
    {
        return JsonUtils.Serialize(value);
    }
}
