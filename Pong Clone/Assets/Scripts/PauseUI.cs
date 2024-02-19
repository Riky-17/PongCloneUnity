using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;

    void Awake()
    {
        resumeButton.onClick.AddListener(() => 
        {
            PongGameManager.Instance.PauseToggle();
        });
        
        mainMenuButton.onClick.AddListener(() => 
        {
            Loader.LoadScene(Scenes.MainMenu);
        });

    }
}
