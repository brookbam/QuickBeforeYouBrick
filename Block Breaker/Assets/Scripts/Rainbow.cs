using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{

   /* public static Color[] colors = new Color[100];

    public int currentIndex;
    private int nextIndex;

    public float changeColourTime = 2.0f;

    private float lastChange = 0.0f;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        nextIndex = (currentIndex + 1) % colors.Length;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > changeColourTime)
        {
            currentIndex = (currentIndex + 1) % colors.Length;
            nextIndex = (currentIndex + 1) % colors.Length;
            timer = 0.0f;
        }
        
        SpriteRenderer renderer = GameObject.FindObjectOfType<SpriteRenderer>();
        renderer.color = Color.Lerp(colors[currentIndex], colors[nextIndex], changeColourTime);

    }

    public static void rainbowArray()
    {
        for (int i = 0; i < 100; i += 1)
        {
            colors[i] = (i, 1, 1, 1);
            //do something with the color
        }
    }*/
}
