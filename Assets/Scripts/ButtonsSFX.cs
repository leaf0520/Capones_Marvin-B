using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsSFX : MonoBehaviour
{

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonSfx);
    }

    public void ButtonSfx()
    {
        AudioController.Instance.PlaySFX(AudioController.Instance.ButtonsSFX);
    }
    public void ButtonSfxReturn()
    {
        AudioController.Instance.PlaySFX(AudioController.Instance.ButtonsSFX);
    }
}
