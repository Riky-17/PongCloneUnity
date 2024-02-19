using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoal : MonoBehaviour
{
    int score;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            ball.transform.position = Vector3.zero;
            score++;
            ScoreUI.Instance.UpdateEnemyScore(score);
            PongGameManager.Instance.PrepareAnotherGame();
        }
    }
}
