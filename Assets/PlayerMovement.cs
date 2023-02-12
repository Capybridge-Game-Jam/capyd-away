using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour


{

    public CharacterController2D controller;
    public Animator animator;
    public GameObject flame;
    public GameObject torchLight;
    public GameObject torchAmbientLight;
    public float runSpeed = 5f;
    
    float horizontalMove = 0f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        // verticalMove = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            // animator.SetBool("isJumping", true);
        }

    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.tag == "torchColourChanger") {
            // Change the colour of the torch
            Color newColor = other.gameObject.GetComponent<SpriteRenderer>().color;
            flame.gameObject.GetComponent<SpriteRenderer>().color = newColor;
            torchLight.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = newColor;
            torchAmbientLight.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = newColor;

            ParticleSystem.MainModule settings = flame.gameObject.GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(newColor);
        }

        else if (other.gameObject.tag == "upwardsPumpForce") {
            Debug.Log("Pumping");
            Debug.Log(other.gameObject.transform.rotation);
            Vector3 otherDirection = other.gameObject.transform.position - other.gameObject.transform.parent.transform.position;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(otherDirection.normalized * 3000f);
        }
        
    }
}
