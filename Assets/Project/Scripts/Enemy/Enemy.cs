using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected SO_Enemies _data;
    [SerializeField] protected LayerMask _playerLayermask;
    [SerializeField] protected LayerMask _obstacleLayerMask;

    protected NavMeshAgent _agent;
    protected EnemyState.State _currentState;
    protected Transform _player;
    protected Vector3 _lastKnownPos;

    protected virtual void Start()
    {
        _agent= GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _agent.speed = _data.MoveSpeed;
    }

    protected virtual void Update()
    {
        CheckPlayer();

        switch (_currentState)
        {
            case EnemyState.State.Idle:
                Idle();
                break;

            case EnemyState.State.Patrol:
                Patrol();
                break;

            case EnemyState.State.Chase:
                Chase();
                break;

            case EnemyState.State.Search:
                Search();
                break;
        }
    }

    protected void CheckPlayer()
    {
        if (CanSeePlayer())
        {
            _currentState = EnemyState.State.Chase;
        }
    }

    protected bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, _player.position) > _data.ViewDistance)
        {
            return false;
        }
            

        Vector3 playerDir = (_player.position - transform.position).normalized;

        if (Vector3.Angle(transform.forward, playerDir) < _data.ViewAngle / 2f)
        {
            if (!Physics.Raycast(transform.position, playerDir,
                Vector3.Distance(transform.position, _player.position),
                _obstacleLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    protected virtual void Idle() { }
    protected virtual void Patrol() { }

    protected virtual void Chase() 
    {
        _agent.speed = _data.ChaseSpeed;
        _agent.SetDestination(_player.position);
        _lastKnownPos = _player.position;
        if (!CanSeePlayer())
        {
            _currentState = EnemyState.State.Search;
        }
    }
    protected virtual void Search() 
    {
        _agent.speed = _data.MoveSpeed;
        _agent.SetDestination(_lastKnownPos);
        if(Vector3.Distance(transform.position, _lastKnownPos)< _data.SearchLimit)
        {
            _currentState=EnemyState.State.Idle;
        }
    }
}
