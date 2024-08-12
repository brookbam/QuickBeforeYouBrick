using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    //cached reference
    Ball myBall;
    Lives life1;
    Lives2 life2;

    private void Start()
    {
        myBall = FindObjectOfType<Ball>();
        life1 = FindObjectOfType<Lives>();
        life2 = FindObjectOfType<Lives2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameSession.lives > 1)
        {
            GameSession.lives--;
            Ball.hasStarted = false;
        }else
        {
            DontDestroyOnLoad(GameObject.Find("Game Canvas For Speed"));
            SceneManager.LoadScene("Game Over");
            Ball.hasStarted = false;
        }
        /*if (GameSession.lives < 3 && (life2 != null))
        {
            life2.TakeAwayLife();
        }
        if (GameSession.lives < 2 && (life1 != null))
        {
            life1.TakeAwayLife();
        }*/
    }

}
