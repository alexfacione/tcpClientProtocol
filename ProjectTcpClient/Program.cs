using System.Net.Sockets;
using System.Text;

/// <summary>
/// <title> TCP CLIENT</title>
/// Author: Alexandre de Oliveira Facione
/// Description: TCP Client developed in .NET 6
/// </summary>

const string ipAddress = "127.0.0.1";
const int portTcpServer = 3124;

// TCP CLIENT
TcpClient client = new TcpClient(ipAddress, portTcpServer);
Console.WriteLine($"CLIENT: Conected to server {ipAddress}:{portTcpServer}");

NetworkStream stream = client.GetStream();

Console.WriteLine($"\nPress <E> to finish");
var message = String.Empty;
do
{
    Console.WriteLine($"\nSend your message to server: ");
    message = Console.ReadLine() ?? "";

    if (message.Trim().Equals("e", StringComparison.InvariantCultureIgnoreCase))
        break;

    // Send message to server
    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
    stream.Write(messageBytes, 0, messageBytes.Length);
    Console.WriteLine($"Message sent: {message}");

    // Response form server
    byte[] responseBuffer = new byte[4096];
    int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
    string response = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);
    Console.WriteLine($"Response from server: {response}");

} while (true);