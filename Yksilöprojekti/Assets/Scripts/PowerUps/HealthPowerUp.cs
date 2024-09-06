using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class HealthPowerUp : MonoBehaviour
{
        [SerializeField]
        private Vector2 initialVelocity;

        private Rigidbody2D rigidbody2D;
        private Collider2D collider2D;

        [SerializeField]
        private float reenableColliderAfter;

        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            collider2D = GetComponent<Collider2D>();
            collider2D.enabled = false;
            rigidbody2D.velocity = initialVelocity;
            StartCoroutine(ReenableCollider());
        }

        private IEnumerator ReenableCollider()
        {
            yield return new WaitForSeconds(reenableColliderAfter);
            collider2D.enabled = true;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var player = other.collider.GetComponent<PlayerController>();
            if (player != null)
            {
                Destroy(gameObject);
            }
        }
}
