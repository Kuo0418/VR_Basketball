using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("籃球場");
    }

    public void QuitGame()
    {
        //應用程式.離開遊戲
        Application.Quit();
    }
}
