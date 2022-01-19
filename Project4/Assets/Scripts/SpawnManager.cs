using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //getting enemy
    public GameObject enemy;
    
    //limits for x and z
    private int xSpawn = 7;
    private int zSpawn = 7;
    // Start is called before the first frame update
    void Start()
    {
        //spawn enemy
        Instantiate(enemy, GenerateSpawn(), enemy.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //method for where to spawn enemy
    Vector3 GenerateSpawn() 
    {
        Vector3 spawn = new Vector3(Random.Range(-xSpawn, xSpawn), 1, Random.Range(-zSpawn, zSpawn));
        return spawn;
    }
}
