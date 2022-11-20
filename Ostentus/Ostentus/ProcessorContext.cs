using NetCoreServer;

namespace Ostentus;

public class ProcessorContext
{
    private readonly UdpClient client = new("192.168.1.85", 5011);

    public void Start()
    {
        client.Connect();
    }
    public void Stop()
    {
        client.Disconnect();
    }

    public void On()
    {
        byte[] data = new byte[64];
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = 255;
        }
        client.SendAsync(data);
    }

    public void Off()
    {
        byte[] data = new byte[64];
        client.SendAsync(data);
    }

    public string Serialize<TValue>(TValue value)
    {
        return JsonUtils.Serialize(value);
    }
}
