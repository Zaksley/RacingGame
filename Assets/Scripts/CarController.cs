using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedMax = 15000f; 
    public float speedAcceleration = 300f; 
    public float speedBrake = 800f;
    public float rotationSpeed = 15f; 
    private float movement = 0f; 
    private float rotation = 0f; 
    [SerializeField] private WheelJoint2D backWheel; 
    [SerializeField] private WheelJoint2D frontWheel; 
    
    private Rigidbody2D rb; 

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>(); 
        speedMax = -speedMax;
    }

    // Update is called once per frame
    void Update()
    {
        
        rotation = Input.GetAxisRaw("Horizontal"); 

        // if previously 0, start motor with speed

        /*
        if (movement == 0f) 
        {
            movement = -Input.GetAxisRaw("Vertical") * speed;
        }
        else 
        {
            movement += -Input.GetAxisRaw("Vertical") * incrSpeed * Time.deltaTime; 
        }
        */

        // Acceleration and brake
        if (-Input.GetAxisRaw("Vertical") == -1f)       movement += -Input.GetAxisRaw("Vertical") * speedAcceleration * Time.deltaTime;
        else if (-Input.GetAxisRaw("Vertical") == 1f)   movement += -Input.GetAxisRaw("Vertical") * speedBrake * Time.deltaTime;
        
        // Controls motor
        if (movement > 0)   movement = 0;
        if (movement <= speedMax) movement = speedMax; 
    }

    void FixedUpdate() {

        if (movement == 0f) 
        {
            backWheel.useMotor = false; 
            frontWheel.useMotor = false; 
            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = backWheel.motor.maxMotorTorque }; 
            backWheel.motor = motor; 
            frontWheel.motor = motor; 
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
