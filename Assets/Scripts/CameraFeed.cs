using UnityEngine;
using UnityEngine.UI;

public class CameraFeed : MonoBehaviour
{
    public RawImage rawImage;
    private WebCamTexture webcamTexture;
    private WebCamDevice[] devices;
    private int currentCamIndex = 0;

    void Start()
    {
        devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.LogWarning("Nenhuma câmera detectada.");
            return;
        }

        if (devices.Length > 1)
        {
            Debug.Log("Duas ou mais câmeras detectadas. Pressione '1' ou '2' para alternar.");
        }

        StartCamera(currentCamIndex);
    }

    void Update()
    {
        if (devices.Length > 1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwitchCamera(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwitchCamera(1);
            }
        }
    }

    void SwitchCamera(int index)
    {
        if (index < devices.Length && index != currentCamIndex)
        {
            webcamTexture.Stop();
            StartCamera(index);
        }
    }

    void StartCamera(int index)
    {
        currentCamIndex = index;
        webcamTexture = new WebCamTexture(devices[index].name);
        rawImage.texture = webcamTexture;
        rawImage.material.mainTexture = webcamTexture;
        webcamTexture.Play();
        Debug.Log("Câmera ativa: " + devices[index].name);
    }

    void OnDestroy()
    {
        if (webcamTexture != null && webcamTexture.isPlaying)
            webcamTexture.Stop();
    }
}
