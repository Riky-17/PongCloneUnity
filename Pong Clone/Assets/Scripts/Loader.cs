using UnityEngine.SceneManagement;

public static class Loader
{
    public static void LoadScene(Scenes scene) => SceneManager.LoadScene(scene.ToString());
}

public enum Scenes 
{
    MainMenu,
    Pong
}
