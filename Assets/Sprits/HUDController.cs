using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public static GameObject instance;
    public TMP_InputField inputNome;


    private void Awake()
    {
        //instance = transform.GetComponent<HudInativo>();
        instance = GameObject.Find("Button");
    }

    public async void botaoEntrar()
    {
        instance.SetActive(false);  
        Usuario usuario = await RequestManager.BuscaUsuario(inputNome.text);

        if ( usuario == null )
        {
            usuario = await RequestManager.CriarUsuario(inputNome.text);
        }



        Gamemanager.usuarioLogado = usuario;

        //Player já está logado bora ligar ele e spawnar os pontos
        PlayerSpawner.instance.Spawnar();
        GameObject.Find("SpawnColetavel").GetComponent<SpawnColetavel>().Spawnar();

        HudInativo.instance.InativarHud();
        GameObject.Find("Canvas").GetComponent<HudInativo>().InativarHud();


    }

}
