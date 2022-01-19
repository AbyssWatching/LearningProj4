using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    //Setting up vars
    public float speed = 10;
    public float forwardMovement;
    private bool hasPowerUP;
    public float powerUpStrength = 15.0f;
    public GameObject powerUp;


    //since we are using the .addforce we need to set up to use component rigibody
    private Rigidbody playerRB;

    //getting the focal point GO so we can make moving forward the way the camera is facing
    private GameObject focalPoint;

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

        powerUp.transform.position = this.transform.position;


        //pushes the player in the direction of the comera facing
        playerRB.AddForce(focalPoint.transform.forward * forwardMovement * speed);

    }

	private void OnTriggerEnter(Collider other)
	{
        //only do this to things tagged power up
		if (other.CompareTag("PowerUp"))
		{
            //destroy power up to simulate picking it up
            Destroy(other.gameObject);
            
            //turn the power up on for collision detect
            hasPowerUP = true;

            powerUp.SetActive(true);

            StartCoroutine("PowerUpCountDownRoutine");

		}
		
	}

    IEnumerator PowerUpCountDownRoutine() 
    {
        yield return new WaitForSeconds(7);
        hasPowerUP = false;
        powerUp.SetActive(false);
        Debug.Log("your power up is done");

    }

    private void OnCollisionEnter(Collision collision)
	{
        //what to do when power up is on
		if (collision.gameObject.CompareTag("Enemy") && hasPowerUP)
		{
            //checking
            Debug.Log("it worked");

            //getting enemy rigibody
            Rigidbody enemyRigibody = collision.gameObject.GetComponent<Rigidbody>();

            //getting the direction to puss the enemy
            Vector3 positionToPush = (collision.gameObject.transform.position - this.transform.position);

            //pushing the enemy
            enemyRigibody.AddForce(positionToPush * powerUpStrength, ForceMode.Impulse);

		}
		
	}

}
