// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;


UdpClient client = null;
try
{
    client = new UdpClient(20777);
    Console.WriteLine("Listening...");
}
catch (Exception ex)
{
    Debug.WriteLine(ex.Message);
}
while (true)
{

    IPEndPoint server = new IPEndPoint(IPAddress.Any, 20777);

    byte[] packet = client.Receive(ref server);
    Console.WriteLine(packet.Length);
    if(packet.Length == 972)
    {
        var header = packet.SubArray(2, 2);
        Console.WriteLine("first byte = " + BitConverter.ToInt16(header));
        var laptime = packet.SubArray(24, 4);
        //if (BitConverter.IsLittleEndian)
        //    Array.Reverse(laptime);

        uint i = BitConverter.ToUInt32(laptime, 0);
        var time = TimeSpan.FromMilliseconds(i);
        var timestring = "" + time.Minutes + ":" + time.Seconds + ":" +time.Milliseconds;
        Console.WriteLine("laptime: {0}", timestring);
    }
}
public static class Extensions
{
    public static T[] SubArray<T>(this T[] array, int offset, int length)
    {
        T[] result = new T[length];
        Array.Copy(array, offset, result, 0, length);
        return result;
    }
}