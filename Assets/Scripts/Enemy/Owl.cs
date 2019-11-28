﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField] float speed = 20.0f;

    [SerializeField] public Vector3 targetChase;
    Vector3 eggPosition;
    Vector3 initialposition;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        eggPosition = targetChase;
        initialposition = transform.position;
    }
    
    enum State
    {
        FALLING,
        WAITING,
        GOINGUP,
        DESTROY
    }
    State state = State.FALLING;
    void Update()
    {
        switch (state)
        {
            case State.FALLING:
                body.velocity = (eggPosition - transform.position).normalized * speed;
                if (Vector3.Distance(transform.position, eggPosition) < 0.1f)
                {
                    state = State.WAITING;
                }
                break;

            case State.WAITING:
                state = State.GOINGUP;
                break;

            case State.GOINGUP:
                body.velocity = (initialposition - transform.position).normalized * speed;
                if (transform.position == initialposition)
                {
                state = State.DESTROY;
                }
                break;

            case State.DESTROY:
                Destroy(gameObject);
                break;
        }

                if (body.velocity.x <= 0)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }

    }
}
