using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGameTimerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    void Update()
    {
        float timer = PongGameManager.Instance.GetStartTimer();

        timerText.text = Mathf.Ceil(timer).ToString();

        if(timer <= 0)
            gameObject.SetActive(false);
    }
}
