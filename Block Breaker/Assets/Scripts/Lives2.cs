﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeAwayLife()
    {
        if(gameObject != null)
        {
            Destroy(gameObject);
        }
        
    }
}
