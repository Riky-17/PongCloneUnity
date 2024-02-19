using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 12f;
    bool canMove = true;
    float wedgeOffset = .1f;
    
    float Wedge(Vector3 a, Vector3 b) => a.x * b.y - a.y * b.x;

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveDir;
        float ballSide = GetBallSide(-transform.right, Ball.Instance.transform.position, transform.position);

        if (ballSide > wedgeOffset)
        {
            moveDir = Vector2.down;
        }
        else if (ballSide < -wedgeOffset)
        {
            moveDir = Vector2.up;
        }
        else
        {
            moveDir = Vector2.zero;
        }

        canMove = !Physics2D.Raycast(transform.position, moveDir, transform.localScale.y / 2 + speed * Time.deltaTime);

        if (canMove)
            transform.position += speed * Time.deltaTime * (Vector3)moveDir;
    }

    float GetBallSide(Vector2 a, Vector2 b, Vector2 pt)
    {
        Vector2 bPt = (b - pt).normalized;

        return Wedge(a, bPt);
    }
}
