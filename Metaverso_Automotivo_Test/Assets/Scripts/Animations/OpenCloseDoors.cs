using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoors : MonoBehaviour
{
    [SerializeField] private Animator[] _doorsAnimator;
    private bool _doorsOpen = false;
    private int _doorsOpenHash;

    private void Start()
    {
        _doorsOpenHash = Animator.StringToHash("doorsOpen");
    }

    public void ToggleDoorState()
    {
        foreach (Animator animator in _doorsAnimator)
        {
            animator.SetBool("Open", !_doorsOpen);
        }
        
        _doorsOpen = !_doorsOpen;
    }
}
