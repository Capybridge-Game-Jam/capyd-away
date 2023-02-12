using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridShadows : MonoBehaviour
{

    public GameObject capybara;
    public GameObject shadowCast;
    public GameObject foregroundTilemapObject;
    public Rect rect = new Rect(new Vector2(-8, 4), new Vector2(8, -4));
    private Tilemap tilemap;
    
    // // Start is called before the first frame update
    public void Start() {
        tilemap = foregroundTilemapObject.GetComponent<Tilemap>();
        int i = 0;
        foreach (var position in tilemap.cellBounds.allPositionsWithin) {
            if (tilemap.GetTile(position) == null)
                continue;
         
            GameObject shadowCaster = GameObject.Instantiate(shadowCast, this.transform);
            // shadowCaster.GetComponent<ShadowCaster2D>().enabled = false;
            shadowCaster.transform.position = new Vector2(position.x + 0.5f, position.y + 0.5f);
            shadowCaster.name = "shadow_caster_" + i;
            i++;
        }
    }

    // public void Update() {
    //     rect.position = capybara.transform.position;
    //     foreach (var position in tilemap.cellBounds.allPositionsWithin) {
    //         if (tilemap.GetTile(position) == null)
    //             continue;
    //         GameObject shadowCaster = GameObject.Find("shadow_caster_" + position.x + "_" + position.y);
    //         if (shadowCaster == null) {
    //             if (rect.Contains(new Vector2(position.x + 0.5f, position.y + 0.5f))) {
    //                 shadowCaster.GetComponent<UnityEngine.Rendering.Universal.ShadowCaster2D>().enabled = true;
    //             } else {
    //                 shadowCaster.GetComponent<UnityEngine.Rendering.Universal.ShadowCaster2D>().enabled = false;
    //             }
    //         } 
    //     }
    // }

    // public void OnTriggerEnter2D(Collider2D other) {
    //     if (other.gameObject.layer == 11) {
    //         other.GetComponent<UnityEngine.Rendering.Universal.ShadowCaster2D>().enabled = true;
    //     }
    // }

    // public void OnTriggerExit2D(Collider2D other) {
    //     if (other.gameObject.layer == 11) {
    //         other.GetComponent<UnityEngine.Rendering.Universal.ShadowCaster2D>().enabled = false;
    //     }
    // }
}
