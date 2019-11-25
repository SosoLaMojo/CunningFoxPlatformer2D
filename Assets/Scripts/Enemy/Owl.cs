using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField] float speed;

    [SerializeField] Transform targetChase;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Vector3 velocity = (targetChase.position - transform.position).normalized * speed;
        velocity = new Vector3(velocity.x, body.velocity.y, 0);
        Debug.Log("Hello");
    }
}
