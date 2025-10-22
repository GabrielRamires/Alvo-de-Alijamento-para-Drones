using UnityEngine;
using UnityEngine.UI;
using TMPro; // Importa o TextMeshPro

public class ShowRawImagePosition : MonoBehaviour
{
    [Header("Arraste aqui o RawImage que quer monitorar")]
    public RawImage rawImage;

    [Header("Arraste aqui o TextMeshProUGUI da HUD")]
    public TextMeshProUGUI positionTMP;

    private RectTransform rectTransform;

    void Start()
    {
        if (rawImage == null)
        {
            Debug.LogError("RawImage não foi atribuído no Inspector!");
            return;
        }

        if (positionTMP == null)
        {
            Debug.LogError("TextMeshProUGUI não foi atribuído no Inspector!");
            return;
        }

        rectTransform = rawImage.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (rectTransform != null && positionTMP != null)
        {
            Vector2 pos = rectTransform.anchoredPosition;
            positionTMP.text = $"X: {pos.x:F2} | Y: {pos.y:F2}";
        }
    }
}
