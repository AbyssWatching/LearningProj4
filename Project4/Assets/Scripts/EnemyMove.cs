using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    public float speed = 4;
    
    //get player info and enemyRB for movement
    private Rigidbody enemyRB;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        //gets rb for movement
        enemyRB = gameObject.GetComponent<Rigidbody>();
        
        //gets GO of player
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        //sets up movement
        Vector3 moving = (player.transform.position - transform.position).normalized;
        
        //moves enemy to player
        enemyRB.AddForce( moving * speed);

        


    }
}
