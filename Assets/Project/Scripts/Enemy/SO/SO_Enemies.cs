using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy",menuName ="EnemiesData")]
public class SO_Enemies : ScriptableObject
{
    [SerializeField] private float _viewDistance;
    [SerializeField] private float _viewAngle;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _chaseSpeed;

    [SerializeField] private float _limitDistance;

    public float ViewDistance => _viewDistance;
    public float ViewAngle => _viewAngle;

    public float MoveSpeed => _moveSpeed;
    public float ChaseSpeed => _chaseSpeed;

    public float LimitDistance => _limitDistance;
}
