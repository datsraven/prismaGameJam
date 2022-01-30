using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public RaycastHit2D hit;
    
    public float moveSpeed;
    private Rigidbody2D playerRigidBody2D;
    private Vector3 moveDir;

    float moveX;
    float moveY;
    Vector2 input;

    void Awake()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        moveX = 0.0f;
        moveY = 0.0f;
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (Slideshow.bPlaying)
        {
            moveX = moveY = 0.0f;
        }

        input = new Vector2(moveX, moveY);
        input = input.normalized * Mathf.Clamp01(input.magnitude); 
    }

    void FixedUpdate()
    {
        playerRigidBody2D.velocity = (input * moveSpeed * Time.fixedDeltaTime);
    }

    
}

