using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //getting enemy
    public GameObject enemy;
    public GameObject powerUp;
    
    //limits for x and z
    private int xSpawn = 7;
    private int zSpawn = 7;

    //more the higher the level
    private int enemiesToSpawn = 1;

    //counts how many enemies are left
    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        //spawn enemy
        spawnEnemies(enemiesToSpawn);

        //spawn power up
        spawnPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        //gets how many enemies there are
        enemyCount = FindObjectsOfType<EnemyMove>().Length;

        //move to next level if all enemies are down
        if(enemyCount == 0)
		{
            //increase because level increased
            enemiesToSpawn++;

            spawnPowerUp();
			
            spawnEnemies(enemiesToSpawn);
		}

    }
    //method for spawning enemies
    void spawnEnemies(int num) 
    {

        //more enemies per level
		for (int i = 0; i < num; i++)
		{
            Instantiate(enemy, generatePosition(), enemy.transform.rotation);
        }
    }

    //to spawn powerups
    void spawnPowerUp()
	{
        Instantiate(powerUp, generatePosition(), powerUp.transform.rotation);
	}

    //generates a random position to spawn enemies
    Vector3 generatePosition()
	{
        Vector3 spawn = new Vector3(Random.Range(-xSpawn, xSpawn), 1, Random.Range(-zSpawn, zSpawn));
        return spawn;
    }
}
