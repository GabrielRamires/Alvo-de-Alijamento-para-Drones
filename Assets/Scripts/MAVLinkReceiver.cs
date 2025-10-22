using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using System.Text;
using Newtonsoft.Json.Linq;
using TMPro;

public class MAVLinkReceiver : MonoBehaviour
{
    private UdpClient udpClient;
    private Thread receiveThread;
    private const int listenPort = 15000;

    public TextMeshProUGUI droneInfoText;
    private string latestData = "";
    private object dataLock = new object(); // Para thread safety

    // Dados do drone
    private float yaw, alt, groundSpeed;
    private double lat, lon;

    void Start()
    {
        udpClient = new UdpClient(listenPort);
        receiveThread = new Thread(ReceiveData);
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    void ReceiveData()
    {
        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, listenPort);

        while (true)
        {
            try
            {
                byte[] data = udpClient.Receive(ref remoteEndPoint);
                string json = Encoding.UTF8.GetString(data);

                // Parse do JSON
                JObject obj = JObject.Parse(json);

                // Atualiza os dados com thread safety
                lock (dataLock)
                {
                    alt = (float)(obj["altitude"] ?? 0);
                    yaw = (float)(obj["yaw"] ?? 0);
                    lat = (double)(obj["latitude"] ?? 0);
                    lon = (double)(obj["longitude"] ?? 0);
                    groundSpeed = (float)(obj["groundspeed"] ?? 0);

                    latestData = $"[DADOS DO DRONE]\n" +
                                $"Lat: {lat:F6}°, Lon: {lon:F6}°\n" +
                                $"Alt: {alt:F1} m, Vel: {groundSpeed:F1} m/s\n" +
                                $"Yaw: {yaw:F1}°";
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Erro no UDP: {e.Message}\nJSON: {latestData}");
            }
        }
    }

    void Update()
    {
        lock (dataLock) // Garante acesso seguro aos dados
        {
            if (droneInfoText != null)
                droneInfoText.text = latestData;
        }
    }

    void OnApplicationQuit()
    {
        receiveThread?.Abort();
        udpClient?.Close();
    }
}