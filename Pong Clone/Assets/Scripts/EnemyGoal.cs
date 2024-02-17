using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoal : MonoBehaviour
{
    Enemy enemy;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            ball.transform.position = Vector3.zero;
            PongGameManager.Instance.PrepareAnotherGame();
        }
    }
}
