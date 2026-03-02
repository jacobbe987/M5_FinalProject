using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Button : MonoBehaviour, I_InteractableObj
{
    [SerializeField] private Animator _animator;

    private bool _isOpen = false;
    public void Interact()
    {
        if (_isOpen)
        {
            _animator.SetTrigger("_isClosing");
        }
        else
        {
            _animator.SetTrigger("_isOpening");
        }

        _isOpen = !_isOpen;
        
    }

    public string InteractableText()
    {
        return "Use F to press the button";
    }
}
