using System;
using GameForClaim;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class Deer : MonoBehaviour, IDamagableComponent
{
    //Deer defaults to looking at the player and moving towards it slowly.
    //Speed and rotation can be incremented using IncrementSpeed/Rotation(amount)
    
    [Header("Damageable Component")]
    [SerializeField] private float value = 0; //Cost of the car in GBP.
    [Range(0, 1)] [SerializeField] private float health = 1; //How much damage the car can withstand remaining. 0 is broken 1 is fine.
    [Range(0, 1)] [SerializeField] private float vulnerability = 0.1f; //How easily the car take damage. 0 is vulnerable 1 is strong.
    
    [Header("Configuration")]
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    [Range(0,200)]
    private float collisionForceMultiplier = 1;//Wheeeeeee
    
    private Transform player;
    private Rigidbody rb;

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public void IncrementSpeed(float amount)
    {
        speed += amount;
    }
    
    public void IncrementRotation(float amount)
    {
        transform.Rotate(0, amount, 0, Space.World);
    }

    private void Move()
    {
        transform.position += speed * Time.deltaTime * transform.forward;
    }

    #region Unity Functions
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindFirstObjectByType<Car>().transform;
        transform.rotation = Quaternion.LookRotation(new Vector3(player.position.x, 0, player.position.z) - new Vector3(transform.position.x, 0, transform.position.z));
        rb.useGravity = false;
    }
    private void Update()
    {
        Move();
    }
    private void OnCollisionEnter(Collision other)
    {
        float collisionSpeed = speed;
        speed = 0;
        rb.useGravity = true;
        
        rb.AddExplosionForce((other.rigidbody.mass * other.rigidbody.linearVelocity.magnitude + collisionSpeed * 200) * collisionForceMultiplier, other.transform.position, 20);
    }
    #endregion

    #region IDamageableComponent
    public float GetUndamagedValue()
    {
        return value;
    }

    public Vector2 GetMovement()
    {
        var velocity3d = speed * transform.forward;
        return new Vector2(velocity3d.x, velocity3d.z);
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
