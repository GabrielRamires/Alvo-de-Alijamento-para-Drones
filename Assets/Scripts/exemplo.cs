using UnityEngine;
using Newtonsoft.Json;

public class exemplo : MonoBehaviour
{
    void Start()
    {
        // Cria um objeto qualquer
        Pessoa pessoa = new Pessoa
        {
            Nome = "Gabriel",
            Idade = 25
        };

        // Serializa para JSON usando Newtonsoft.Json
        string json = JsonConvert.SerializeObject(pessoa);

        // Mostra no console
        Debug.Log("JSON gerado: " + json);

        // Desserializa de volta para objeto
        Pessoa pessoaDesserializada = JsonConvert.DeserializeObject<Pessoa>(json);
        Debug.Log("Objeto desserializado: Nome = " + pessoaDesserializada.Nome + ", Idade = " + pessoaDesserializada.Idade);
    }
}

// Classe simples para teste
public class Pessoa
{
    public string Nome;
    public int Idade;
}
