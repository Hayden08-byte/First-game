using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
   
   
    private UnityEngine.Transform player;

    private int direction; 
    private Rigidbody2D rb;
    public bool Vertical;
    public LayerMask groundLayerMask;
    SpriteRenderer sr;
    bool isGrounded;
    HelperScript helper;

    public UnityEngine.Transform targetDestination;
    private NavMeshAgent agent;
    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    private Vector3 startPos;







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        agent = GetComponent<NavMeshAgent>();
        groundLayerMask = LayerMask.GetMask("Ground");
        startPos = transform.position;
        direction = 4;
        sr = GetComponent<SpriteRenderer>();
        // Add the HelperScript to this GameObject
        // and store a reference to it
        helper = gameObject.AddComponent<HelperScript>();

    }

    // Update is called once per frame
    void Update()
    {

        bool l, r;

        l = RayCollisionCheck(-0.5f, 0);
        r = RayCollisionCheck(0.5f, 0);

        if(l == false && direction < 0 )
        {
            direction = 4;
        }

        if (r == false && direction > 0)
        {
            direction = -4;
        }

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            helper.FlipSprite(true);
        }

        


        rb.linearVelocityX = speed * direction;



        /*

        if (player != null)
        {
            // Move towards the player's position every frame
            //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        if (targetDestination != null)
        {
            // Tell the character to move to the target's position automatically
            agent.SetDestination(targetDestination.position);
        }
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;


        float distance = Vector3.Distance(transform.position, player.position);
        */
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
    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            helper.DestroyObject();
        }
    }
    */
}







