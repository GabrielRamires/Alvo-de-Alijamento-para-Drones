using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class MoverInputfield : MonoBehaviour
{
    [Header("Referências")]
    public TMP_InputField coordinateInput;
    public RawImage targetImage;
    public GameObject panel; // Arraste o painel que deseja controlar aqui

    [Header("Configurações")]
    public float moveSpeed = 5f;
    public bool smoothMovement = true;

    private void Start()
    {
        // Desativa o painel ao iniciar
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    void Update()
    {
        // Ativa/desativa o painel com Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TogglePanel();
        }

        // Se o InputField estiver ativo e o Enter for pressionado
        if (Input.GetKeyDown(KeyCode.Return) && coordinateInput.gameObject.activeInHierarchy)
        {
            MoveImageToCoordinates();
        }
    }

    void TogglePanel()
    {
        if (panel != null)
        {
            bool newState = !panel.activeSelf;
            panel.SetActive(newState);

            // Se estiver ativando o painel, coloca o foco no InputField
            if (newState)
            {
                coordinateInput.Select();
                coordinateInput.ActivateInputField();
            }
        }
    }

    public void MoveImageToCoordinates()
    {
        string inputText = coordinateInput.text;

        // Remove espaços e divide a entrada em X e Y
        string[] coordinates = inputText.Replace(" ", "").Split(',');

        if (coordinates.Length == 2)
        {
            if (float.TryParse(coordinates[0], out float x) && float.TryParse(coordinates[1], out float y))
            {
                Vector2 targetPosition = new Vector2(x, y);

                if (smoothMovement)
                {
                    StartCoroutine(SmoothMove(targetPosition));
                }
                else
                {
                    targetImage.rectTransform.anchoredPosition = targetPosition;
                }

                Debug.Log($"Movendo para: X={x}, Y={y}");
            }
            else
            {
                Debug.LogWarning("Digite números válidos! Exemplo: 100,200");
            }
        }
        else
        {
            Debug.LogWarning("Formato inválido! Use: X,Y (Exemplo: 150,-50)");
        }
    }

    IEnumerator SmoothMove(Vector2 targetPos)
    {
        while (Vector2.Distance(targetImage.rectTransform.anchoredPosition, targetPos) > 0.1f)
        {
            targetImage.rectTransform.anchoredPosition = Vector2.Lerp(
                targetImage.rectTransform.anchoredPosition,
                targetPos,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }
    }

    public void ClearInput()
    {
        coordinateInput.text = "";
    }
}