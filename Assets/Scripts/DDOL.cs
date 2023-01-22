using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    public static DDOL Instance;
    private void Awake()
    {
        // if (GameObject.FindObjectsOfType<DDOL>().Length > 1)
        // {
        //     
        // }

        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
