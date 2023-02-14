using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lagfix : MonoBehaviour
{
    void OnBecameVisible()
    {
         this.GetComponent<UnityEngine.Rendering.Universal.ShadowCaster2D>().enabled = true;
    }
 
    void OnBecameInvisible()
    {
         this.GetComponent<UnityEngine.Rendering.Universal.ShadowCaster2D>().enabled = false;
	}
}
