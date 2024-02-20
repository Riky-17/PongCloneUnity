using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI Instance {get; private set;}

    [SerializeField] TextMeshProUGUI playerScore;
    [SerializeField] TextMeshProUGUI enemyScore;

    void Awake() => Instance = this;

    public void UpdatePlayerScore(int score) => playerScore.text = score.ToString();

    public void UpdateEnemyScore(int score) => enemyScore.text = score.ToString();
}
