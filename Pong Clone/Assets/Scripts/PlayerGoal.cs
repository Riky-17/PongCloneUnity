using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoal : MonoBehaviour
{
    Player player;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            ball.transform.position = Vector3.zero;
            PongGameManager.Instance.PrepareAnotherGame();
        }
    }
}
