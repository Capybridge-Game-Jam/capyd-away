using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyShrooms : MonoBehaviour
{
    public float bounceForce;
    public GameObject torchColour;
    public GameObject torchPedestal;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (torchColour.GetComponent<SpriteRenderer>().color == torchPedestal.GetComponent<SpriteRenderer>().color) {
            // Check if the player has collided with the mushroom from above
            // && other.contacts[0].normal.y > 0.5f
            if (other.gameObject.tag == "Player")
                {
        
                Rigidbody2D playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
                Debug.Log("Collision");
                if (playerRigidbody != null) {
                    playerRigidbody.velocity = new Vector2(0, 0);
                    playerRigidbody.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
                }
            }
        }
        
    }
    
    
}
