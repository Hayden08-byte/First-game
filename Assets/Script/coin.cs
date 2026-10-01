using UnityEngine;

public class coin : MonoBehaviour
{
    HelperScript helper;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            helper.DestroyObject();
        }
    }
}
