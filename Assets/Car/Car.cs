using System;
using UnityEngine;
using GameForClaim;
using UnityEditor;

public class Car : MonoBehaviour
{
    private Rigidbody CarRB;
    private WheelCollider[] wheels;

    //Properties
    [SerializeField]
    private float enginePower;
    [SerializeField]
    private float brakingForce;
    [SerializeField]
    [Range(0.0f, 90.0f)]
    private float maxSteerAngle;
    
    private float verticalInput;
    private float horizontalInput;
    
    #region UnityFunctions
    void Start()
    {
        //Default values
        CarRB = GetComponent<Rigidbody>();
        wheels[0].motorTorque = wheels[1].motorTorque = wheels[2].motorTorque = wheels[3].motorTorque = 0.00001f;
    }
    
    void Update()
    {
        SetInputs();
        AccelerationAndBraking();
        Steering();
    }

    private void Awake()
    {
        wheels = gameObject.GetComponentsInChildren<WheelCollider>();
        wheels[0].motorTorque = wheels[1].motorTorque = wheels[2].motorTorque = wheels[3].motorTorque = 0.00001f;
    }

    #endregion

    private void SetInputs()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    #region Movement
    private void AccelerationAndBraking()
    {
        if (verticalInput < 0)
        {
            foreach (WheelCollider wheel in wheels)
            {
                wheel.brakeTorque = brakingForce * -verticalInput;
            }
        }
        else if (verticalInput > 0)
        {
            wheels[2].motorTorque = wheels[3].motorTorque = enginePower * verticalInput;
        }
        else
        {
            foreach (WheelCollider wheel in wheels)
            {
                wheel.motorTorque = 0;
                wheel.brakeTorque = 0;
            }
        }
    }

    private void Steering()
    {
        wheels[0].steerAngle = wheels[1].steerAngle = horizontalInput * maxSteerAngle;
    }
    #endregion
}
