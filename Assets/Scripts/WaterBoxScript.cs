using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoxScript : MonoBehaviour
{

    public GameObject pumpUpwardsForce;
    public GameObject capybara;
    public ParticleSystem waterParticles;
    public bool isFlowing;
    public int height = 5;

    void Start() {
        if (isFlowing) {
            enableWaterFlow();
        } else {
            disableWaterFlow();
        }
    }

    void enableWaterFlow() {
        pumpUpwardsForce.GetComponent<BoxCollider2D>().enabled = true;
        waterParticles.Play();
        pumpUpwardsForce.transform.localPosition = new Vector2(pumpUpwardsForce.transform.localPosition.x, height/2);
        pumpUpwardsForce.transform.localScale = new Vector2(pumpUpwardsForce.transform.localScale.x, height);
        var main = waterParticles.main;
        main.startSpeed = height*3;
    }

    void disableWaterFlow() {
        pumpUpwardsForce.GetComponent<BoxCollider2D>().enabled = false;
        waterParticles.Stop();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "pumpTrigger") {
            enableWaterFlow();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "pumpTrigger") {
            disableWaterFlow();
        }
    }
}
