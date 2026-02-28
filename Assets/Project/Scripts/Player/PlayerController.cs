using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Camera _cam;

    private void Awake()
    {
        _agent= GetComponent<NavMeshAgent>();
        _cam= Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Move();
        }
    }

    private void Move()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            _agent.SetDestination(hit.point);
        }
    }
}
