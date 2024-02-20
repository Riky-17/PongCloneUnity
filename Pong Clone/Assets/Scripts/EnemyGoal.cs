using UnityEngine;

public class EnemyGoal : MonoBehaviour
{
    int score;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            ball.ResetBallPos();
            score++;
            ScoreUI.Instance.UpdateEnemyScore(score);
            PongGameManager.Instance.PrepareAnotherGame();
        }
    }
}
