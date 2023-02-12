using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{

    public GameObject bg1;
    public GameObject bg2;

    public float speedMult = 200;
    public Vector3 centre = new Vector3(20, 50, 19);

    // Update is called once per frame
    void Update() {
        bg1.transform.localPosition = this.transform.localPosition + (centre - this.transform.position) * speedMult;
    }
}
