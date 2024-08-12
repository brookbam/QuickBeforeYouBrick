using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{


    public void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameSession.difficulty = 1;
            GameSession.lives = 3; ;
        }
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < 11)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else if(GameSession.difficulty == 1)
        {
            DontDestroyOnLoad(GameObject.Find("Game Canvas For Speed"));
            SceneManager.LoadScene("Win Screen");
        }
        else if (GameSession.difficulty == 2)
        {
            DontDestroyOnLoad(GameObject.Find("Game Canvas For Speed"));
            SceneManager.LoadScene("Win Screen Medium");
        }
        else if (GameSession.difficulty == 3)
        {
            DontDestroyOnLoad(GameObject.Find("Game Canvas For Speed"));
            SceneManager.LoadScene("Win Screen Hard");
        }
    }

    public void LoadNextSceneMedium()
    {
        GameSession.difficulty = 2;
        GameSession.lives = 2;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadNextSceneHard()
    {
        GameSession.difficulty = 3;
        GameSession.lives = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        if(FindObjectOfType<GameSession>() != null)
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
        Destroy(GameObject.Find("Game Canvas For Speed"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
