using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f;
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(horizontal, 0, vertical);
        movimento = movimento * velocidade * Time.deltaTime;

        transform.Translate(movimento);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Coletavel"))
        {
            Gamemanager.usuarioLogado.pontos++;
            CanvasManager.Instance.AlteraPontosTela(Gamemanager.usuarioLogado.pontos);
            RequestManager.AlteraPontos( Gamemanager.usuarioLogado.id, Gamemanager.usuarioLogado.pontos);
            Destroy(collider.gameObject);
        }
    }

}
