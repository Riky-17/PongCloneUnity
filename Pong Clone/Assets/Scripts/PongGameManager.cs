using System.Collections;
using System.Collections.Generic;
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

    Vector3 LaunchDir()
    {
        return isPlayerTurn ? new(-CosAngLaunch, SinAngLaunch) : new(CosAngLaunch, SinAngLaunch);
    }

    public void PrepareAnotherGame()
    {
        isPlayerTurn = !isPlayerTurn;
        Ball.Instance.SetDirection(LaunchDir());
        Ball.Instance.ResetSpeed();
    }

    public void PauseToggle()
    {
        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? 0 : 1;
        pauseScreen.SetActive(isGamePaused);
    }

    public float GetStartTimer()
    {
        return startGameTimer;
    }
}
