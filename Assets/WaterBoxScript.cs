using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoxScript : MonoBehaviour
{

    public GameObject pumpUpwardsForce;
    public GameObject capybara;
    public ParticleSystem waterParticles;

    void Start() {
        waterParticles.Stop();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "pumpTrigger") {
            pumpUpwardsForce.GetComponent<BoxCollider2D>().enabled = true;
            waterParticles.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "pumpTrigger") {
            pumpUpwardsForce.GetComponent<BoxCollider2D>().enabled = false;
            waterParticles.Stop();
        }
    }
}
