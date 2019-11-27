using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField] float speed = 20.0f;

    [SerializeField] public Vector3 targetChase;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //Debug.Log(targetChase);
    }
    
    void Update()
    {
        Vector3 velocity = (-transform.position + targetChase);
        //Debug.Log(targetChase.position);
        //Debug.Log(transform.position);
        //Debug.Log(velocity);
        velocity = new Vector3(velocity.x, velocity.y, 0).normalized;
        body.velocity = velocity * speed;
       
       // Debug.Log(body.velocity);
    }
}
