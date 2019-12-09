using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] GameObject owl;
    [SerializeField] AudioClip eggSound;
    AudioSource audioSource;

    private bool isActive = true;

    private void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && isActive)
        {
            other.GetComponent<PlayerController>().AddEgg(value);

            if(owl)
            {
                GameObject Enemy = Instantiate(owl, new Vector2(transform.position.x + 4, transform.position.y + 2.5f), Quaternion.identity);
                Enemy.GetComponent<Owl>().EggPostion = transform.position;
            }

            if (eggSound)
            {
                audioSource.Play();
            }
            isActive = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
