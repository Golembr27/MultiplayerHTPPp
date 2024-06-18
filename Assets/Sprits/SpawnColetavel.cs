using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnColetavel : MonoBehaviour
{
    public float intervaloSpawn = 0.5f;

    public Transform prefabColetavel;
    public Transform areaSpawn;

    void Start()
    {
        //InvokeRepeating("Spawnar", 0, intervaloSpawn);
    }

    void Update()
    {
        
    }

    public void Spawnar()
    {
        float areaX = areaSpawn.localScale.x / 2;
        float areaZ = areaSpawn.localScale.z / 2;

        float ramdomX = Random.Range( -areaX, areaX);
        float ramdomZ = Random.Range(-areaZ, areaZ);
        Vector3 localSpawn = new Vector3(ramdomX, 0.7f, ramdomZ);

        Transform instacia = Instantiate(prefabColetavel, transform);
        instacia.position = localSpawn;

        Invoke("Spawnar", intervaloSpawn);
    }

}
