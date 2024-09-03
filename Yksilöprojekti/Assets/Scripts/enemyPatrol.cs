using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb2d;
    private Transform currentPoint;
    private SpriteRenderer spriteRenderer;
    public float speed;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (isChasing)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else
        {

            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }

            Vector2 point = currentPoint.position - transform.position;
            if (currentPoint == pointB.transform)
            {
                rb2d.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb2d.velocity = new Vector2(-speed, 0);
            }

            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
            {
                spriteRenderer.flipX = true;
                currentPoint = pointA.transform;
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
            {
                spriteRenderer.flipX = false;
                currentPoint = pointB.transform;
            }
        }
        
    }
}
