using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object we touched has the "Enemy" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the player game object
            Destroy(gameObject);
        }
    }
}
