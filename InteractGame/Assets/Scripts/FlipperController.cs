using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    
    public float flipperDamper;
    HingeJoint2D hinge;
    public KeyCode activationKey; // Key to activate the flipper
    public float flipperVelocity; // Speed of the flip

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
        JointMotor2D motor = hinge.motor;
        motor.maxMotorTorque = flipperDamper;
        hinge.motor = motor;
        hinge.useMotor = true;
    }

    void Update()
    {
        JointMotor2D motor = hinge.motor;
        if (Input.GetKey(activationKey))
        {
            motor.motorSpeed = -flipperVelocity;
        }
        else
        {
            motor.motorSpeed = flipperVelocity;
        }
        hinge.motor = motor;
    }

        
}

