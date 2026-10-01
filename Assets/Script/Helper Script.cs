using UnityEngine;

public class HelperScript : MonoBehaviour
{
     
    

    public void FlipSprite(bool flip)
    {
        // Get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
    //to destroy the game object
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
