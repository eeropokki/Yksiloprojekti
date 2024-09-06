using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class PowerUpBlock : MonoBehaviour
{

    [SerializeField] Sprite inactiveSprite;
    [SerializeField] private GameObject powerUp;

    private bool used;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<PlayerController>();

        if (!used && player != null && other.contacts[0].normal.y > 0)
        {
            //Spawn powerUp
            GetComponent<SpriteRenderer>().sprite = inactiveSprite;
            Instantiate(powerUp, transform.position, Quaternion.identity);
        }
    }
}
