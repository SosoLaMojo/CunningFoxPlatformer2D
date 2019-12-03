using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField] float speed = 20.0f;

    Vector3 eggPosition;
    Vector3 initialPosition;

    public Vector3 EggPostion {
        get { return eggPosition; }
        set { eggPosition = value; }
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
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
                initialPosition = new Vector2(initialPosition.x - 2 * (initialPosition.x - transform.position.x), initialPosition.y);
                break;

            case State.GOINGUP:
                body.velocity = (initialPosition - transform.position).normalized * speed;
                if(Vector3.Distance(transform.position, initialPosition) < 0.2f)
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
