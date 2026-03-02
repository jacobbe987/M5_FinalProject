using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private NavMeshSurface _navMeshSurface;
    public void DoorClosed()
    {
        _navMeshSurface.BuildNavMesh();
    }
    public void DoorOpened()
    {
        _navMeshSurface.BuildNavMesh();
    }
}
