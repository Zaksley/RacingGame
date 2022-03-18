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


    private float rotation = 0f; 
    [SerializeField] private float rotationSpeed = 2f; 

    private Rigidbody2D rb; 

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>(); 
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
