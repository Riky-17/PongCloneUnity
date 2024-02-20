using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button restartMatchButton;

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

        restartMatchButton.onClick.AddListener(() => 
        {
            PongGameManager.Instance.RestartMatch();
            PongGameManager.Instance.PauseToggle();
        });
    }
}
