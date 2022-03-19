using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class CarController : MonoBehaviour
{

    [SerializeField] private float speed = 20f;
    private bool move; 
    private bool isGrounded; 

    
    [SerializeField] private GameObject wheelFront; 
    [SerializeField] private GameObject wheelBack; 
    [SerializeField] private float rotationWheel; 

    private Vector3 lastPosition; 
    private Vector3 newPosition; 
    private Vector3 velocity;


    private float rotation = 0f; 
    [SerializeField] private float rotationSpeed = 2f; 

    private Rigidbody2D rb; 

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>(); 
        lastPosition = rb.transform.position; 
        newPosition = lastPosition; 
    }

    void Update()
    {
        // Get inputs 
        rotation = -Input.GetAxisRaw("Horizontal"); 
        
        if (Input.GetAxisRaw("Vertical") > 0)       move = true; 
        else                                        move = false; 
                
    }

    void FixedUpdate() 
    {

        if (move && isGrounded)
        {
            rb.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force); 


        }

        if (rotation != 0) 
        {
            rb.AddTorque(rotation * rotationSpeed * rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
        }


        // Rotate wheels 
        newPosition = rb.transform.position; 
        velocity = newPosition - lastPosition; 

        if (velocity.x > 0)  
        {
            wheelBack.transform.Rotate(0f, 0f, -rotationWheel, Space.Self);
            wheelFront.transform.Rotate(0f, 0f, -rotationWheel, Space.Self);
        }
        else if (velocity.x < 0) 
        {
            wheelBack.transform.Rotate(0f, 0f, rotationWheel, Space.Self);
            wheelFront.transform.Rotate(0f, 0f, rotationWheel, Space.Self);
        }

        lastPosition = newPosition; 


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true; 
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false; 
    }

}
