using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance {get; private set;}

    float speed = 7f;
    Vector3 direction;
    //Vector3 direction = (Vector3.left + Vector3.up).normalized;
    //Vector3 direction = Vector3.left;

    Rigidbody2D rb;

    void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    // void Update()
    // {
    //     transform.position += speed * Time.deltaTime * direction;
    // }

    void FixedUpdate()
    {
        CheckCollision();
    }

    private void CheckCollision()
    {
        rb.velocity = direction * speed;

        RaycastHit2D hit = Physics2D.BoxCast(transform.position, transform.localScale, 0, direction, speed * Time.deltaTime);

        // if(hit.transform == null)
        // {
        //     hit = Physics2D.BoxCast(transform.position, transform.localScale, 0, -direction, speed * Time.deltaTime);
        // }

        if(hit.transform == null)
            return;

        if (hit.transform.gameObject.TryGetComponent(out Player player))
        {
            direction = (transform.position - player.transform.position).normalized;
            speed = 20f;
        }
        else if (hit.transform.gameObject.TryGetComponent(out Enemy enemy))
        {
            direction = (transform.position - enemy.transform.position).normalized;
            speed = 20f;
        }
        else
        {
            direction = Bounce(hit.normal);
        }
    }

    private Vector3 Bounce(Vector3 surfaceNormal)
    {
        float p = Vector2.Dot(direction, surfaceNormal);
        return direction - 2 * p * surfaceNormal;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
