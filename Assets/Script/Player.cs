using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;
public class Player : MonoBehaviour
{
    //declare the variables
    InputAction moveAction;
    Rigidbody2D rb;
    InputAction jumpAction;
    InputAction lookAction;
    InputAction crouchAction;
    bool isGrounded;
    Animator anim;
    SpriteRenderer sr;
    HelperScript helper;
    bool TabkeyisPressed;
    InputAction attackAction;
    public GameObject weapon;






    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("jump");
        crouchAction = InputSystem.actions.FindAction("crouch");
        attackAction = InputSystem.actions.FindAction("Attack");


        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        helper = gameObject.AddComponent<HelperScript>();


    }

    // Update is called once per frame
    void Update()
    {
        // read the x-axis and output it to the rigidbody
        Vector2 moveVel = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveVel.x * 6, rb.linearVelocity.y);


        /*
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            helper.DestroyObject();
        }
        */
        // Walking motion code
        if (rb.linearVelocityX != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
        // Crouching motion code
        if (crouchAction.IsPressed())
        {
            anim.SetBool("crouch", true);
        }
        else
        {
            anim.SetBool("crouch", false);
        }

        // The attacking code 
        if (attackAction.WasPressedThisFrame() &&)
        {
            // Initation of the weapon at the position and rotation 
            GameObject clone;
            clone = Instantiate(weapon, transform.position, transform.rotation);

            // for the 2D Rigidbody Component
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
            
            //set the x velocity to 15 and y to 0
            rb.linearVelocity = new Vector2(15, 0);

            // set position close to the player 
            rb.transform.position = new Vector3(transform.position.x, transform.position.y +
            2,transform.position.z + 1);
        }
        



        Jump();

        FlipSprite();


        print("grounded=" + isGrounded);








        //Jump
        void FlipSprite()
        {
            if (rb.linearVelocityX < -0.1f)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
        void Jump()
        {
            if (jumpAction.WasPressedThisFrame())
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 10);

            }
        }
    }





    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            helper.DestroyObject();
        }
        if (collision.gameObject.tag == "Killercoins")
        {
        
            helper.DestroyObject();
        }
    
    }



    





}
