using System;
using UnityEngine;

public class Deer : MonoBehaviour
{
    //Deer defaults to looking at the player and moving towards it slowly.
    //Speed and rotation can be incremented using IncrementSpeed/Rotation(amount)
    
    [SerializeField]
    private float speed = 1;
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
        transform.LookAt(player);
        rb.useGravity = false;
    }
    private void Update()
    {
        Move();
    }
    private void OnCollisionEnter(Collision other)
    {
        speed = 0;
        rb.useGravity = true;
    }
}
