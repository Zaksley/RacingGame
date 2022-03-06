using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1500f; 
    public float rotationSpeed = 15f; 
    private float movement = 0f; 
    private float rotation = 0f; 
    [SerializeField] private WheelJoint2D backWheel; 
    [SerializeField] private WheelJoint2D frontWheel; 
    
    private Rigidbody2D rb; 

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        movement = -Input.GetAxisRaw("Vertical") * speed; 
        rotation = Input.GetAxisRaw("Horizontal"); 
    }

    void FixedUpdate() {

        if (movement == 0f) 
        {
            backWheel.useMotor = false; 
            frontWheel.useMotor = false; 
        }
        else 
        {
            backWheel.useMotor = true; 
            frontWheel.useMotor = true; 

            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = backWheel.motor.maxMotorTorque }; 
            backWheel.motor = motor; 
            frontWheel.motor = motor; 
        }

        rb.AddTorque(-rotation * rotationSpeed * Time.fixedDeltaTime); 
    }
}
