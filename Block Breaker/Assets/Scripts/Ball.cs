using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.1f;
    [Range(1f, 1.05f)] [SerializeField] float speedUpFactor = 1f;
    [SerializeField] TextMeshProUGUI speedText;


    //state
    Vector2 paddleToBallVector;
    public static bool hasStarted = false;
    [SerializeField] double ballSpeed = 0;

    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    Lives life1;
    Lives2 life2;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        life1 = FindObjectOfType<Lives>();
        life2 = FindObjectOfType<Lives2>();
        DifficultySetting();    
        speedText.text = ballSpeed.ToString() + " m/s";
    }

    // Update is called once per frame
    void Update()
    {
        CurrentSpeed();
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        speedText.text = ballSpeed.ToString() + " m/s";
        if (GameSession.lives < 3 && (life2 != null))
        {
            life2.TakeAwayLife();
        }
        if (GameSession.lives < 2 && (life1 != null))
        {
            life1.TakeAwayLife();
        }
    }

    public void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    public void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (UnityEngine.Random.Range(-randomFactor/4, randomFactor/4), 
            UnityEngine.Random.Range(-randomFactor, 0)); 

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
            myRigidBody2D.velocity *= speedUpFactor;
        }
    }

    public double CurrentSpeed()
    {
            ballSpeed = Math.Round(Math.Sqrt((Math.Pow(myRigidBody2D.velocity.x, 2.0) + Math.Pow(myRigidBody2D.velocity.y, 2.0))));
            return ballSpeed;
    }

    private void DifficultySetting()
    {
        if (GameSession.difficulty == 1)
        {
            yPush = 13f;
            speedUpFactor = 1.001f;
        }
        else if (GameSession.difficulty == 2)
        {
            yPush = 14f;
            speedUpFactor = 1.003f;
        }
        else if (GameSession.difficulty == 3)
        {
            yPush = 15f;
            speedUpFactor = 1.006f;
        }
    }
}
