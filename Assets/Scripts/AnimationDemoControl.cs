using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDemoControl : MonoBehaviour
{
    public Animator _animator;

    public void PlayAnimation(string animationName)
    {
        _animator.Play(animationName);
    }


}
