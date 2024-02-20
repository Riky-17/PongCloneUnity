using UnityEngine;

public class PongGameManager : MonoBehaviour
{
    public static PongGameManager Instance {get; private set;}

    int CosAngDegLaunch => Random.Range(0, 46);
    int SinAngDegLaunch => Random.Range(-45, 46);
    float CosAngLaunch => Mathf.Cos(CosAngDegLaunch * Mathf.Deg2Rad / 2);
    float SinAngLaunch => Mathf.Sin(SinAngDegLaunch * Mathf.Deg2Rad / 2);

    bool isPlayerTurn = true;

    bool isGamePaused = false;
    [SerializeField] GameObject pauseScreen;

    float startGameTimer = 3f;
    bool isFirstThrow = true;
    [SerializeField] GameObject startGameTimerUI;

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1;
    }

    void Update()
    {
        if(startGameTimer > 0)
            startGameTimer -= Time.deltaTime;
        
        if(startGameTimer <= 0 && isFirstThrow)
        {
            Ball.Instance.SetDirection(LaunchDir());
            isFirstThrow = false;
        }
    }

    public void PrepareAnotherGame()
    {
        isPlayerTurn = !isPlayerTurn;
        Ball.Instance.SetDirection(LaunchDir());
        Ball.Instance.ResetSpeed();
    }

    public void RestartMatch()
    {
        if(startGameTimer > 0)
            return;

        Ball.Instance.ResetBallPos();
        Ball.Instance.SetDirection(Vector2.zero);
        Ball.Instance.ResetSpeed();
        startGameTimer = 3f;
        startGameTimerUI.SetActive(true);
        isFirstThrow = true;
    }

    public void PauseToggle()
    {
        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? 0 : 1;
        pauseScreen.SetActive(isGamePaused);
    }

    Vector3 LaunchDir() => isPlayerTurn ? new(-CosAngLaunch, SinAngLaunch) : new(CosAngLaunch, SinAngLaunch);

    public float GetStartTimer() => startGameTimer;
}
