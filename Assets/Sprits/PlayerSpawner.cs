using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform localDeSpawn; 
    //Sigleton
    public static PlayerSpawner instance;
    private void Awake()
    {
        //instance = transform.GetComponent<PlayerSpawner>();
        instance = this;
    }

    public Transform playerPrefab;

    private void Start()
    {
            
    }

    public void Spawnar()
    {
        Transform playerCriado = Instantiate(playerPrefab);
        playerCriado.transform.position = localDeSpawn.transform.position;
    }
}
