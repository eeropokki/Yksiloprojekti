using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Globaali muuttuja
    public static PlayerController instance;

    [Header("LIIKKUMINEN")]
    public bool canMove;
    public float moveSpeed = 4f;
    private Rigidbody rb;
    private Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
