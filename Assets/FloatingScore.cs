﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScore : MonoBehaviour
{

    private float DestroyTime = 2f;
    private Vector3 Offset = new Vector3(0,2,0);
    void Start()
    {
        Destroy(gameObject, DestroyTime);
        transform.localPosition += Offset;
    }

  
}
