using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lagfix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnBecameVisible()
    {
	     enabled = true;
         this.GetComponent<UnityEngine.Rendering.Universal.ShadowCaster2D>().enabled = true;
    }
 
    void OnBecameInvisible()
    {
	     enabled = false;
         this.GetComponent<UnityEngine.Rendering.Universal.ShadowCaster2D>().enabled = false;
	}
}
