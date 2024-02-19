using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] Button startGameButton;
    [SerializeField] Button exitButton;

    void Awake()
    {
        startGameButton.onClick.AddListener(() =>
        {
            Loader.LoadScene(Scenes.Pong);
        });

        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
