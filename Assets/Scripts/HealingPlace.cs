using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPlace : MonoBehaviour
{
    public float Heal;
    private PlayerData _playerData;

    private void Awake()
    {
        _playerData = GameObject.FindObjectOfType<PlayerData>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            _playerData.AddHealth(Heal);
        }
    }
   
}
