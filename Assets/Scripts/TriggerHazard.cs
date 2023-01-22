using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHazard : MonoBehaviour
{
    public float Damage;
    private PlayerData _playerData;
    public bool IsStayTrigger;
    private void Awake()
    {
        _playerData = GameObject.FindObjectOfType<PlayerData>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            _playerData.ReduceHealth(Damage);
       }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!IsStayTrigger)
        {
            return;
        }
        else
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                _playerData.ReduceHealth(Damage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
  
    }
}
