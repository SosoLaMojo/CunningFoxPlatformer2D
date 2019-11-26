using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField] float speed;

    [SerializeField] Transform targetChase;

    [SerializeField] Vector3 leftOffset;
    [SerializeField] Vector3 rightOffset;

    Vector3 leftTarget;
    Vector3 rightTarget;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        leftTarget = transform.position + leftOffset;
        rightTarget = transform.position + rightOffset;
    }

    
    void Update()
    {
        Vector3 velocity = (leftTarget - transform.position).normalized * speed;
        velocity = new Vector3(velocity.x, body.velocity.y, 0);

        body.velocity = velocity;
        Debug.Log("Hello");
       // Destroy(gameObject);
    }
}
