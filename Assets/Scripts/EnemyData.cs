using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public int HP;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            HP--;
            Destroy(col.gameObject);
            Debug.Log(HP);
            if (HP <= 0)
            {
                PlayerSavedValues.Instance.AddScore(100);
                Destroy(gameObject);
            }
        }
    }
}
