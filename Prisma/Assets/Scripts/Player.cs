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

    void Awake()
    {
        playerRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }

        moveDir = new Vector3(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        playerRigidBody2D.velocity = moveDir * moveSpeed;
    }

    
}

