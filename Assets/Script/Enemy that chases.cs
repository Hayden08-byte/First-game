using System.Diagnostics.Metrics;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;



public class enemythatchases : MonoBehaviour
{
    public LayerMask groundLayerMask;
    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 1.0f;
    private Vector3 startPos;
    private int direction;
    SpriteRenderer sr;
    Rigidbody2D rb;
    public GameObject player;
    int Counter;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        direction = 4;
    }
      
// Update is called once per frame
    void Update()
    {
        print("player x position is " + player.transform.position.x);
        print("enemy x position is " + transform.position.x);

        if (Counter == 0f)
        {
            if (player.transform.position.x < transform.position.x)
            {
                direction = -4;
            }

            if (player.transform.position.x > transform.position.x)
            {
                direction = 4;
            }
        }
        FlipSprite();

        rb.linearVelocityX = speed * direction;
    }
    void FlipSprite()
    {
        if (player.transform.position.x < transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
    public bool RayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward starting at the sprite's position
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, groundLayerMask);

        Color hitColor = Color.red;
       
        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray's position
        // You need to enable gizmos in th e editor to see these
        Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, hitColor);
        return hitSomething;
    }
     
}
