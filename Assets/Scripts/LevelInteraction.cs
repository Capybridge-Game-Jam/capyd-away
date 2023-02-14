using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInteraction : MonoBehaviour
{

    public Vector3 teleportPosition;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown("e"))
        {
            player.transform.position = teleportPosition;
        }
    }
}
