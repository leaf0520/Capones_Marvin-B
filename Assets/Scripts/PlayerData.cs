using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public Image HPBar;

    // Player Movement
    public float MovementSpeed;
    public float JumpForce;
    public int MaxJumpCount;

    // Player Stats
    public float MaxHealth;
    private float _currentHealth;

    // Checkpoint stats
    private float _checkpointPosX;
    private float _checkpointPosY;
    private float _checkpointPosZ;
    private void Awake()
    {
        _currentHealth = MaxHealth;
    }

    private void Start()
    {
        PlayerPrefs.DeleteKey("PlayerScore");
    }

    public void AddHealth(float value)
    {
        if (_currentHealth < MaxHealth)
        {
            _currentHealth += value;
            //_currentHealth = _currentHealth + value;
        }
        HPBarUpdate();
    }
    public void ReduceHealth(float value)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= value;
            //_currentHealth = _currentHealth - value;

            if (_currentHealth <= 0)
            {
                SceneManager.LoadScene("MainMenu");
                Debug.Log("GAME OVER");
            }
        }
        HPBarUpdate();
    }

    private void HPBarUpdate()
    {
        HPBar.fillAmount = _currentHealth / MaxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ReduceHealth(5);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddHealth(10);
        }
    }

    public Vector3 SpawnPos()
    {
        if (PlayerPrefs.HasKey("PlayerPosX"))
        {
            _checkpointPosX = PlayerPrefs.GetFloat("PlayerPosX");
            _checkpointPosY = PlayerPrefs.GetFloat("PlayerPosY");
            _checkpointPosZ = PlayerPrefs.GetFloat("PlayerPosZ");
        }
        else
        {
            _checkpointPosX = transform.position.x;
            _checkpointPosY = transform.position.y;
            _checkpointPosZ = transform.position.z;
        }

        return new Vector3(_checkpointPosX, _checkpointPosY, _checkpointPosZ);
    }
}
