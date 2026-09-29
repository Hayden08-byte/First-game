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
    
    



    


    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("jump");
        crouchAction = InputSystem.actions.FindAction("crouch");

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr= GetComponent<SpriteRenderer>();
        


    }

    // Update is called once per frame
    void Update()
    {
        // read the x-axis and output it to the rigidbody
        Vector2 moveVel = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveVel.x * 6, rb.linearVelocity.y);

       

        


        if (rb.linearVelocityX != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        if (crouchAction.IsPressed())
        {
            anim.SetBool("crouch", true);
        }
        else
        {
            anim.SetBool("crouch", false);
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
        if (collision.gameObject.tag == "Enemy")
        {
            int health = 40;
            health -= 1; // Reduce player health
        }
    }

   

   
    
       
    

}
