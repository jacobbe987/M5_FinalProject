using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroller : Enemy
{
    [SerializeField] protected Transform[] _waypointsArr;
    protected int _currentIndex;
    protected override void Idle()
    {
        _currentState = EnemyState.State.Patrol;
    }

    protected override void Start()
    {
        base.Start();
        _currentState = EnemyState.State.Patrol;
        _agent.SetDestination(_waypointsArr[_currentIndex].position);
    }

    protected override void Patrol()
    {
        if(!_agent.pathPending && _agent.remainingDistance < 0.2)
        {
            _currentIndex = (_currentIndex + 1)% _waypointsArr.Length;
            _agent.SetDestination(_waypointsArr[_currentIndex].position);
        }
    }
    
}
