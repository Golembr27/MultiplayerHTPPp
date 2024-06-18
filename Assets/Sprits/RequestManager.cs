using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using TMPro;

public class Usuario
{
    public int id;
    public string nome;
    public int pontos;
    public string created_at;
}
public class RequestManager : MonoBehaviour
{
    static string apiUrl = "https://esziwqdftdcobnzodgug.supabase.co/rest/v1/usuarios";
    static string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImVzeml3cWRmdGRjb2Juem9kZ3VnIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTIzNDY5OTEsImV4cCI6MjAyNzkyMjk5MX0.qb2vdyPXh0P-uCAj8kpb9Lb3hNJZJtM-N8kuj-_GoYk\r\n";

    public static async void BustarTodosOsUsuarios()
    {
        string requestUrl = $"{apiUrl}?pontos=gt.0&order=pontos.desc&apikey={apiKey}";

        UnityWebRequest request = UnityWebRequest.Get(requestUrl);
        await request.SendWebRequest();

        string response = request.downloadHandler.text;

        if (response == "[]")
        {
            return ;
        }
        List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(response);
        
        for (int i = 0; i < usuarios.Count; i++)
        {
            string mostraRanking = $"{i + 1}°{usuarios[i].nome}:{usuarios[i].pontos}";
            HudInativo.instance.prefab.GetComponent<TextMeshProUGUI>().text = mostraRanking;
            Instantiate(HudInativo.instance.prefab, HudInativo.instance.spawn);
        }

    }
    // Buscar o usuário pelo nome
    public static async Task<Usuario> BuscaUsuario(string nome)
    {

        string requestUrl = $"{apiUrl}?nome=eq.{nome}&apikey={apiKey}";

        UnityWebRequest request = UnityWebRequest.Get(requestUrl);
        await request.SendWebRequest();

        string response = request.downloadHandler.text;

        if (response == "[]")
        {
            return null;
        }
        List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(response);
        Debug.Log(usuarios[0].id);
        BustarTodosOsUsuarios();
        return usuarios[0];
        
    }

    // Criar o usuário
    public static async Task<Usuario> CriarUsuario(string nome)
    {

        string requestUrl = $"{apiUrl}?apikey={apiKey}";
        string json = $" \"nome\": \"{nome}\", \"pontos\": 0 ";
        json = "{"+json+"}" ;

        UnityWebRequest request = UnityWebRequest.Post(requestUrl, json,"application/json");
        await request.SendWebRequest();

        return await BuscaUsuario(nome);



    }
    // Atualizar pontos buscando pelo id do usuário
    public static async void AlteraPontos( int id, int pontos)
    {

        string json = " { \"pontos\": "+pontos+" } ";
        string requestUrl = $"{apiUrl}?id=eq.{id}&apikey={apiKey}";

        UnityWebRequest request = UnityWebRequest.Put(requestUrl, json);
        request.SetRequestHeader("Content-Type", "application/json");
        request.method = "PATCH";
        await request.SendWebRequest();

        Debug.Log("Pontos alterados no banco");
    }



}
    //GET, POST, PUT, DELETE

    // Buscar todos os usuário
