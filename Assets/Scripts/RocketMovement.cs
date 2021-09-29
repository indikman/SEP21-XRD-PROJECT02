using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float movementSpeed = 50f;
    public float rotateSpeed = 20f;

    public Rigidbody rocketBody;


    public GameObject laserPrefab;
    public Transform spawnPoint;
    public float shootForce = 200f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if ( Input.GetKey(KeyCode.W)  )
        {
            // Apply a force to the rocket 
            rocketBody.AddForce(transform.forward * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            // Apply a force to the rocket 
            rocketBody.AddForce(transform.right * Time.deltaTime * movementSpeed * -1); // right * -1 = left
        }

        if (Input.GetKey(KeyCode.S))
        {
            // Apply a force to the rocket 
            rocketBody.AddForce(transform.forward * Time.deltaTime * movementSpeed * -1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            // Apply a force to the rocket 
            rocketBody.AddForce(transform.right * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.E))
        {
            // Apply a force to the rocket 
            rocketBody.AddTorque(0, 0, rotateSpeed*Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            // Apply a force to the rocket 
            rocketBody.AddTorque(0, 0, rotateSpeed * Time.deltaTime * -1);
        }


        // If i am not pressing WASD keys, then it should decelerate
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A)  && !Input.GetKey(KeyCode.S)  && !Input.GetKey(KeyCode.D))
        {
            // stop the rocket movement
            rocketBody.velocity = rocketBody.velocity * 0.99f;
            

        }

      
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        if(horizontalRotation == 0 && verticalRotation == 0)
        {
            rocketBody.angularVelocity = rocketBody.angularVelocity * 0.9f;
        }


       // Debug.Log("X : " + horizontalRotation + "  " + "Y : " + verticalRotation);

        // Only apply the torque if Right click is pressed and held
        if (Input.GetMouseButton(1))
        {
            // Get the axis input and apply the torque
            rocketBody.AddTorque(verticalRotation * Time.deltaTime * rotateSpeed, horizontalRotation * Time.deltaTime * rotateSpeed, 0);

        }


        // If I press the mouse click, shoot a laser
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // create a new laser
            GameObject tempLaser = Instantiate(laserPrefab, spawnPoint.position, spawnPoint.rotation);

            // SHOOT!!
            tempLaser.GetComponent<Rigidbody>().AddForce(shootForce * spawnPoint.forward);

            Destroy(tempLaser, 5.0f);

            
        }
        

    }
}
