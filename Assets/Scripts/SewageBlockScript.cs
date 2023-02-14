using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewageBlockScript : MonoBehaviour
{
    public GameObject flame;
    public GameObject torchColour;
    public ParticleSystem sewageParticles;
    public BoxCollider2D sewageCollider;
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("hello");
        if (other.gameObject.tag == "Player") {
            if (flame.GetComponent<SpriteRenderer>().color == torchColour.GetComponent<SpriteRenderer>().color) {
                sewageCollider.enabled = false;
                sewageParticles.Stop();
            }
        }
    }
}
