using UnityEngine;

public class Owl : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer rendererOwl;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float speed = 20.0f;

    Vector3 eggPosition;
    Vector3 initialPosition;

    public Vector3 EggPostion 
    {
        get { return eggPosition; }
        set { eggPosition = value; }
    }

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        rendererOwl = GetComponent<SpriteRenderer>();
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

    private void Update()
    {
        switch (state)
        {
            case State.FALLING:
                body.velocity = (eggPosition - transform.position).normalized * speed;
                if (Vector3.Distance(transform.position, eggPosition) < 0.1f) //TODO magic number
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
                if(Vector3.Distance(transform.position, initialPosition) < 0.1f) //TODO magic number
                {
                state = State.DESTROY;
                }
                break;

            case State.DESTROY:
                Destroy(gameObject);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            audioSource.Play();
        }
    }
}
