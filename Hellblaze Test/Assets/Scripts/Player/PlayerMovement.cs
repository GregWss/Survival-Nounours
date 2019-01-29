using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public Camera playerCamera;

    Vector3 movement;
    Vector3 jumpForce;
    Animator anim;
    Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per frame, but is attached to physics of the character
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Animating(h, v);
    }

    // Applying movement to the player
    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);

        /* Speed : speed of the character
        *  Time.deltaTime : in order to not move by the distance every frame
        */
        movement = movement.normalized * playerCamera.transform.forward * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    // Animating the player
    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f; // if h or v != 0
        anim.SetBool("isWalking", walking);
    }
}