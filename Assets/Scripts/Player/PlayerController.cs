using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    private Animator Animator;
    private SpriteRenderer playerRenderer;

    AudioSource audioSource;

    [SerializeField]
    private int egg = 0, playerLifeMax = 10;

    [SerializeField]
    private int currentPlayerLife;

    [SerializeField]
    private int owlDamage = 1, fallingDamage = 1;

    private Vector2 velocity;
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float maxSpeed = 70.0f, maxSpeedJump = 200.0f;

    [SerializeField]
    private GameObject groundCheck;

    [SerializeField]
    private LayerMask layer;

    private Vector3 startPosition;

    private float respawnPosition = -13.5f;

    [SerializeField] TextMeshProUGUI textEggScore;
    [SerializeField] TextMeshProUGUI textHeartPlayer;

    private void Start()
    {
        velocity = Vector2.zero;
        rigidBody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        currentPlayerLife = playerLifeMax;
        textHeartPlayer.text = currentPlayerLife.ToString();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // get value in the axes x and y
        float x = Input.GetAxisRaw("Horizontal");

        Animator.SetFloat("Speed", Mathf.Abs(x));

        if (x == -1)
        {
            playerRenderer.flipX = true;
        }
        else if (x == 1)
        {
            playerRenderer.flipX = false;
        }

        float y = 0;

        if (Input.GetButtonDown("Jump"))
        {
            y = 1;
            audioSource.Play();
        }

        velocity = new Vector2(x, y);

        RunAndJump(velocity);

        if (transform.position.y <= respawnPosition)
        {
            Respawn();
            if (currentPlayerLife >= 0.1f)
            {
                currentPlayerLife -= fallingDamage;
                textHeartPlayer.text = currentPlayerLife.ToString();
            }
        }
    
        PerformRunAndJump();
    }

    public void AddEgg(int value)
    {
        egg += value;
        textEggScore.text = egg.ToString();
    }

    public void RunAndJump(Vector2 _velocity)
    {
        velocity = _velocity;
    }

    private void PerformRunAndJump()
    {
        bool grounded = Physics2D.OverlapBox(groundCheck.transform.position, new Vector3(0.32f, 0.06f, 0), layer);
        bool isGrounded = grounded && Mathf.Abs(rigidBody.velocity.y) <= 0.01f;

        if (isGrounded)
        {
            rigidBody.AddForce(new Vector2(0f, velocity.y) * Time.fixedDeltaTime * maxSpeedJump, ForceMode2D.Impulse);
        }
        rigidBody.velocity = new Vector2(velocity.x * maxSpeed * Time.fixedDeltaTime, rigidBody.velocity.y);
        Animator.SetBool("IsJumping", !isGrounded);
    }

    public void Respawn()
    {
        transform.position = startPosition;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.transform.position, new Vector3(0.32f, 0.06f, 0));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (currentPlayerLife >= 0.1f)
            {
                currentPlayerLife -= owlDamage;
                textHeartPlayer.text = currentPlayerLife.ToString();
            }
        }
    }

    public int GetPlayerLife()
    {
        return currentPlayerLife;
    }
}
