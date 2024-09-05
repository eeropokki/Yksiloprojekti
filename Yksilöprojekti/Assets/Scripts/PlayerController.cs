using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    private Rigidbody2D rb2d;

    private SpriteRenderer spriteRenderer;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        
    }

    private void MovePlayer()
    {
        if (Input.GetKeyDown(left))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);

            //audioManager.PlaySFX(audioManager.Walking);

            spriteRenderer.flipX = true;
        }
        else if (Input.GetKeyDown(right))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

            //audioManager.PlaySFX(audioManager.Walking);

            spriteRenderer.flipX = false;
        }
        else
        {
            if (rb2d.velocity.y != 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
            }
            else
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
        }

        if (Input.GetKeyDown(jump))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

}
