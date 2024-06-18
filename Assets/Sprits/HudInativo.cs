using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudInativo : MonoBehaviour
{
    public GameObject hud;
    public static HudInativo instance;

    public Transform prefab;
    public Transform spawn;
    private void Awake()
    {
        //instance = transform.GetComponent<HudInativo>();
        instance = this;

    }

    public void InativarHud()
    {
        hud.SetActive(false);
    }
}
