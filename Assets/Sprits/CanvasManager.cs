using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    Transform hud;
    Transform login;

    public static CanvasManager Instance;
    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        hud = transform.Find("HUD").transform;
        login = transform.Find("Login").transform;
    }

    public void AlteraPontosTela(int pontos)
    {
        hud.transform.Find("Pontos").transform.Find("Numeracao").GetComponent<TextMeshProUGUI>().text = pontos.ToString();
    }

    public void AlteraRanking(string nome)
    {
        hud.transform.Find("Ranking").transform.Find("Numeracao").GetComponent<TextMeshProUGUI>().text = nome.ToString();
    }

    public void AlternarHUD(bool mostrar)
    {
        hud.gameObject.SetActive(mostrar);
    }

    public void AlternarLogin(bool mostrar)
    {
        login.gameObject.SetActive(mostrar);
    }

}
