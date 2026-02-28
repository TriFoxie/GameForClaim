using System;
using UnityEngine;

public class Deer : MonoBehaviour
{
    //Deer defaults to looking at the player and moving towards it slowly.
    //Speed and rotation can be incremented using IncrementSpeed/Rotation(amount)
    
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    [Range(0,200)]
    private float collisionForceMultiplier = 1;//Wheeeeeee
    public Transform player;
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
}
