using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoal : MonoBehaviour
{
    int score = 0;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            ball.transform.position = Vector3.zero;
            score++;
            ScoreUI.Instance.UpdatePlayerScore(score);
            PongGameManager.Instance.PrepareAnotherGame();
        }
    }
}
