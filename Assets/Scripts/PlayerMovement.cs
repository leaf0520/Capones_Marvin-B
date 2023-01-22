using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerData PlayerDataRef;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private int _jumpCount = 0;
    private bool _isRun;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();

        transform.position = PlayerDataRef.SpawnPos();
    }

    private void Update()
    {
        //MovementUsingTranslate();
        //MovementUsingGetAxis();
        MovementUsingPhysics();

        Jump();

        if (Input.GetKeyDown(KeyCode.F))
        {
            _animator.SetTrigger("Attack");
        }

        _animator.SetBool("Run", _isRun);
        _animator.SetFloat("YAxis", _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (_jumpCount < PlayerDataRef.MaxJumpCount)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
                _rigidbody2D.AddForce(Vector2.up * PlayerDataRef.JumpForce, ForceMode2D.Impulse);
                _jumpCount++;
            }
        }
    }

    private void MovementUsingPhysics()
    {
        float x = Input.GetAxis("Horizontal");

        if (Mathf.Abs(x) > 0)
        {
            _isRun = true;
        }

        if (Mathf.Abs(x) < .5f && _isRun)
        {
            _isRun = false;
        }

        if (x > 0)
        {
            _sprite.flipX = false;
        }
        else if (x < 0)
        {
            _sprite.flipX = true;
        }

        _rigidbody2D.velocity = new Vector2(x * PlayerDataRef.MovementSpeed, _rigidbody2D.velocity.y);
    }

    private void MovementUsingGetAxis()
    {
        float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        if (Mathf.Abs(x) > 0)
        {
            _isRun = true;
        }

        if (Mathf.Abs(x) < .5f && _isRun)
        {
            _isRun = false;
        }

        if (x > 0)
        {
            _sprite.flipX = false;
        }
        else if (x < 0)
        {
            _sprite.flipX = true;
        }

        transform.position += new Vector3(x * PlayerDataRef.MovementSpeed, /*y*/0 * PlayerDataRef.MovementSpeed, 0);
    }

    private void MovementUsingTranslate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // vector2.left = (-1,0,0)
            transform.Translate(Vector2.left * PlayerDataRef.MovementSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // vector2.right = (1,0,0)
            transform.Translate(Vector2.right * PlayerDataRef.MovementSpeed);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            // vector2.up = (0,1,0)
            transform.Translate(Vector2.up * PlayerDataRef.MovementSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            // vector2.down = (0,-1,0)
            transform.Translate(Vector2.down * PlayerDataRef.MovementSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Ground"))
        {
            _jumpCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("OffGround"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //throw new NotImplementedException();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //throw new NotImplementedException();
    }
}
