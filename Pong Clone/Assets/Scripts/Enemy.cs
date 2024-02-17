using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 12f;
    bool canMove = true;
    
    float Wedge(Vector3 a, Vector3 b) => a.x * b.y - a.y * b.x;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveDir = Vector2.zero;

        if (IsBallOnLeft(-transform.right, Ball.Instance.transform.position, transform.position) > 0)
        {
            moveDir = Vector2.down;
        }
        else if (IsBallOnLeft(-transform.right, Ball.Instance.transform.position, transform.position) < 0)
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

    float IsBallOnLeft(Vector2 a, Vector2 b, Vector2 pt)
    {
        Vector2 aPt = (a - pt).normalized;
        Vector2 bPt = (b - pt).normalized;

        return Wedge(aPt, bPt);
    }
}
