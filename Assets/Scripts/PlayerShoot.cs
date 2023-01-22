using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletSpawnPosition;
    public float BulletForce;

    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_sprite.flipX)
        {
            BulletSpawnPosition.localPosition = new Vector3(-.275f, .38f, 0);
        }
        else
        {
            BulletSpawnPosition.localPosition = new Vector3(.275f, .38f, 0);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bulletClone = Instantiate(Bullet, BulletSpawnPosition.position, Quaternion.identity);
            if (_sprite.flipX)
            {
                //                                                         (-1, 0, 0)
                bulletClone.GetComponent<Rigidbody2D>().AddForce(-transform.right * BulletForce, ForceMode2D.Impulse);
            }
            else
            {
                //                                                         (1, 0, 0)
                bulletClone.GetComponent<Rigidbody2D>().AddForce(transform.right * BulletForce, ForceMode2D.Impulse);
            }
        }
    }
}
