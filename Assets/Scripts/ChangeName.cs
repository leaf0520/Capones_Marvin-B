using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
//using System.Diagnostics;

public class ChangeName : MonoBehaviour
{
    private Sprite PlayerSprite;
    public Image PlayerImage;
    public TextMeshProUGUI PlayerNameText;


    public string NewName;

    public void ChangeNameButton(string newName)
    {
        PlayerNameText.text = newName;
        PlayerNameText.color = Color.red;
        PlayerNameText.fontSize = 50;
        PlayerImage.gameObject.SetActive(false);
    }

   public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeNameButton(NewName);
            PlayerImage.sprite = PlayerSprite;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            PlayerImage.gameObject.SetActive(true);
        }
    }
    #region Default
    /*
    private void Awake()
    {
        Debug.Log("Awake");
    }
    private void Start()
    {
        Debug.Log("Start");
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }


    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }
    private void Update()
    {
        Debug.Log("Update");
    }
    private void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }
    */
    #endregion
}
