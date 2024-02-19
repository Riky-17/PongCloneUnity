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

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Ball.Instance.SetDirection(LaunchDir());
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
}
