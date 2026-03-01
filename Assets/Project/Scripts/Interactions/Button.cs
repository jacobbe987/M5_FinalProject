using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Button : MonoBehaviour, I_InteractableObj
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshSurface _navMeshSurface;

    private bool _isOpen;
    private bool _isClose;
    public void Interact()
    {
        if(_isOpen)
        {
            _animator.SetTrigger("_isClosing");
            _navMeshSurface.BuildNavMesh();
            _isOpen = false;
        }

        if (_isClose)
        {
            _animator.SetTrigger("_isOpening");
            _navMeshSurface.BuildNavMesh();
            _isOpen = false;
        }
    }

    public string InteractableText()
    {
        return "Use F to press the button";
    }
}
