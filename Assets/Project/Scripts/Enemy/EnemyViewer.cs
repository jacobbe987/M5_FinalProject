using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyViewer : Enemy
{
    [SerializeField] protected float _rotateTimer;

    private Coroutine _rotate;

    protected override void Start()
    {
        base.Start();
        _currentState = EnemyState.State.Idle;
        StartCoroutine(Rotate());
    }

    protected override void Idle()
    {
        if (_rotate == null)
        {
            _rotate = StartCoroutine(Rotate());
        }
    }

    protected override void Chase()
    {
        if (_rotate != null)
        {
            StopCoroutine(Rotate());
            _rotate = null;
        }
        base.Chase();
    }

    private IEnumerator Rotate()
    {
        yield return new WaitForSeconds(_rotateTimer);
        if (_currentState == EnemyState.State.Idle )
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
