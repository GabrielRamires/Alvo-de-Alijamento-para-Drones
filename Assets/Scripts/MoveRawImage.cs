using UnityEngine;
using UnityEngine.UI;

public class MoveRawImage : MonoBehaviour
{
    public float speed = 100f;
    private RectTransform rectTransform;
    private Vector2 startPosition;
    private Vector2 initialPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.anchoredPosition;

        // Carrega se existir valor salvo
        float x = PlayerPrefs.GetFloat("SavedX", rectTransform.anchoredPosition.x);
        float y = PlayerPrefs.GetFloat("SavedY", rectTransform.anchoredPosition.y);
        Vector2 savedPosition = new Vector2(x, y);
        rectTransform.anchoredPosition = savedPosition;

        startPosition = savedPosition; // define como nova posição inicial também
    }

    void Update()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) movement.y += 1;
        if (Input.GetKey(KeyCode.S)) movement.y -= 1;
        if (Input.GetKey(KeyCode.A)) movement.x -= 1;
        if (Input.GetKey(KeyCode.D)) movement.x += 1;

        rectTransform.anchoredPosition += movement * speed * Time.deltaTime;

        // Voltar para o startPosition ao apertar Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            rectTransform.anchoredPosition = startPosition;
        }

        // Atualizar startPosition e salvar no PlayerPrefs ao apertar P
        if (Input.GetKeyDown(KeyCode.P))
        {
            startPosition = rectTransform.anchoredPosition;

            // Salva a posição
            PlayerPrefs.SetFloat("SavedX", startPosition.x);
            PlayerPrefs.SetFloat("SavedY", startPosition.y);
            PlayerPrefs.Save(); // garante que será salvo
            Debug.Log("Posição salva!");
        }

        // Voltar para a posição inicial fixa ao apertar 0
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            rectTransform.anchoredPosition = initialPosition;
        }
    }
}
