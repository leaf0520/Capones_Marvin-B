using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float MovementSpeed;
    private bool isLookingRight;

    private SpriteRenderer enemySprite;

    private void Awake()
    {
        enemySprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isLookingRight)
        {
            transform.Translate((Vector2.right * (MovementSpeed * Time.deltaTime)));
        }
        else
        {
            transform.Translate((Vector2.left * (MovementSpeed * Time.deltaTime)));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isLookingRight = !isLookingRight;
        if (isLookingRight)
            enemySprite.flipX = true;
        else
            enemySprite.flipX = false;

    }
}
