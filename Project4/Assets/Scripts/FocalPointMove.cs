using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocalPointMove : MonoBehaviour
{
    //setting up the VARS
    public float speed = 10.0f;
    public float horizontalInput;
   
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        //getting the user input as floating point
        horizontalInput = Input.GetAxis("Horizontal");
        
        //allow rotation with horizontal controls
        transform.Rotate(Vector3.up * horizontalInput * speed * Time.deltaTime);
        
    }
}
