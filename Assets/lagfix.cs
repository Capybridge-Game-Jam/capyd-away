using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lagfix : MonoBehaviour
{
    static bool PointIsVisibleToCamera(Vector2 point)
    {
        if (Camera.main.WorldToViewportPoint(point).x < -0.2 || Camera.main.WorldToViewportPoint(point).x > 1.2 || Camera.main.WorldToViewportPoint(point).y > 1.2 || Camera.main.WorldToViewportPoint(point).y < -0.2)
            return false;
        return true;
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
