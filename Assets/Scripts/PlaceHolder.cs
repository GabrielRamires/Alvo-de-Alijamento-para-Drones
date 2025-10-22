using TMPro;
using UnityEngine;

public class PlaceHolder : MonoBehaviour
{
    public TextMeshProUGUI droneInfoText; // arraste o TextMeshPro no Inspector

    private float timer = 0f;
    private int fakeYaw = 0;

    void Update()
    {
        timer += Time.deltaTime;

        // A cada 1 segundo, atualiza os dados simulados
        if (timer >= 1f)
        {
            timer = 0f;
            fakeYaw = (fakeYaw + 10) % 360;

            string simulatedData =
                "[SIMULAÇÃO DE DADOS DO DRONE]\n" +
                $"Posição: Lat 47.398, Lon 8.545, Alt 543.21m\n" +
                $"Atitude: Roll 5.2°, Pitch -2.1°, Yaw {fakeYaw}°\n" +
                $"Velocidade: 3.4 m/s";

            if (droneInfoText != null)
            {
                droneInfoText.text = simulatedData;
            }
        }
    }
}
