using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] GameObject owl;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.GetComponent<PlayerController>().AddEgg(value);
            if(owl != null)
            {
                GameObject.Instantiate(owl, new Vector2(transform.position.x + 4, transform.position.y + 2.5f), Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
