using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ", transform.position.z);
        }
    }
}
