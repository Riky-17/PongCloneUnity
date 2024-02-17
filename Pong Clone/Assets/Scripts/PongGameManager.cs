using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongGameManager : MonoBehaviour
{
    public static PongGameManager Instance {get; private set;}

    int cosAngDegLaunch => Random.Range(0, 46);
    int sinAngDegLaunch => Random.Range(-45, 46);
    float cosAngLaunch => Mathf.Cos(cosAngDegLaunch * Mathf.Deg2Rad / 2);
    float sinAngLaunch => Mathf.Sin(sinAngDegLaunch * Mathf.Deg2Rad / 2);

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
        if (isPlayerTurn)
        {
            return new(-cosAngLaunch, sinAngLaunch);
        }

        return new(cosAngLaunch, sinAngLaunch);
    }

    public void PrepareAnotherGame()
    {
        isPlayerTurn = !isPlayerTurn;
        Ball.Instance.SetDirection(LaunchDir());
        Ball.Instance.SetSpeed(7f);
    }
}
