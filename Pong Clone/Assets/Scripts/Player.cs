using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 12f;
    bool canMove = true;

    void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.Escape))
            PongGameManager.Instance.PauseToggle();
    }

    private void Move()
    {
        Vector3 moveDir;
        moveDir = CheckInput();
        canMove = !Physics2D.Raycast(transform.position, moveDir, transform.localScale.y / 2 + speed * Time.deltaTime);
        if (canMove)
            transform.position += speed * Time.deltaTime * moveDir;
    }

    private Vector3 CheckInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            return Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            return Vector2.down;
        }
        return Vector2.zero;
    }
}
