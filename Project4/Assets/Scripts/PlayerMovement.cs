using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    //Setting up vars
    public float speed = 10;
    public float forwardMovement;
    public bool hasPowerUP;

    //since we are using the .addforce we need to set up to use component rigibody
    public Rigidbody playerRB;

    //getting the focal point GO so we can make moving forward the way the camera is facing
    public GameObject focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        //since we only need to get the component once we can get it in start
        playerRB = GetComponent<Rigidbody>();

        //gets the GO FocalPoint
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //getting the input for forward motion
        forwardMovement = Input.GetAxis("Vertical");




        //pushes the player in the direction of the comera facing
        playerRB.AddForce(focalPoint.transform.forward * forwardMovement * speed);

    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("PowerUp"))
		{
            Destroy(other.gameObject);
            hasPowerUP = true;
		}
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		
	}

}
