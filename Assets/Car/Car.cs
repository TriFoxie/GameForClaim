using System;
using UnityEngine;
using GameForClaim;
using UnityEditor;
using Vector2 = System.Numerics.Vector2;

public class Car : MonoBehaviour, IDamagableComponent
{
    private Rigidbody CarRB;
    private WheelCollider[] wheels;
    private IDamageCalculator damageCalculator;
    private float lastCollision;

    //Properties
    [Header("Car Data")] public string name { get; private set; }
    [SerializeField] private float value = 27000; //Cost of the car in GBP.
    [Range(0, 1)] [SerializeField] private float health = 1; //How much damage the car can withstand remaining. 0 is broken 1 is fine.
    [Range(0, 1)] [SerializeField] private float vulnerability = 0.5f; //How easily the car take damage. 0 is vulnerable 1 is strong.
    
    [Header("Driving Properties")]
    [SerializeField] private float enginePower;
    [SerializeField] private float brakingForce;
    [SerializeField] [Range(0.0f, 90.0f)] private float maxSteerAngle;
    
    private float verticalInput;
    private float horizontalInput;
    
    #region UnityFunctions
    void Start()
    {
        //Default values
        CarRB = GetComponent<Rigidbody>();
        wheels[0].motorTorque = wheels[1].motorTorque = wheels[2].motorTorque = wheels[3].motorTorque = 0.00001f;
        damageCalculator = DamageCalculator.GetInstance();
        lastCollision = float.MinValue;
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

    private void OnCollisionEnter(Collision other)
    {
        if (Time.time - lastCollision > 1f)
        {
            damageCalculator.CalculateDamage(this, other.gameObject.GetComponent<IDamagableComponent>());
        }
        lastCollision = Time.time;
        Debug.Log("<color=red>CRASH! </color> New Value: " + damageCalculator.GetValueOfCurrentDamage());
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

    #region IDamagableComponent
    public float GetUndamagedValue()
    {
        return value;
    }

    public Vector2 GetMovement()
    {
        return new Vector2(CarRB.linearVelocity.x, CarRB.linearVelocity.z);
    }

    public decimal GetVulnerability()
    {
        return (decimal)vulnerability;
    }

    public decimal GetHealthLevel()
    {
        return (decimal)health;
    }

    public void SetNewHealthLevel(decimal newHealthLevel)
    {
        health = (float)newHealthLevel;
    }
    #endregion
}
